namespace SecIotAgent.Forms
{
    partial class AuthServerConnectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressStatlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(36, 35);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(299, 16);
            this.progressBar1.TabIndex = 0;
            // 
            // ProgressStatlabel
            // 
            this.ProgressStatlabel.AutoSize = true;
            this.ProgressStatlabel.Location = new System.Drawing.Point(53, 71);
            this.ProgressStatlabel.Name = "ProgressStatlabel";
            this.ProgressStatlabel.Size = new System.Drawing.Size(50, 20);
            this.ProgressStatlabel.TabIndex = 1;
            this.ProgressStatlabel.Text = "label1";
            // 
            // AuthServerConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 111);
            this.Controls.Add(this.ProgressStatlabel);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuthServerConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthServerConnectForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AuthServerConnectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private ProgressBar progressBar1;
        private Label ProgressStatlabel;
    }
}