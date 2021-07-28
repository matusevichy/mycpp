using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Less1_hw
{
    public partial class Form1 : Form
    {
        List<int> numbers;
        public Form1()
        {
            InitializeComponent();
            numbers = new List<int>();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                string buttonText = (sender as Button).Text;
                //numbers.Add(Int32.Parse(buttonText));
                label2.Text += buttonText;
            }

        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            string buttonText = (sender as Button).Text;
            label1.Text += label2.Text;
            Calc();
            label1.Text += buttonText;
            label2.Text = "";
        }

        private void Calc()
        {
            if (label1.Text!="")
            {
                var regex = "(\\d+)([+-/*])(\\d+)";
                Match match = Regex.Match(label1.Text, regex);
                switch (match.Groups[2].Value)
                {
                    case "+":
                        var res = Int32.Parse(match.Groups[1].Value) + Int32.Parse(match.Groups[3].Value);
                        label1.Text = res.ToString();
                        break;
                    case "-":
                        res = Int32.Parse(match.Groups[1].Value) - Int32.Parse(match.Groups[3].Value);
                        label1.Text = res.ToString();
                        break;
                    case "*":
                        res = Int32.Parse(match.Groups[1].Value) * Int32.Parse(match.Groups[3].Value);
                        label1.Text = res.ToString();
                        break;
                    case "/":
                        res = Int32.Parse(match.Groups[1].Value) / Int32.Parse(match.Groups[3].Value);
                        label1.Text = res.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string buttonText = (sender as Button).Text;
            label1.Text += label2.Text;
            Calc();
            label2.Text = "";
        }
    }
}
