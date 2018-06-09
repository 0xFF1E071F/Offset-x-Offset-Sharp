using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
/*
*      how it works (see Worker_DoWork):
*      (this is a draft, more steps need to be added)
*         [lblProcess]   [lblScan]
*          process -> scan -> wait -> no file -yes-> larger than max size -no-> is there auto fixed ranges -no-> Done [lblDone]
*              ^                            | no                   | yes                        | yes
*              |                            v                      |                            |
*              <--------------------- take result[index]           |                            |
*              ^                                                   v                            |
*              <-----------------------------------split range to variable + fixed              |
*                                                     [lblSplit]   ^                            |
*                                                                  |                            v
*                                                                  |               clear added fixed ranges
*                                                                  |                            |
*                                                                  |                            v
*                                                                  |              set signature as fixed range
*                                                                  |                            |
*                                                                  |            [lblUpdate]     v
*                                                                  <-------exclude signature range from variable range
*/


/*
 *  use inverted mode
 *  (not sure) make inverted mode available for the user
 * 
 */
namespace oxoSharp.Core
{
    class AutoProcess : oxoCore
    {

        private event ProgressChangedEventHandler StateCallBack;
        List<int[]> _signatures = new List<int[]>();
        public int[][] Singatures
        {
            get
            {
                if (_signatures.Count == 0)
                    return new int[][] { new int[] { Session.start, Session.end } };
                return _signatures.ToArray();
            }
        }

        Random random = new Random();
        public AutoProcess(ProgressChangedEventHandler ProgressCallBack, RunWorkerCompletedEventHandler WorkCompletedCallBack, ProgressChangedEventHandler StateCallBack, bool CreateFiles = true)
            : base(ProgressCallBack, WorkCompletedCallBack, CreateFiles)
        {
            this.StateCallBack += StateCallBack;
        }
        protected override void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _signatures.Clear();
            /// use unkSize

            Config cfg = GlobalDataAndMethods.Config;
            while (_continue)
            {
                //    process();
                SendState("process");
                base.worker_DoWork(sender, e);

                //scan();
                //wait();
                SendState("scan");
                GlobalDataAndMethods.Scan(true);

                //if (!noFile)
                if (NextInterval())
                {
                    SendState("next");
                    //    TakeResult[index]; //already done by NextInterval();
                }
                else
                {
                    if (cfg.AutoGenerateFixedRange)
                    {
                        if ((base.Session.end - base.Session.start) > cfg.SignatureMaxSize)
                        {
                            SendState("split");
                            // SplitToVarAndFixed();
                        }
                        else
                        {
                            SaveSignature();
                            if (Session.AutoAddedFixedRanges.Count > 0)
                            {
                                SendState("update");
                                Session.AutoAddedFixedRanges.Clear();
                                Session.AutoAddedFixedRanges.AddRange(_signatures);
                                //updateVariableRangeToOldOneMinusSignatures();
                            }
                            else
                                break;

                        }
                    }
                    SaveSignature();
                    break;
                }
            }
            SendState("done");
            #region Draft
            //while (true)
            //{
            //    // process
            //    base.worker_DoWork(sender, e);
            //    // scan
            //    GlobalDataAndMethods.Scan(WaitForExit: true); // av config should be checked in frmAuto

            //    if (!NextInterval()) // no file
            //    {
            //        if (GlobalDataAndMethods.Config.AutoGenerateFixedRange)
            //        {
            //            if (base.Session.size <= GlobalDataAndMethods.Config.SignatureMaxSize)
            //            {
            //                ///
            //                //// this is the case where viral sig is found and conform to criteras
            //                ///

            //                //add viral interval to this.Signatures
            //                SaveSignature();
            //                // if (there is auto defined fixed interval)
            //                if (Session.AutoAddedFixedRanges.Count > 0)
            //                {
            //                    ////////////////
            //                    // INCOMPLETE //
            //                    ////////////////

            //                    // clear Session.AutoAddedFixedRanges
            //                    Session.AutoAddedFixedRanges.Clear();
            //                    // add all viral intervals to Session.SetAutoAddedFixedRangesWithoutCollisionWithVariableRange
            //                    Session.AutoAddedFixedRanges.AddRange(Signatures);
            //                    // variable range without signatures
            //                    //Session.ExcludeAutoAddedRangeFromVariableRange();
            //                    throw new NotImplementedException();

            //                }
            //                else
            //                {
            //                    //break;
            //                }
            //            }
            //            else
            //            {
            //                //SplitRange();
            //            }
            //        }
            //        else
            //        {
            //            SaveSignature();
            //        }
            //    }
            //}
            #endregion
        }

        private void SendState(string state)
        {
            StateCallBack(this, new ProgressChangedEventArgs(0, state));
        }

        private void SaveSignature()
        {
            _signatures.Add(new int[] { Session.start, Session.end });
        }

        private bool NextInterval()
        {
            int[][] undetected = base.ListUndetectedIntervals(true);
            if (undetected.Length > 0)
            {
                SetNextIntervalInSession(undetected, GenerateIndex(undetected.Length));
                return true;
            }
            else
                return false;
        }

        private void SetNextIntervalInSession(int[][] undetected, int index)
        {
            base.Session.start = undetected[index][0];
            base.Session.end = undetected[index][1];
            base.Session.AutoCalculateSize();
        }

        private int GenerateIndex(int numberOfRanges)
        {
            switch (GlobalDataAndMethods.Config.nextRange)
            {
                case NextRange._last:
                    return numberOfRanges - 1;
                case NextRange._random:
                    return random.Next(numberOfRanges);
                default:
                    return 0;
            }
        }
    }
}
