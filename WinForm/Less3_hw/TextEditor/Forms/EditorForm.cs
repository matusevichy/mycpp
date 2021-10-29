using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.Forms
{
    public partial class EditorForm : Form
    {
        public event Action<string> EditText;
        public EditorForm()
        {
            InitializeComponent();
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            tbFileText.Text = ((MainForm)this.Owner).FileText;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EditText?.Invoke(tbFileText.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbFileText.Text = ((MainForm)this.Owner).FileText;
        }
    }
}
