using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace oxoSharp.Core
{
    public unsafe delegate bool CallBackDelegate(byte* buffer, int CurrentStart, int CurrentEnd, int size);

    public class oxoCore
    {
        BackgroundWorker worker;
        //string _filename, Session.output;
        //int Session.start, _End, Session.size, Session.value;
        //Mode Session.mode;
        //private List<int[]> Session.FixedRanges;

        private Session _session;
        

        // these two viariables are used to calculate the progress 
        int _Counter; // how many time callback function was called
        private double _numberOfLoops; // the estimated number of loops (how many times the callback function should be called)

        private ProgressChangedEventHandler _progressCallBack;
        private RunWorkerCompletedEventHandler _workCompletedCallBack;

        public String Error = "";
        private bool _createFiles;

        private const string generatedFilePattern = @"(?<start>[0-9a-fA-F]+)-(?<end>[0-9a-fA-F]+)\.exe";
        private static Regex regex = new Regex(generatedFilePattern);
        private bool Continue = true;
        private unsafe byte* lpTempBuffer;

        public oxoCore(ProgressChangedEventHandler ProgressCallBack, RunWorkerCompletedEventHandler WorkCompletedCallBack, bool CreateFiles = true)
        {
            _createFiles = CreateFiles;
            SetWorkerEventHandlers(ProgressCallBack, WorkCompletedCallBack);
            InitBackgroundWorker();

            // load oxoSharp.dll with dllHelper init
            if (!dllHelper.Init())
                throw new Exception("I couldn't load/resolve the dll/API address ... deleted my DLL? not cool");
        }

        private void ProgressCallBackCaller(object sender, ProgressChangedEventArgs e)
        {
            _progressCallBack(sender, e);
        }
        private void WorkCompleteCaller(object sender, RunWorkerCompletedEventArgs e)
        {
            _workCompletedCallBack(sender, e);
        }

        private void InitBackgroundWorker()
        {
            worker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            worker.ProgressChanged += ProgressCallBackCaller;
            worker.RunWorkerCompleted += WorkCompleteCaller;
            worker.DoWork += worker_DoWork;
        }
        private void SetWorkerEventHandlers(ProgressChangedEventHandler progressChangedEH, RunWorkerCompletedEventHandler workCompleteEH)
        {
            SetWorkerProgressChanged(progressChangedEH);
            SetWorkerWorkComplete(workCompleteEH);
        }

        private void SetWorkerWorkComplete(RunWorkerCompletedEventHandler workCompleteEH)
        {
            _workCompletedCallBack = workCompleteEH;
        }
        private void SetWorkerProgressChanged(ProgressChangedEventHandler progressChangedEH)
        {
            _progressCallBack = progressChangedEH;
        }
        public void SetSession(Session session)
        {
            this.Session = session;
            #region check parameters
            if (session.end < session.start)
                throw new Exception("Start address can't be greater than End address ... I mean, come on, seriously?");
            if (session.size > (session.end - session.start))
                this.Session.size = session.end - session.start; // I fix this in silence
            #endregion
            //_filename = session.fileLocation;
            //Session.output = session.output;
            //Session.start = session.start;
            //_End = session.end;
            //Session.size = session.size;
            //Session.value = session.value;
            //Session.mode = session.mode;
            //Session.FixedRanges = session.FixedRanges;
        }
        protected virtual void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Continue = true;
            ProcessInterval();
        }

        private void ProcessInterval()
        {
            ClearOutputFolder();
            byte[] buffer = ReadFile();
            if (buffer == null) return;

            _Counter = 0; // reinit counter
            _numberOfLoops = Math.Ceiling((double)(Session.end - Session.start) / (double)Session.size);
            if (_numberOfLoops == 0) _numberOfLoops++; // if the parameters checked and corrected this case is impossible

            unsafe
            {
                fixed (byte* ptr = &buffer[0])
                {
                    dllHelper.CallProcess((IntPtr)ptr, buffer.Length, Session.mode, Session.value, Session.start, Session.end, Session.size, Marshal.GetFunctionPointerForDelegate(new CallBackDelegate(CallBack)));
                }
            }
        }


        private unsafe bool CallBack(byte* buffer, int CurrentStart, int CurrentEnd, int size)
        {
            lpTempBuffer = buffer;
            if (_createFiles)
            {
                string FileName = Path.Combine(Session.output, GlobalDataAndMethods.OutputFormat(CurrentStart, CurrentEnd, true));
                try
                {
                    ApplyFixedRanges(buffer, size);
                    WriteToFile(buffer, size, FileName);
                }
                catch { }
            }

            _Counter++;
            worker.ReportProgress((int)((double)_Counter * 100.0 / _numberOfLoops));
            return Continue;
        }

        unsafe private void WriteToFile(byte* buffer, int size, string FileName)
        {
            byte[] managedBuffer = new byte[size];
            Marshal.Copy((IntPtr)buffer, managedBuffer, 0, size);
            File.WriteAllBytes(FileName, managedBuffer);
        }

        private unsafe void ApplyFixedRanges(byte* buffer, int bufferSize)
        {
            try
            {
                foreach (int[] range in Session.AllFixedRanges)
                    if (CheckFixedRange(range, bufferSize))
                        dllHelper.CallFillFixedRange((IntPtr)buffer, bufferSize, Session.mode, Session.value, range[0], range[1]);
            }
            catch { }
        }

        private static bool CheckFixedRange(int[] range, int bufferSize)
        {
            return (range[0] < bufferSize && range[1] < bufferSize && range[0] < range[1]);
        }

        private byte[] ReadFile()
        {
            try
            {
                return File.ReadAllBytes(Session.fileLocation);
            }
            catch { Error = "I couldn't read the input file ... guys, that's the minimum"; return null; }
        }
        // start
        public void DoWork()
        {
            worker.RunWorkerAsync();
        }
        // stop
        public unsafe void StopWork()
        {
            Continue = false;
            new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(1000);
                worker.CancelAsync();
                Thread.Sleep(1000);
                dllHelper.CallFreeTempBuffer(lpTempBuffer); // the dll should have done that, but who knows
            })).Start();
        }

        public bool IsBusy()
        {
            return (worker != null && worker.IsBusy);
        }

        internal void ClearOutputFolder()
        {
            foreach (string filename in Directory.GetFiles(Session.output))
                try
                {
                    File.Delete(filename);
                }
                catch { }
        }

        // int[i,0] = start
        // int[i,1] = end
        public int[][] ListUndetectedIntervals()
        {
            if (Session.output == "" || !Directory.Exists(Session.output)) return null;
            string[] remainingFiles = Directory.GetFiles(Session.output);
            int[][] remainingIntervals = new int[remainingFiles.Length][];
            for (int i = 0; i < remainingFiles.Length; i++)
            {
                Match match = regex.Match(remainingFiles[i]);
                if (match.Success)
                {
                    remainingIntervals[i] = new int[2];
                    remainingIntervals[i][0] = int.Parse(match.Groups["start"].Value, NumberStyles.HexNumber);
                    remainingIntervals[i][1] = int.Parse(match.Groups["end"].Value, NumberStyles.HexNumber);
                }
            }
            return remainingIntervals;
        }
        internal Session Session
        {
            get
            {
                return _session;
            }
            set
            {
                _session = value;
            }
        }
    }
}
