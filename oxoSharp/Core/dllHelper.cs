//#define debug
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace oxoSharp.Core
{
    internal static class dllHelper
    {
        private delegate void dllProcessDelegate(IntPtr lpBuffer, int BufferSize, Mode mode, int Fill, int Start, int End, int Step, IntPtr CallBackFunction);
        private delegate void dllFillFixedRangeDelegate(IntPtr lpBuffer, int BufferSize, Mode mode, int Fill, int FixedRangeStart, int FixedRangeEnd);
        private unsafe delegate void dllFreeTempBufferDelegate(byte* lpTempBuffer);

        static string _dllPath = "OxOsharpDLL.dll";
        private const string ProcessAPIname = "Process";
        private const string FillFixedRangeAPIname = "FillFixedRange";
        private const string FreeTempBufferAPIname = "FreeTempBuffer";
        static dllProcessDelegate dllProcess;
        static dllFillFixedRangeDelegate dllFillFixedRange;
        static dllFreeTempBufferDelegate dllFreeTempBuffer;

        public static string dllPath
        {
            set
            {
                _dllPath = value;
            }
        }
        internal static void CallProcess(IntPtr lpBuffer, int BufferSize, Mode mode, int Fill, int Start, int End, int Size, IntPtr CallBackFunction)
        {
            try
            {
                dllProcess(lpBuffer, BufferSize, mode, Fill, Start, End, Size, CallBackFunction);
            }
            finally { }
        }
        internal static void CallFillFixedRange(IntPtr lpBuffer, int BufferSize, Mode mode, int Fill, int FixedRangeStart, int FixedRangeEnd)
        {
            dllFillFixedRange(lpBuffer, BufferSize, mode, Fill, FixedRangeStart, FixedRangeEnd);
        }
        internal static unsafe void CallFreeTempBuffer(byte* lpTempBuffer)
        {
            dllFreeTempBuffer(lpTempBuffer);
        }
        private static Delegate GetDelegateForImportedFunction(string ProcName, Type delegateType)
        {
            return Marshal.GetDelegateForFunctionPointer(GetProcAddress(LoadLibraryW(_dllPath), ProcName), delegateType);
        }
        internal static bool Init()
        {
            #region debug
#if debug
            dllPath = @"D:\.net\vs2013\oxoSharp\OxOsharp_dll\OxOsharp.dll";
#endif
            #endregion

            try
            {
                dllProcess = (dllProcessDelegate)GetDelegateForImportedFunction(ProcessAPIname, typeof(dllProcessDelegate));
                dllFillFixedRange = (dllFillFixedRangeDelegate)GetDelegateForImportedFunction(FillFixedRangeAPIname, typeof(dllFillFixedRangeDelegate));
                dllFreeTempBuffer = (dllFreeTempBufferDelegate)GetDelegateForImportedFunction(FreeTempBufferAPIname, typeof(dllFreeTempBufferDelegate));
                return (dllProcess != null && dllFillFixedRange != null && dllFreeTempBuffer != null);
            }
            catch { }
            return false;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibraryW(string DllName);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hDLL, string Proc);
    }
}
