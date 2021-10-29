using CompShop.Forms;
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

namespace CompShop
{
    public partial class Form1 : Form
    {
        public List<Product> products = new List<Product>();
        public List<Product> sales = new List<Product>();
        public Form1()
        {
            InitializeComponent();
            Init();
            lbSaleList.DataSource = sales;
            cbProductsList.DisplayMember = "Name";
            cbProductsList.DataSource = products;
        }

        private void Init()
        {
            products.Add(new Product { Name = "Product 1", Description = "Description 1", Characteristics = "Char 1", Price = 10 });
            products.Add(new Product { Name = "Product 2", Description = "Description 2", Characteristics = "Char 2", Price = 20 });
            products.Add(new Product { Name = "Product 3", Description = "Description 3", Characteristics = "Char 3", Price = 30 });
            products.Add(new Product { Name = "Product 4", Description = "Description 4", Characteristics = "Char 4", Price = 40 });
            products.Add(new Product { Name = "Product 5", Description = "Description 5", Characteristics = "Char 5", Price = 50 });
            products.Add(new Product { Name = "Product 6", Description = "Description 6", Characteristics = "Char 6", Price = 60 });
            products.Add(new Product { Name = "Product 7", Description = "Description 7", Characteristics = "Char 7", Price = 70 });
            products.Add(new Product { Name = "Product 8", Description = "Description 8", Characteristics = "Char 8", Price = 80 });
            products.Add(new Product { Name = "Product 9", Description = "Description 9", Characteristics = "Char 9", Price = 90 });
        }
        private void btnAddToList_Click(object sender, EventArgs e)
        {
            sales.Add((Product)cbProductsList.SelectedItem);
            UpdateSaleList();
            ChangeFullPrice();
        }
        private void ChangeFullPrice()
        {
            var tmp = sales.Sum(s => s.Price);
            lbFullPrice.Text = tmp.ToString();
        }
        private void UpdateSaleList()
        {
            lbSaleList.DataSource = null;
            lbSaleList.DataSource = sales;
        }
        private void UpdateProductList()
        {
            cbProductsList.DataSource = null;
            cbProductsList.DataSource = products;
        }

        private void cbProductsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProductsList.SelectedItem != null)
            {
                var tmp = (Product)cbProductsList.SelectedItem;
                tbPrice.Text = tmp.Price.ToString() ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductsForm form = new ProductsForm
            {
                StartPosition = FormStartPosition.CenterParent,
                Owner = this
            };
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateProductList();
                UpdateSaleList();
                ChangeFullPrice();
            }
        }
    }
}