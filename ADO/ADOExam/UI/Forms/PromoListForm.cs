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
    public partial class PromoListForm : Form
    {
        PromoService promoService = new PromoService();
        List<PromoDTO> promos;
        public bool isAdmin { get; set; }

        public PromoListForm()
        {
            promos = promoService.GetAll();
            InitializeComponent();
            lbPromos.DataSource = promos;
            lbPromos.DisplayMember = "Name";
            lbPromos.ValueMember = "Id";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var promo = promoService.GetById((int)lbPromos.SelectedValue);
            using (AddPromoForm addPromoForm = new AddPromoForm(promo))
            {
                addPromoForm.IsAdmin = isAdmin;
                addPromoForm.ShowDialog();
                if (isAdmin && addPromoForm.DialogResult == DialogResult.OK)
                {
                    promoService.Update(addPromoForm.Promo);
                }
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
