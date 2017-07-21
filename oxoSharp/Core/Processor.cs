using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace oxoSharp.Core
{
    public class TestProcessor
    {
        int counter = 0;
        public void test()
        {
            Processor p = new Processor();

            Task Third = new Task(new Task.Action(ReturnFalse), Task.FinalTask, Task.FinalTask);
            Task Second = new Task(new Task.Action(ReturnTrue), Third, Task.FinalTask);
            Task First = new Task(new Task.Action(ReturnFalse), Task.FinalTask, Second);
            Task EP = new Task(new Task.Action(EPmethod), First, Task.FinalTask);
            p.EntryPoint = EP;
            p.ExecuteProcess();

        }

        public bool EPmethod(object o)
        {
            Console.WriteLine("EP");
            counter = 0;
            return true;
        }
        public bool ReturnTrue(object o)
        {
            ShowCounter();
            return true;
        }
        public bool ReturnFalse(object o)
        {
            ShowCounter();
            return false;
        }
        private void ShowCounter()
        {
            Console.WriteLine((++counter).ToString());
        }

    }
    public class Processor
    {
        public Task EntryPoint;
        private Task NextTask;
        private bool _continue = true;

        private BackgroundWorker _worker;

        public Processor()
        {
            _worker = new BackgroundWorker() { WorkerSupportsCancellation = true };
            _worker.DoWork += _worker_DoWork;
        }

        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Continue && NextTask != null)
                NextTask = (NextTask.Execute() ? NextTask.NextWhenTrue : NextTask.NextWhenFalse);
        }
        public void ExecuteProcess()
        {
            _continue = true;
            NextTask = EntryPoint;
            _worker.RunWorkerAsync();
        }
        public bool Continue { get { return _continue; } }
        public void Stop()
        {
            _continue = false;
        }
        public void ForceStop()
        {
            _worker.CancelAsync();
        }
    }
    public class Task
    {
        public delegate bool Action(object arg);
        private Task _NextWhenTrue;
        private Task _NextWhenFalse;
        private Action _action;
        private object _argument;
        private BackgroundWorker _worker;

        private Task()
        {
            _action = new Action(NoAction);
        }
        private bool NoAction(object obj)
        {
            return true;
        }
        public Task(Action Action, Task NextWhenTrue, Task NextWhenFalse, object Argument = null)
        {
            this._action = Action;
            this._NextWhenFalse = NextWhenFalse;
            this._NextWhenTrue = NextWhenTrue;
            this._argument = Argument;
        }
        public bool Execute()
        {
            return _action(_argument);
        }
        public bool IsBusy()
        {
            return _worker.IsBusy;
        }
        public Task NextWhenTrue
        {
            get
            {
                return _NextWhenTrue;
            }
            set
            {
                _NextWhenTrue = value;
            }
        }
        public Task NextWhenFalse
        {
            get
            {
                return _NextWhenFalse;
            }
            set
            {
                _NextWhenFalse = value;
            }
        }

        public static Task FinalTask = new Task();
    }
}
