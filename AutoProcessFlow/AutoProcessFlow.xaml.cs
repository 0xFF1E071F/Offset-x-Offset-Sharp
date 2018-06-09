using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoProcessFlow
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AutProcessFlow : UserControl
    {
        SolidColorBrush _transparent = Brushes.Transparent;
        SolidColorBrush _green = Brushes.Green;

        List<Shape> shapes;
        public AutProcessFlow()
        {
            InitializeComponent();
            EnumShapes();
        }

        private void EnumShapes()
        {

            shapes = new List<Shape>()
            {
                process,
                scan,
                next,
                split,
                bNoFile,
                bMaxSize,
                bGrtMaxSize,
                update,
                done
            };
        }

        public void SetState(string state)
        {
            foreach (Shape s in shapes)
            {
                s.Dispatcher.BeginInvoke((Action)(() =>
                {
                    s.Fill = (s.Name == state) ? _green : _transparent;
                }));
            }
        }
        public void Status(string start, string end, string size)
        {
            txtStart.Dispatcher.BeginInvoke((Action)(() => { txtStart.Text = start; }));
            txtEnd.Dispatcher.BeginInvoke((Action)(() => { txtEnd.Text = end; }));
            txtSize.Dispatcher.BeginInvoke((Action)(() => { txtSize.Text = size; }));
        }
        public void SetConfig(string mode)
        {
            txtMode.Dispatcher.BeginInvoke((Action)(() => { this.txtMode.Text = mode; }));
        }
    }
}
