namespace Less2_cw
{
    public partial class Form1 : Form
    {
        MailClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            if (tbHost.Text.Length != 0 && tbUser.Text.Length != 0 && tbPassword.Text.Length != 0)
            {
                client = new MailClient(tbHost.Text, tbUser.Text, tbPassword.Text);
                if (tbLog.DataBindings.Count==0)
                {
                    tbLog.DataBindings.Add("Text", client, "Log");
                }
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("All fields are required!","Warning");
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            await Task.Run(async () =>
                {
                    await client.Connect();
                    BeginInvoke(async () =>  await client.GetMessagesList());
                    if (dgvMessages.DataSource == null)
                    {
                        dgvMessages.Invoke(() =>
                        {
                            BindingSource binding = new BindingSource();
                            binding.SuspendBinding();
                            binding.DataSource = client.messages;
                            binding.ResumeBinding();

                            dgvMessages.DataSource = binding;
                        });
                    }
                });
        }

        private void dgvMessages_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMessages.CurrentRow != null)
            {
                var current = (Message)dgvMessages.CurrentRow.DataBoundItem;
                tbMessage.Text = current.Body;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (tbFrom.Text.Length!=0 && tbTo.Text.Length !=0)
            {
                await client.SendMessage(tbFrom.Text, tbTo.Text, tbSubject.Text, tbBody.Text);
            }
            else
            {
                MessageBox.Show("Marked * fields are required!", "Warning");
            }
        }

        private void tbLog_TextChanged(object sender, EventArgs e)
        {
            tbLog.SelectionStart = tbLog.Text.Length;
            tbLog.ScrollToCaret();
        }
    }
}