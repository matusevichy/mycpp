using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Less3_hw.Forms
{
    public partial class FindForm : Form
    {
        public event Action<string[]> FilesList;
        public FindForm()
        {
            InitializeComponent();
        }

        private void FindForm_Load(object sender, EventArgs e)
        {
            lbPathFolder.Text = Directory.GetCurrentDirectory();
            tbFindMask.Text = "*.*";
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                SelectedPath = lbPathFolder.Text
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lbPathFolder.Text = dlg.SelectedPath;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var list = Directory.GetFiles(lbPathFolder.Text, tbFindMask.Text);
            FilesList?.Invoke(list);
          
        }
    }
}
