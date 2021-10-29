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
using TextEditor.Forms;

namespace TextEditor
{
    public partial class MainForm : Form
    {
        public string FileText { get; set; }
        public MainForm()
        {
            InitializeComponent();
            btnEditFile.Enabled = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileText = null;
                using (FileStream fs = new FileStream(dlg.FileName,FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
                    {
                        string line = null;
                        while ((line=reader.ReadLine())!=null)
                        {
                            FileText += line;
                        }
                    };
                }
                UpdateFileText();
                if (tbFileText.Text !="")
                {
                    btnEditFile.Enabled = true;
                }
                else
                {
                    btnEditFile.Enabled = false;
                }
            }
        }

        private void btnEditFile_Click(object sender, EventArgs e)
        {
            EditorForm editorForm = new EditorForm
            {
                Owner = this
            };
            editorForm.EditText += (text) =>
            {
                FileText = text;
                UpdateFileText();
            };
            editorForm.Show();
        }

        private void UpdateFileText()
        {
            tbFileText.Text = FileText;
        }
    }
}
