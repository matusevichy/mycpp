using System.Diagnostics;

namespace Less1_new_cw
{
    public partial class Form1 : Form
    {
        List<Process> processes;
        public Form1()
        {
            InitializeComponent();
            RefreshList();
            timer1.Enabled = true;
        }

        private void killButton_Click(object sender, EventArgs e)
        {
            var selectedProcess = processListBox1.SelectedItem as Process;
            int id = selectedProcess.Id;
            var result = MessageBox.Show("Delete process?", "Confirm");
            if (result == DialogResult.OK)
            {
                selectedProcess.Kill();
                RefreshList();
            }
        }

        void RefreshList()
        {
            if (processes == null)
            {
                processes = Process.GetProcesses().ToList();
            }
            var processes1 = Process.GetProcesses().ToList();
            if (processes.Count != processes1.Count)
            {
                processes = Process.GetProcesses().ToList();
                processListBox1.DataSource = null;
                processListBox1.DataSource = processes;
                processListBox1.DisplayMember = "ProcessName";
                processListBox1.ValueMember = "Id";
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Select executable file";
                dlg.Multiselect = false;
                dlg.Filter = "*.exe | *.exe";
                var result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Process.Start(dlg.FileName);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshList();
        }
    }
}