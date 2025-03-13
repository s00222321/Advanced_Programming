namespace APLab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int sum = 0;
            string strToDisplay;

            try
            {
                for (int i = 1; i <= int.Parse(txtNumber.Text); i++)
                {

                    int temp = sum;
                    sum += i;
                    strToDisplay = String.Format(" {0} + {1} = {2}", temp, i, sum);

                    this.Invoke(new MethodInvoker(delegate {
                        lbSum.Items.Add(strToDisplay);
                    }));

                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(delegate {
                    lblError.Text = ex.Message;
                }));
            }

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Background Worker completed!");
        }
    }
}
