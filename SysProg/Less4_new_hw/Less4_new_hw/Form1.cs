using System.Text;
using System.Text.RegularExpressions;

namespace Less4_new_hw
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken token;

        Dictionary<string, string> report;

        bool isStarted = false;
        public Form1()
        {
            InitializeComponent();
            token = cancellationTokenSource.Token;
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            if (tbText.Text!="")
            {
                btnStart.Enabled = true;
            }
            else
            {
                btnStart.Enabled=false;
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                isStarted = true;
                btnStart.Text = "Stop";
                btnViewReport.Enabled = false;
                btnSaveReport.Enabled = false;
                string text = tbText.Text;

                report = new Dictionary<string, string>();

                Task.Run(async () =>
                {
                    await Analise(text);
                    if (report.Count > 0)
                    {
                        BeginInvoke(() =>
                        {
                            btnViewReport.Enabled = true;
                            btnSaveReport.Enabled = true;
                        });
                    }
                    BeginInvoke(() =>
                    {
                        btnStart.Text = "Start";
                        isStarted = false;
                    });
                },token);
            }
            else
            {
                isStarted=false;
                cancellationTokenSource.Cancel();
                btnStart.Text = "Start";
            }
            ;
        }

        async Task Analise(string text)
        {
            report.Clear();
            string exp = @"(\S[,&\w\s]+[.;!?])";
            Regex regex = new Regex(exp);
            var res = regex.Matches(text).ToList();
            report.Add("Sentences", "Count of the sentences: " + res.Count());
            report.Add("Characters", "Count of the characters: " + text.Count(char.IsLetterOrDigit));

            exp = @"\s*\w+";
            regex = new Regex(exp);
            var res1 = regex.Matches(text).ToList();
            report.Add("Words", "Count of the words: " + res1.Count());
            report.Add("Questions", "Count of the question sentences: " + res.Where(m => m.Value.EndsWith('?')).Count());
            report.Add("Exclamatories", "Count of the exclamatory sentences: " + res.Where(m => m.Value.EndsWith('!')).Count());
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetReport());
        }

        string GetReport()
        {
            string result = string.Empty;
            if (cbSentences.Checked)
            {
                result += report.GetValueOrDefault("Sentences") + Environment.NewLine;
            }
            if (cbCharacters.Checked)
            {
                result += report.GetValueOrDefault("Characters") + Environment.NewLine;
            }
            if (cbWords.Checked)
            {
                result += report.GetValueOrDefault("Words") + Environment.NewLine;
            }
            if (cbQuestionSentences.Checked)
            {
                result += report.GetValueOrDefault("Questions") + Environment.NewLine;
            }
            if (cbExclamatorySentences.Checked)
            {
                result += report.GetValueOrDefault("Exclamatories") + Environment.NewLine;
            }
            return result;
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Title = "Save report as...";
            dlg.Filter = "*.txt|*.txt";
            dlg.FileName = "report.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write))
                {
                    var rep = GetReport();
                    stream.Write(Encoding.ASCII.GetBytes(rep), 0, rep.Length);
                }
            }
        }
    }
}