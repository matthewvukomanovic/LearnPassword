namespace Learn_Password
{
    partial class LearnPassword
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
            this.fniIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ftimTimer = new System.Windows.Forms.Timer(this.components);
            this.controlUseValue = new System.Windows.Forms.Button();
            this.controlPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fniIcon
            // 
            this.fniIcon.Text = "Learn Password";
            this.fniIcon.Visible = true;
            this.fniIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fniIcon_MouseClick);
            // 
            // ftimTimer
            // 
            this.ftimTimer.Tick += new System.EventHandler(this.ftimTimer_Tick);
            // 
            // controlUseValue
            // 
            this.controlUseValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlUseValue.Location = new System.Drawing.Point(243, 8);
            this.controlUseValue.Name = "controlUseValue";
            this.controlUseValue.Size = new System.Drawing.Size(96, 24);
            this.controlUseValue.TabIndex = 6;
            this.controlUseValue.Text = "Set Password";
            this.controlUseValue.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // controlPassword
            // 
            this.controlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPassword.Location = new System.Drawing.Point(11, 8);
            this.controlPassword.Name = "controlPassword";
            this.controlPassword.Size = new System.Drawing.Size(224, 20);
            this.controlPassword.TabIndex = 5;
            this.controlPassword.Text = "Enter Password";
            this.controlPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbOriginalPassword_KeyUp);
            // 
            // LearnPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 37);
            this.Controls.Add(this.controlUseValue);
            this.Controls.Add(this.controlPassword);
            this.Name = "LearnPassword";
            this.Text = "Learn Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon fniIcon;
        private System.Windows.Forms.Timer ftimTimer;
        private System.Windows.Forms.Button controlUseValue;
        private System.Windows.Forms.TextBox controlPassword;
    }
}