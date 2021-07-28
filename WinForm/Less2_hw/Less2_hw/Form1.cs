using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Less2_hw
{
    public partial class Form1 : Form
    {
        Dictionary<string, double> fuelDictionary;
        double[] costsArray;
        private Dictionary<string, double> dictionary;

        public Form1(Dictionary<string, double> dict, double[] costs)
        {
            InitializeComponent();
            fuelDictionary = dict;
            costsArray = costs;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = fuelDictionary.Keys.ToList();
            tbHotDogCost.Text = costsArray[0].ToString();
            tbHamburgerCost.Text = costsArray[1].ToString();
            tbFriesCost.Text = costsArray[2].ToString();
            tbCocaColaCost.Text = costsArray[3].ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double cost;
            fuelDictionary.TryGetValue(comboBox1.Text, out cost);
            textBox1.Text = cost.ToString();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "0";
            if ((sender as RadioButton).Name=="rbCount")
            {
                label4.Text = "грн.";
                groupBox3.Text = "До сплати";
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                FuelCalc();
            }
            else
            {
                label4.Text = "л.";
                groupBox3.Text = "До видачі";
                textBox2.Enabled = false;
                textBox3.Enabled = true;
                FuelCalc();
            }
        }

        private void textBoxDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void textBoxFuelCount_TextChanged(object sender, EventArgs e)
        {
            FuelCalc();
        }


        private void FuelCalc()
        {
            if(rbCount.Checked)
            {
                if (textBox2.Text != "")
                {
                    label3.Text = (Double.Parse(textBox1.Text) * Double.Parse(textBox2.Text)).ToString();
                }
            }
            else
            {
                if (textBox3.Text != "")
                {
                    label3.Text = (Double.Parse(textBox3.Text) / Double.Parse(textBox1.Text)).ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbCount.Checked)
            {
                label10.Text = (Double.Parse(label3.Text) + Double.Parse(label6.Text)).ToString();
            }
            else
            {
                label10.Text = (Double.Parse(label3.Text) * Double.Parse(textBox1.Text) + Double.Parse(label6.Text)).ToString();
            }
            label12.Text = (Double.Parse(label12.Text) + Double.Parse(label10.Text)).ToString();
            timer1.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbHotDogCount.Enabled = !tbHotDogCount.Enabled;
            FoodCalc();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            tbHamburgerCount.Enabled = !tbHamburgerCount.Enabled;
            FoodCalc();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            tbFriesCount.Enabled = !tbFriesCount.Enabled;
            FoodCalc();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            tbCocaColaCount.Enabled = !tbCocaColaCount.Enabled;
            FoodCalc();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Очистить форму?", "Следующий клиент?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            timer1.Stop();
            switch (result)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    ResetComponents();
                    break;
                case DialogResult.No:
                    timer1.Start();
                    break;
                default:
                    break;
            }
        }
        
        private void ResetComponents()
        {
            rbCount.Checked = true;
            textBox2.Text = "";
            textBox3.Text = "";
            tbHotDogCount.Text = "";
            tbHamburgerCount.Text = "";
            tbFriesCount.Text = "";
            tbCocaColaCount.Text = "";
            label3.Text = "0";
            label6.Text = "0";
            label10.Text = "0";
            cbHotDog.Checked = false;
            cbHamburger.Checked = false;
            cbFries.Checked = false;
            cbCocaCola.Checked = false;
        }

        private void textBoxFoodCount_TextChanged(object sender, EventArgs e)
        {
            FoodCalc();
        }

        private void FoodCalc()
        {
            label6.Text = "0";
            if (cbHotDog.Checked)
            {
                if (tbHotDogCount.Text != "")
                {
                    label6.Text = (Double.Parse(label6.Text) + Double.Parse(tbHotDogCost.Text) * Double.Parse(tbHotDogCount.Text)).ToString();
                }
            }
            if (cbHamburger.Checked)
            {
                if (tbHamburgerCount.Text != "")
                {
                    label6.Text = (Double.Parse(label6.Text) + Double.Parse(tbHamburgerCost.Text) / Double.Parse(tbHamburgerCount.Text)).ToString();
                }
            }
            if (cbFries.Checked)
            {
                if (tbFriesCount.Text != "")
                {
                    label6.Text = (Double.Parse(label6.Text) + Double.Parse(tbFriesCost.Text) / Double.Parse(tbFriesCount.Text)).ToString();
                }
            }
            if (cbCocaCola.Checked)
            {
                if (tbCocaColaCount.Text != "")
                {
                    label6.Text = (Double.Parse(label6.Text) + Double.Parse(tbCocaColaCost.Text) / Double.Parse(tbCocaColaCount.Text)).ToString();
                }
            }
        }
    }
}
