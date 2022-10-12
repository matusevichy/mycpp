using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class SaleInfoForm : Form
    {
        SaleService saleService = new SaleService();
        List<SaleDTO> sales = new List<SaleDTO>();
        public SaleInfoForm()
        {
            InitializeComponent();
            var sales = saleService.GetAll();
            lbSales.DataSource = sales;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
