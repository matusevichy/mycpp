using System.Diagnostics;

namespace Less1_new_hw1
{
    public partial class Form1 : Form
    {
        List<ListViewItem> listViewItems = new List<ListViewItem>();
        public Form1()
        {
            InitializeComponent();
            System.Threading.Timer timer = new System.Threading.Timer((e) => FillList());
            Thread thread = new Thread(() => Start());
            thread.Start();
        }

        void Start()
        {
            System.Threading.Timer timer = new System.Threading.Timer((e) => FillList());
            timer.Change(0, 2000);
        }

        void FillList()
        {
            List<ListViewItem> listViewItems1 = new List<ListViewItem>();
            var processes = Process.GetProcesses();
            foreach (var item in processes)
            {
                ListViewItem listViewItem1 = new ListViewItem(item.ProcessName);
                listViewItem1.SubItems.Add(item.Id.ToString());
                listViewItem1.SubItems.Add(item.Threads.Count.ToString());
                listViewItem1.SubItems.Add(item.HandleCount.ToString());
                listViewItems1.Add(listViewItem1);
                ;
            }
            var compareList = listViewItems.Where(n => listViewItems1.Select(n1 => n1.SubItems[1].Text).Contains(n.SubItems[1].Text)).ToList();
            if (listViewItems1.Count != compareList.Count)
            {
                listViewItems=listViewItems1;
                listView1.Invoke(() => listView1.Items.Clear());
                listView1.Invoke(() => listView1.Items.AddRange(listViewItems.ToArray()));
                lbCounter.Invoke(() => lbCounter.Text = listViewItems.Count.ToString());
            }
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Kill process?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                if (listView1.SelectedItems.Count >0)
                {
                    GetSelectedProcess().Kill();
                }
            }

        }

        Process GetSelectedProcess ()
        {
            var id = listView1.SelectedItems[0].SubItems[1].Text;
            return Process.GetProcessById(int.Parse(id));
        }

        private void idleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetSelectedProcess().PriorityClass = ProcessPriorityClass.Idle;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetSelectedProcess().PriorityClass = ProcessPriorityClass.Normal;
        }

        private void highToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetSelectedProcess().PriorityClass = ProcessPriorityClass.High;
        }

        private void realTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetSelectedProcess().PriorityClass = ProcessPriorityClass.RealTime;
        }
    }
}