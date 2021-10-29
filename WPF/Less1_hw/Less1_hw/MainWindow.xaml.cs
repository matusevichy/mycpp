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

namespace Less1_hw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double sum = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetTextBox(((Button)sender).Content.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "0")
            {
                textBox.Text += ((Button)sender).Content;
            }
        }
        
        private void SetTextBox(string str)
        {
            string tmpStr = textBox.Text + str;
            double value = 0;
            Double.TryParse(tmpStr, out value);
            textBox.Text = value.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            double value = 0;
            Double.TryParse(textBox.Text, out value);
            if (value%1==0)
            {
                textBox.Text += ",";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            textBlock.Text = "0";
            sum = 0;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (textBlock.Text == "")
            {
                sum = Double.Parse(textBox.Text);
            }
            else
            {
                Calculate();
            }
            textBlock.Text = sum.ToString() + "+";
            textBox.Text = "";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (textBlock.Text == "")
            {
                sum = Double.Parse(textBox.Text);
            }
            else
            {
                Calculate();
            }
            textBlock.Text = sum.ToString() + "-";
            textBox.Text = "";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (textBlock.Text == "")
            {
                sum = Double.Parse(textBox.Text);
            }
            else
            {
                Calculate();
            }
            textBlock.Text = sum.ToString() + "*";
            textBox.Text = "";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (textBlock.Text == "")
            {
                sum = Double.Parse(textBox.Text);
            }
            else
            {
                Calculate();
            }
            textBlock.Text = sum.ToString() + "/";
            textBox.Text = "";
        }
        private void Calculate()
        {
            var act = textBlock.Text.Last();
            switch (act)
            {
                case '+':
                    sum += Double.Parse(textBox.Text);
                    break;
                case '-':
                    sum -= Double.Parse(textBox.Text);
                    break;
                case '*':
                    sum *= Double.Parse(textBox.Text);
                    break;
                case '/':
                    sum /= Double.Parse(textBox.Text);
                    break;
                default:
                    break;
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (textBlock.Text != "")
            {
                Calculate();
                textBlock.Text = sum.ToString();
                textBox.Text = "";
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (textBox.Text !="")
            {
                textBox.Text = "-" + textBox.Text;
            }
        }
    }
}
