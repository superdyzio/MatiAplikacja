using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace MatiAplikacja
{
    /// <summary>
    /// Main form class.
    /// </summary>
    public partial class MatiForm : Form
    {
        // Countdown state variables and constants.
        private Boolean run;
        private Boolean finished;
        private int currentValue;
        private const int timerInterval = 100;  // miliseconds
        private const int timerFrequency = 1000 / timerInterval;
        private const int oneYearInSeconds = 31556926;
        private const int maxTime = oneYearInSeconds * 3 * timerFrequency;

        // Dialog boxes messages (msg) and headers (h).
        private const string msg_countdownFinished = "Your countdown has finished!";
        private const string msg_resetUnfinishedCountdown = "Are you sure about restarting unfinished countdown?";
        private const string msg_resetFinishedCountdown = "Do you want to restart the countdown?";
        private const string h_countdownFinished = "Countdown ended!";
        private const string h_resetUnfinishedCountdown = "Reset?";
        private const string h_resetFinishedCountdown = "Start again?";

        /// <summary>
        /// Class constructor - initialize all variables, time not running.
        /// </summary>
        public MatiForm()
        {
            InitializeComponent();

            timer.Interval = timerInterval;
            progressBarTimeElapsed.Maximum = maxTime;
            progressBarTimeElapsed.Value = maxTime;
            run = false;
            finished = false;
            currentValue = maxTime;
            setText();
        }

        /// <summary>
        /// Timer tick event - decrements currentValue and updates view.
        /// </summary>
        /// <param name="sender">object which reported event</param>
        /// <param name="e">event arguments</param>
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
                setText();
            }
            if (finished)
            {
                timer.Stop();
                SoundPlayer endOfCountdownSound = new SoundPlayer(Path.GetDirectoryName(Application.ExecutablePath) + "\\MatiAplikacja_data\\endOfCountdown.wav");
                try
                {
                    endOfCountdownSound.Play();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                MessageBox.Show(msg_countdownFinished, h_countdownFinished);
            }
        }

        /// <summary>
        /// Method used to show remaining time in understandable form.
        /// </summary>
        private void setText()
        {
            double seconds = Math.Floor((double)currentValue / timerFrequency);
            double minutes = Math.Floor(seconds / 60);
            double hours = Math.Floor(minutes / 60);
            double days = Math.Floor(hours / 24);

            hours -= days * 24;
            minutes -= (days * 24 + hours) * 60;
            seconds -= (days * 24 * 60 + hours * 60 + minutes) * 60;

            textBoxTimeRemaining.Text = days.ToString() + "d " + hours.ToString() + "h " + minutes.ToString() + "m " + seconds.ToString() + "s";
        }

        /// <summary>
        /// Handling START button click - start or continue countdown.
        /// </summary>
        /// <param name="sender">object which reported event</param>
        /// <param name="e">event arguments</param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!finished && !run)
            {
                run = true;
                timer.Start();
                setText();
            }
        }

        /// <summary>
        /// Handling STOP button click - pause countdown.
        /// </summary>
        /// <param name="sender">object which reported event</param>
        /// <param name="e">event arguments</param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            run = false;
            timer.Stop();
            setText();
        }

        /// <summary>
        /// Handling RESET button click - return to initial state of countdown.
        /// </summary>
        /// <param name="sender">object which reported event</param>
        /// <param name="e">event arguments</param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            run = false;
            timer.Stop();
            if (!finished)
            {
                DialogResult result = MessageBox.Show(msg_resetUnfinishedCountdown, h_resetUnfinishedCountdown, MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    progressBarTimeElapsed.Value = maxTime;
                    currentValue = maxTime;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(msg_resetFinishedCountdown, h_resetFinishedCountdown, MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    progressBarTimeElapsed.Value = maxTime;
                    currentValue = maxTime;
                    finished = false;
                }
            }
            setText();
        }

        /// <summary>
        /// Closing form event - saving current countdown state to textfile.
        /// </summary>
        /// <param name="sender">object which reported event</param>
        /// <param name="e">event arguments</param>
        private void MatiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (finished)
                currentValue = maxTime;
            string miliseconds = currentValue.ToString();
            string exeFolder = Path.GetDirectoryName(Application.ExecutablePath);
            Directory.CreateDirectory(exeFolder + "\\MatiAplikacja_data");
            StreamWriter file = new StreamWriter(exeFolder + "\\MatiAplikacja_data\\value.txt");

            file.WriteLine(miliseconds);

            file.Close();
        }

        /// <summary>
        /// Loaded form event -  loading countdown state from file or staying at initial state when process fails.
        /// </summary>
        /// <param name="sender">object which reported event</param>
        /// <param name="e">event arguments</param>
        private void MatiForm_Load(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\MatiAplikacja_data\\value.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    currentValue = Int32.Parse(sr.ReadToEnd());
                    setText();
                    progressBarTimeElapsed.Value = currentValue;
                    sr.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
