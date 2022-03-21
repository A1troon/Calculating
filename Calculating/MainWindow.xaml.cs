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
using System.Text.RegularExpressions;
using System.Globalization;

namespace Calculating
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string first = "";
        string second = "0";
        public MainWindow()
        {
            InitializeComponent();
            foreach (var elememnt in container.Children)
            {
                if( elememnt is Button)
                {
                   ((Button)elememnt).Click += onClick;
                }
            }
        }

        private void onClick(object sender, RoutedEventArgs e)
        {
            string str = ((Button)e.OriginalSource).Content.ToString();
            if (first!="" && Regex.IsMatch(str,"^[-+/X=]$"))
                //Regex.IsMatch(mainLabel.Content.ToString(), @".*[-+/X].*")
                historyLabel.Text = first + second + '\n'+ historyLabel.Text;
            switch (str)
            {
                case "%":
                    break;
                case "+":
                    first = new DataTable().Compute(mainLabel.Content.ToString(), null).ToString().Replace(',', '.') +"+";
                    second = "0";
                    break;
                case "-":
                    first = new DataTable().Compute(mainLabel.Content.ToString(), null).ToString().Replace(',', '.') + "-";
                    second = "0";
                    break;
                case "=":
                    second = new DataTable().Compute(mainLabel.Content.ToString(), null).ToString().Replace(',', '.');
                    first = "";
                    break;
                case "X":
                    first = new DataTable().Compute(mainLabel.Content.ToString(), null).ToString().Replace(',', '.') + "*";
                    second = "0";
                    break;
                case "/":
                    first = new DataTable().Compute(mainLabel.Content.ToString(), null).ToString().Replace(',', '.') + "/";
                    second = "0";
                    break;
                case "+/-":
                    if (second != "0")
                        if (Regex.IsMatch(second, @"-\d*"))
                            second = second.Substring(1).Replace(',', '.');
                        else
                            second = "-" + second;
                    break;
                case "<-":
                    second = second.Substring(0,second.Length-1);
                    if (second == "")
                        second = "0";
                    break;
                case ".":
                    if (!Regex.IsMatch(second, @"\d*[,.]\d*"))
                        second +=str;
                    break;
                case "sqrt(x)":
                    double temp1 = Convert.ToDouble(second.Replace('.', ','));
                    if (temp1 > 0)
                        second = Math.Sqrt(temp1).ToString().Replace(',', '.');
                    break;
                case "x^2":
                    double temp = Convert.ToDouble(second.Replace('.', ','));
                    second = (temp*temp).ToString().Replace(',', '.');
                    break;
                case "1/x":
                    double temp3 = Convert.ToDouble(second.Replace('.', ','));
                    if (temp3 != 0)
                        second = (1/temp3).ToString().Replace(',', '.');
                    break;
                case "CE":
                    second = "0";
                    break;
                case "C":
                    first = "";
                    second = "0";
                    break;
                default:
                    if (second == "0")
                        second = str;
                    else
                        second += str;
                    break;
            }
            mainLabel.Content = first + second;
            if (!Regex.IsMatch(mainLabel.Content.ToString(), @"^[-\d]"))
                mainLabel.Content = "0";
        }

    }
}
