using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace Calculating
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Info {
            public string sum()
            {

            }
            private string first;
            private string second;
        }

        public MainWindow()
        {
            InitializeComponent();
            foreach (var elememnt in container.Children)
            {
                if( elememnt is Button)
                {
                   ((Button)elememnt).Click += inClick;
                }
            }
        }

        private void inClick(object sender, RoutedEventArgs e)
        {
            string str = ((Button)e.OriginalSource).Content.ToString();
        }
    }
}
