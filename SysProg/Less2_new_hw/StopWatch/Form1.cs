namespace StopWatch
{
    public partial class Form1 : Form
    {
        TimeSpan time = new TimeSpan();
        int success = 0;
        int unsuccess = 0;
        bool isTimerStarted = false;
        public Form1()
        {
            InitializeComponent();
            ShowResult();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled == false) timer1.Enabled = true;
            timer1.Start();
            isTimerStarted=true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time += new TimeSpan(0, 0, 0, 0, 100);
            ShowTime();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (isTimerStarted)
            {
                timer1.Stop();
                isTimerStarted=false;
                switch (time.Milliseconds)
                {
                    case 0:
                        success++;
                        break;
                    default:
                        unsuccess++;
                        break;
                }
                ShowResult();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            time = TimeSpan.Zero;
            success = 0;
            unsuccess = 0;
            ShowTime();
            ShowResult();
        }

        void ShowTime()
        {
            lbTime.Text = time.ToString(@"m\:ss\.f");
        }

        void ShowResult()
        {
            lbCounter.Text = $"{success}/{unsuccess}";
        }
    }
}