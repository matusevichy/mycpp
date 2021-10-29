using CompShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompShop.Forms
{
    public partial class ProductsForm : Form
    {
        List<Product> products = new List<Product>();
        public ProductsForm()
        {
            InitializeComponent();
            var tmp = this.Owner;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            var tmp = (Form1)this.Owner;
            products = tmp.products;
            lbProducts.DataSource = products;
            tbName.DataBindings.Add(new Binding("Text", products, "Name",false,DataSourceUpdateMode.OnPropertyChanged));
            tbDescr.DataBindings.Add(new Binding("Text", products, "Description"));
            tbCharact.DataBindings.Add(new Binding("Text", products, "Characteristics"));
            numUpDown.DataBindings.Add(new Binding("Value", products, "Price"));
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            //lbProducts.ClearSelected();
            products.Add(new Product { Characteristics = "", Description = "", Name = "", Price = 0 });
            ValueChanged(sender, e);
            lbProducts.SelectedIndex = products.Count - 1;
        }

        private void lbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var tmp = (Product)lbProducts.SelectedItem;
            //if (tmp != null)
            //{
            //    tbName.Text = tmp.Name;
            //    tbDescr.Text = tmp.Description;
            //    tbCharact.Text = tmp.Characteristics;
            //    numUpDown.Value = (decimal)tmp.Price;
            //}
            //else
            //{
            //    tbName.Text = "";
            //    tbDescr.Text = "";
            //    tbCharact.Text = "";
            //    numUpDown.Value = 0;
            //}
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            lbProducts.DataSource = null;
            lbProducts.DataSource = products;
        }

        private void tbName_BindingContextChanged(object sender, EventArgs e)
        {
        }

        private void ProductsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
