﻿using System;
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
            switch (str)
            {
                case "+":
                    first = new DataTable().Compute(mainLabel.Content.ToString(), null)+"+";
                    second = "0";
                    mainLabel.Content = first + second;
                    break;
                case "-":
                    first = new DataTable().Compute(mainLabel.Content.ToString(), null) + "-";
                    second = "0";
                    mainLabel.Content = first + second;
                    break;
                default:
                    if (second == "0")
                        second = str;
                    else
                        second += str;
                    break;
                   
            }
        }
    }
}
