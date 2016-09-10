using System;
using System.IO;
using System.Windows.Forms;

namespace MatiAplikacja
{
    public partial class MatiForm : Form
    {
        private Boolean run;
        private Boolean finished;
        private int currentValue;
        private const int timerInterval = 100;  // miliseconds
        private const int timerFrequency = 1000 / timerInterval;
        private const int oneYearInSeconds = 31556926;
        private const int maxTime = oneYearInSeconds * 3 * timerFrequency;

        public MatiForm()
        {
            InitializeComponent();

            timer.Interval = timerInterval;
            progressBarTimeElapsed.Maximum = maxTime;
            progressBarTimeElapsed.Value = maxTime;
            run = false;
            finished = false;
            currentValue = maxTime;
            setText(currentValue);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (run)
            {
                currentValue--;
                if (currentValue == 0)
                {
                    run = false;
                    finished = true;
                }
                progressBarTimeElapsed.Value = currentValue;
                setText(currentValue);
            }
            if (finished)
            {
                timer.Stop();
                MessageBox.Show("MATI MATI MATI MATI MATI MATI MATI!", "MAAAATIIIII!");
            }
        }

        private void setText(int currentValue)
        {
            double seconds = Math.Floor((double)currentValue / 10);
            double minutes = Math.Floor(seconds / 60);
            double hours = Math.Floor(minutes / 60);
            double days = Math.Floor(hours / 24);

            hours -= days * 24;
            minutes -= (days * 24 + hours) * 60;
            seconds -= (days * 24 * 60 + hours * 60 + minutes) * 60;

            textBoxTimeRemaining.Text = days.ToString() + "d " + hours.ToString() + "h " + minutes.ToString() + "m " + seconds.ToString() + "s";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!finished && !run)
            {
                run = true;
                timer.Start();
                setText(currentValue);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            run = false;
            timer.Stop();
            if (!finished)
            {
                DialogResult result = MessageBox.Show("MATI MATI MATI?", "MATI?", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    progressBarTimeElapsed.Value = maxTime;
                    currentValue = maxTime;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("MATI MATI MATI MATI MATI MATI?", "MATI?", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    progressBarTimeElapsed.Value = maxTime;
                    currentValue = maxTime;
                }
            }
            setText(currentValue);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            run = false;
            timer.Stop();
            setText(currentValue);
        }

        private void MatiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string miliseconds = currentValue.ToString();
            string exeFolder = Path.GetDirectoryName(Application.ExecutablePath);
            Directory.CreateDirectory(exeFolder + "\\MatiAplikacja_data");
            StreamWriter file = new StreamWriter(exeFolder + "\\MatiAplikacja_data\\value.txt");

            file.WriteLine(miliseconds);

            file.Close();
        }

        private void MatiForm_Load(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\MatiAplikacja_data\\value.txt";
            try
            {   
                using (StreamReader sr = new StreamReader(path))
                {
                    currentValue = Int32.Parse(sr.ReadToEnd());
                    setText(currentValue);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
