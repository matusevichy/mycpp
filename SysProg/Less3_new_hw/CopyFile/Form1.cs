namespace CopyFile
{
    public partial class Form1 : Form
    {
        string pathFrom="";
        string pathTo="";


        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelDirFrom_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pathFrom= dialog.FileName;
                tbFileFrom.Text = pathFrom;
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = Path.GetFileName(tbFileFrom.Text);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pathTo = dialog.FileName;
                CopyFile();
            }
        }

        void CopyFile()
        {
            Task.Run(() =>
            {
                var tasks = new List<Task>();
                object locker = new object();
                using (var fromStream = new FileStream(pathFrom, FileMode.Open, FileAccess.Read))
                using (var toStream = new FileStream(pathTo, FileMode.Create, FileAccess.Write))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        tasks.Add(Task.Run(() =>
                        {
                            byte[] buffer = new byte[1024];
                            int count = 0;
                            while (true)
                            {
                                lock (locker)
                                {
                                    count = fromStream.Read(buffer, 0, buffer.Length);
                                    if (count <= 0)
                                    {
                                        break;
                                    }
                                    toStream.Write(buffer, 0, count);
                                }
                            }
                        }));
                    }
                    Task.WaitAll(tasks.ToArray());
                    MessageBox.Show("Succesfulll!");
                }
            });
        }

        private void tbDirFrom_TextChanged(object sender, EventArgs e)
        {
            if (tbFileFrom.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}