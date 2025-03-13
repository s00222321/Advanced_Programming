namespace APLab2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtNumber = new TextBox();
            button = new Button();
            lbSum = new ListBox();
            lblError = new Label();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(107, 66);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 0;
            label1.Text = "Please input a number";
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(107, 130);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(213, 27);
            txtNumber.TabIndex = 1;
            // 
            // button
            // 
            button.Location = new Point(115, 203);
            button.Name = "button";
            button.Size = new Size(167, 32);
            button.TabIndex = 2;
            button.Text = "Calculate Sum";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // lbSum
            // 
            lbSum.FormattingEnabled = true;
            lbSum.Location = new Point(469, 46);
            lbSum.Name = "lbSum";
            lbSum.Size = new Size(240, 324);
            lbSum.TabIndex = 3;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(115, 298);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 4;
            // 
            // backgroundWorker
            // 
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblError);
            Controls.Add(lbSum);
            Controls.Add(button);
            Controls.Add(txtNumber);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNumber;
        private Button button;
        private ListBox lbSum;
        private Label lblError;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}
