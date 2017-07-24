using System;
using System.Windows.Forms;
namespace oxoSharp
{
    interface IIntervalForm
    {
        Values DialogValues();
        DialogResult ShowDialog();
    }
    public struct Values
    {
        public int[] SelectedInterval;
        public ThreeButtonsWindowAction Action;

        public Values(int[] SelectedInterval, ThreeButtonsWindowAction Action)
        {
            this.SelectedInterval = SelectedInterval;
            this.Action = Action;
        }
    }
}
