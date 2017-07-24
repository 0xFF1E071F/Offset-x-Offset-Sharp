using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace oxoSharp.UserControls
{
    public partial class HexTextBox : FlashingTextBox
    {
        public int ErrorValue = -1;
        public HexTextBox()
        {
            InitializeComponent();
            EnableHandlers();
        }

        void HexTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (AcceptableChar(e.KeyChar))
                return;
            if (!isHexChar(e.KeyChar))
                e.Handled = true;
        }

        private static bool AcceptableChar(char c)
        {
            const int BackSpace = 8;
            const int Paste = 22;
            const int Copy = 3;
            const int Undo = 26;
            const int Redo = 25;
            return c == BackSpace || c == Paste || c == Copy || c == Undo || c == Redo;
        }

        void HexTextBox_TextChanged(object sender, EventArgs e)
        {
            bool changed = false;
            string newText = "";
            foreach (char c in this.Text)
            {
                if (isHexChar(c))
                    newText += c.ToString();
                else
                    changed = true;
            }
            if (changed)
            {
                SetText(newText);
            }
        }
        /// <summary>
        /// Sets a text without checking if hexformat or not
        /// </summary>
        /// <param name="Text"></param>

        public void SetText(string Text)
        {
            RemoveTextChangedHandler();
            this.Text = Text;
            SetTextChangedHandler();
        }

        public void DisableHandlers()
        {
            RemoveTextChangedHandler();
            RemoveKeyPressHandler();
        }
        public void EnableHandlers()
        {
            SetTextChangedHandler();
            SetKeyPressHandler();
        }
        private void SetTextChangedHandler()
        {
            this.TextChanged += HexTextBox_TextChanged;
        }
        private void RemoveTextChangedHandler()
        {
            this.TextChanged -= HexTextBox_TextChanged;
        }
        private void SetKeyPressHandler()
        {
            this.KeyPress += HexTextBox_KeyPress;
        }
        private void RemoveKeyPressHandler()
        {
            this.KeyPress -= HexTextBox_KeyPress;
        }
        private bool isHexChar(char c)
        {
            return ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'));
        }
        public bool ParseText(out int hexVal)
        {
            return int.TryParse(this.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out hexVal);
        }
        public int ParseText()
        {
            int hexVal;
            if (ParseText(out hexVal))
                return hexVal;
            else
                return ErrorValue;
        }
    }
}
