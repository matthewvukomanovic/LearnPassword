using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CustomLibrary.Forms;

namespace Learn_Password
{

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class LearnPassword : System.Windows.Forms.Form
	{
		private System.Windows.Forms.NotifyIcon fniIcon;
		private System.Windows.Forms.Timer ftimTimer;
		private System.Windows.Forms.TextBox tbOriginalPassword;
		private System.Windows.Forms.Button btnSet;
		private System.Windows.Forms.TextBox tbTime;
		private System.Windows.Forms.TextBox tbTestPassword;
		private System.Windows.Forms.Button btnTest;
		private System.ComponentModel.IContainer components;

		public LearnPassword()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			myInit();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
			this.tbOriginalPassword = new System.Windows.Forms.TextBox();
			this.btnSet = new System.Windows.Forms.Button();
			this.tbTime = new System.Windows.Forms.TextBox();
			this.tbTestPassword = new System.Windows.Forms.TextBox();
			this.btnTest = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// fniIcon
			// 
			this.fniIcon.Text = "Learn Password";
			this.fniIcon.Visible = true;
			this.fniIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fniIcon_OnClick);
			// 
			// ftimTimer
			// 
			this.ftimTimer.Tick += new System.EventHandler(this.Timer_Ticked);
			// 
			// tbOriginalPassword
			// 
			this.tbOriginalPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbOriginalPassword.Location = new System.Drawing.Point(8, 8);
			this.tbOriginalPassword.Name = "tbOriginalPassword";
			this.tbOriginalPassword.Size = new System.Drawing.Size(224, 20);
			this.tbOriginalPassword.TabIndex = 0;
			this.tbOriginalPassword.Text = "Enter Password";
			this.tbOriginalPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp_Set);
			// 
			// btnSet
			// 
			this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSet.Location = new System.Drawing.Point(240, 8);
			this.btnSet.Name = "btnSet";
			this.btnSet.Size = new System.Drawing.Size(96, 24);
			this.btnSet.TabIndex = 1;
			this.btnSet.Text = "Set Password";
			this.btnSet.Click += new System.EventHandler(this.Set_Password);
			// 
			// tbTime
			// 
			this.tbTime.Location = new System.Drawing.Point(8, 72);
			this.tbTime.Name = "tbTime";
			this.tbTime.TabIndex = 2;
			this.tbTime.Text = "tbTime";
			this.tbTime.Visible = false;
			// 
			// tbTestPassword
			// 
			this.tbTestPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbTestPassword.Location = new System.Drawing.Point(8, 8);
			this.tbTestPassword.Name = "tbTestPassword";
			this.tbTestPassword.PasswordChar = '*';
			this.tbTestPassword.Size = new System.Drawing.Size(224, 20);
			this.tbTestPassword.TabIndex = 3;
			this.tbTestPassword.Text = "";
			this.tbTestPassword.Visible = false;
			this.tbTestPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp_Test);
			// 
			// btnTest
			// 
			this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTest.Enabled = false;
			this.btnTest.Location = new System.Drawing.Point(240, 8);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(96, 24);
			this.btnTest.TabIndex = 4;
			this.btnTest.Text = "Test Password";
			this.btnTest.Visible = false;
			this.btnTest.Click += new System.EventHandler(this.Test_Password);
			// 
			// LearnPassword
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 37);
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.tbTestPassword);
			this.Controls.Add(this.tbTime);
			this.Controls.Add(this.btnSet);
			this.Controls.Add(this.tbOriginalPassword);
			this.Name = "LearnPassword";
			this.Text = "Learn Password";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Before_Close);
			this.Closed += new System.EventHandler(this.After_Close);
			this.ResumeLayout(false);

		}


		#endregion

		#region Variable And Declaration

		private bool actuallyClose = false;
		private string passwordSet = "";

		#endregion

		#region Initialisation

		public void myInit()
		{
			this.Icon = new Icon( this.GetType().Assembly.GetManifestResourceStream( "Learn_Password.App.ico"));
			this.fniIcon.Icon = new Icon( this.GetType().Assembly.GetManifestResourceStream( "Learn_Password.App.ico"));
			this.ftimTimer.Interval = (int)(new TimeSpan(0,1,0,0,0)).TotalMilliseconds;
//			this.ftimTimer.Interval = (int)(new TimeSpan(0,0,0,5,0)).TotalMilliseconds;

			MenuItem[] menuItems = new MenuItem[3];
			menuItems[2] = new MenuItem( "Exit", new EventHandler( this.ExitSelected));
			menuItems[2].DefaultItem = true;
			menuItems[1] = new MenuItem( "Stop Timer", new EventHandler( this.StopSelected));
			menuItems[0] = new MenuItem( "Start Timer", new EventHandler( this.StartSelected));
			//menuItems[0].Visible = false;

			ContextMenu notifyiconMenu = new ContextMenu( menuItems);
			fniIcon.ContextMenu = notifyiconMenu;
		}


		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			LearnPassword window = new LearnPassword();
			window.Show();
			Application.Run();
		}


		#region Visibility Functions

		public void ShowMe()
		{
			if( !this.Visible)
			{
				this.Visible = true;
			}
			if( this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
			{
			}
			if( !this.ShowInTaskbar)
			{
				this.ShowInTaskbar = true;
			}
			this.BringToFront();
			StopTimer();
		}


		public void HideMe()
		{
			if( this.Visible)
			{
				this.Visible = false;
			}
			if( this.ShowInTaskbar)
			{
				this.ShowInTaskbar = false;
			}
			StartTimer();
		}


		public void ToggleMe()
		{
			if( this.Visible)
			{
				this.HideMe();
			}
			else
			{
				this.ShowMe();
			}
		}


		private void fniIcon_OnClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( e.Button == MouseButtons.Left)
			{
				this.ToggleMe();
			}
		}


		#endregion

		#region Closing Functions

		private void ExitSelected(object sender, System.EventArgs e)
		{
			this.actuallyClose = true;
			this.Close();
		}


		private void Before_Close(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if( !this.actuallyClose)
			{
				e.Cancel = true;
				HideMe();
			}
		}
		

		private void After_Close(object sender, System.EventArgs e)
		{
			Application.Exit();
		}


		#endregion

		#region Timer Functions

		private void Timer_Ticked(object sender, System.EventArgs e)
		{
			this.ftimTimer.Stop();
			ShowMe();
		}


		private void StartTimer()
		{
			if( !this.ftimTimer.Enabled)
			{
				this.ftimTimer.Start();
			}
		}


		private void StopTimer()
		{
			if( this.ftimTimer.Enabled)
			{
				this.ftimTimer.Stop();
			}
		}


		#endregion

		#region Password Functions

		private void Set_Password(object sender, System.EventArgs e)
		{
			string passwordText = tbOriginalPassword.Text;
			if( passwordText.Length == 0)
			{
				TextDisplay.ShowDialog( "Password is not there");
			}
			else
			{
				this.passwordSet = Encryption.Encrypt(passwordText);
				this.tbOriginalPassword.Clear();
				btnTest.Enabled = true;
				btnTest.Visible = true;
				tbTestPassword.Visible = true;

				btnSet.Visible = false;
				tbOriginalPassword.Visible = false;

				HideMe();
			}
		}


		private void Test_Password(object sender, System.EventArgs e)
		{
			string passwordText = this.tbTestPassword.Text;
			if( passwordText.Length == 0)
			{
				TextDisplay.ShowDialog( "Password Entered Is Blank");
			}
			else
			{
				if( passwordText.CompareTo( Encryption.Decrypt(this.passwordSet)) == 0)
				{
					this.tbTestPassword.Clear();
					HideMe();
					HideMe();
				}
				else
				{
					TextDisplay.ShowDialog( "Password Entered Is Not The Same Password");
				}
			}
		
		}


		private void KeyUp_Set(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				Set_Password(sender, e);
			}		
		}

		private void KeyUp_Test(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				Test_Password(sender, e);
			}	
		}

		#endregion


		private void StopSelected(object sender, System.EventArgs e)
		{
			this.StopTimer();
		}

		private void StartSelected(object sender, System.EventArgs e)
		{
			this.StartTimer();
		}

	}
}
