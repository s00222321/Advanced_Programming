using System.ComponentModel;
using System.Threading;

namespace APLab1
{
    public partial class Form1 : Form
    {
        TimeSpan timeElapsed;

        public Form1()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true; // can report progress
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //start the backgroundWorker
            backgroundWorker.RunWorkerAsync();

            //disable the button
            button1.Enabled = false;
        }


        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime begin = DateTime.Now;

            int noSeconds = 5;

            DateTime endTime = begin.AddSeconds(noSeconds); // set to noSeconds from now

            float percentComplete;

            while (DateTime.Now < endTime) // while time now is less than the end time
            {
                Thread.Sleep(500); // sleep for 1 sec to simulate some work

                timeElapsed = DateTime.Now - begin; // find out how long we've been going for

                // convert it to %   
                percentComplete = ((float)timeElapsed.TotalSeconds / (float)noSeconds) * 100;

                // Ensure the progress value does not exceed 100
                int progressValue = (int)Math.Min(Math.Round(percentComplete), 100);

                //The ReportProgress() method raises the ProgressChanged event
                //In its simplest form, the ReportProgress() method accepts one int parameter which 
                //     can have values between 0 and 100 and represents the % completed by the 
                //     background worker so far 
                // The % completed (specified as parameter in the ReportProgress() method)
                //     is returned as the ProgressPercentage property of the 
                //     ProgressChangedEventArgs.
                backgroundWorker.ReportProgress(progressValue);
            }
        }


        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //update progress bar with the % completed so far
            progressBar1.Value = e.ProgressPercentage;

            // update timer label with custom string format                             
            label1.Text = string.Format("{0:mm\\:ss}", timeElapsed);
        }


        //runs when the background worker completes its tasks
        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Background worker completed");// show messagebox when done          
        }
    }
}
