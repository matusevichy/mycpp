using Less3_hw.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Less3_hw
{
    public partial class MainForm : Form
    {
        string[] filesList;
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterParent
            };
            findForm.FilesList += (list) =>
            {
                filesList = list;
                UpdateFileList();
            };
            findForm.Show();
        }

        private void UpdateFileList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = filesList;
        }
    }
}
