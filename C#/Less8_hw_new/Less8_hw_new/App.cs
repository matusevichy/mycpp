using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Less8_hw_new
{
    class App
    {
        private System.Timers.Timer timer;
        private System.Timers.Timer timer2;
        public Tamagochi tamagochi;
        public App(int lifeTime)
        {
            tamagochi = new Tamagochi(lifeTime);
            timer = new System.Timers.Timer { Interval = 1000 };
            timer2 = new System.Timers.Timer { Interval = 5000 };
        }
        public void Start()
        {
            timer.Elapsed += Timer_Tick;
            timer2.Elapsed += Timer2_Tick;
            Tamagochi.Action action = (Tamagochi.Action)Enum.GetValues(typeof(Tamagochi.Action)).GetValue(0);
            timer.Start();
            timer2.Start();
            ;
        }

        private void Timer2_Tick(object sender, ElapsedEventArgs e)
        {
            tamagochi.Die();
        }

        private void Timer_Tick(object sender, ElapsedEventArgs e)
        {
            Tamagochi.Action action;
            action = tamagochi.Require(tamagochi.LastAction);
            tamagochi.Show(action);
            timer.Stop();
            timer2.Stop();
            var result = MessageBox.Show($"I want {action.ToString()}", "Tamagochi say", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            switch (result)
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    return;
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    if (action==Tamagochi.Action.Cure)
                    {
                        tamagochi.FailCount = 0;
                    }
                    timer.Start();
                    timer2.Start();
                    break;
                case DialogResult.No:
                    tamagochi.FailCount++;
                    timer.Start();
                    timer2.Start();
                    break;
            }
            if (tamagochi.FailCount == 3)
            {
                tamagochi.Die();
            }
        }
    }
}
