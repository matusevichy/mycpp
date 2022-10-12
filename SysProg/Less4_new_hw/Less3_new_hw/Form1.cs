using DirComp;

namespace Less3_new_hw
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken token;
        DirComparer dirComparer;
        string dirFrom="";
        string dirTo="";

        int countAll = 0;

        bool isStarted = false;
        enum States
        {
            Waiting,
            Copying,
            Success
        }

        public Form1()
        {
            InitializeComponent();
            dirComparer = new DirComp.DirComparer();
            progressBar1.DataBindings.Add("Value", dirComparer, "CountFact");
            lbState.Text = Enum.GetName(typeof(States), 0);
            token = cancellationTokenSource.Token;
        }

        private void btnSelDirFrom_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dirFrom= dialog.SelectedPath;
                tbDirFrom.Text = dirFrom;
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dirTo = dialog.SelectedPath;
                tbDirTo.Text = dirTo;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                cancellationTokenSource = new CancellationTokenSource();
                var opt = new EnumerationOptions();
                opt.RecurseSubdirectories = true;
                opt.AttributesToSkip = new FileAttributes();
                countAll = Directory.EnumerateFileSystemEntries(dirFrom, "*", opt).ToArray().Length;
                progressBar1.Maximum = countAll;
                changeUI();
                Task.Run(async () =>
                {
                    await dirComparer.Start(dirFrom, dirTo, cancellationTokenSource);
                    BeginInvoke(() => changeUI());
                });
            }
            else
            {
                changeUI();
                cancellationTokenSource.Cancel();
            }
            btnReport.Enabled = true;
            ;
        }

        private void tbDirFrom_TextChanged(object sender, EventArgs e)
        {
            if (tbDirFrom.Text != "" && tbDirTo.Text != "")
            {
                btnStartEnd.Enabled = true;
            }
            else
            {
                btnStartEnd.Enabled = false;
            }
        }

        void changeUI()
        {
            if (isStarted)
            {
                isStarted = false;
                btnStartEnd.Text = "Start";
                lbState.Text = Enum.GetName(typeof(States), 2);
            }
            else
            {
                isStarted = true;
                btnStartEnd.Text = "Stop";
                lbState.Text = Enum.GetName(typeof(States), 1);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"In source directory found {countAll} directories and files. {Environment.NewLine}In destination directory create {dirComparer.CreatedDirs} new directory, copied {dirComparer.CopiedFeles} files.");
        }
    }
}