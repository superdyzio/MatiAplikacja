using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatiAplikacja
{
    public partial class MatiForm : Form
    {
        private Boolean run;
        private Boolean finished;
        private int seconds;
        private const int maxTime = 30;
        // one year = 31 556 926 seconds

        public MatiForm()
        {
            InitializeComponent();

            run = false;
            finished = false;
            seconds = maxTime;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (run)
            {
                seconds--;
                if (seconds == 0)
                {
                    run = false;
                    finished = true;
                }
                progressBarTimeElapsed.Value = (seconds / maxTime);
            }
            if (finished)
            {
                // TODO: popup
                timer.Stop();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!finished)
            {
                run = true;
                timer.Start();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (!finished)
            {
                run = false;
                timer.Stop();
                seconds = maxTime;
            }
            else
            {
                // TODO: ask if proceed
            }
        }
    }
}
