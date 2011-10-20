using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Learn_Password.Interfaces;
using Learn_Password.Implementations;

namespace Learn_Password
{
    public partial class LearnPassword : Form, IPasswordInterface
    {
        public LearnPassword()
        {
            InitializeComponent();
            MyInit();
        }

        #region Members

        private bool ActuallyClose = false;

        private IUIHandler CurrentHandler = null;

        #endregion

        #region Initialisation

        public void MyInit()
        {
            this.Icon = new Icon(this.GetType().Assembly.GetManifestResourceStream("Learn_Password.App.ico"));
            this.fniIcon.Icon = new Icon(this.GetType().Assembly.GetManifestResourceStream("Learn_Password.App.ico"));
            this.ftimTimer.Interval = (int)(new TimeSpan(0, 1, 0, 0, 0)).TotalMilliseconds;

            MenuItem[] menuItems = new MenuItem[3];
            menuItems[2] = new MenuItem("Exit", new EventHandler(this.ExitSelected));
            menuItems[2].DefaultItem = true;
            menuItems[1] = new MenuItem("Stop Timer", new EventHandler(this.StopSelected));
            menuItems[0] = new MenuItem("Start Timer", new EventHandler(this.StartSelected));

            ContextMenu notifyiconMenu = new ContextMenu(menuItems);
            fniIcon.ContextMenu = notifyiconMenu;

            this.Deploy(new SetPasswordHandler());
        }


        #endregion

        #region Visibility Functions

        public void ShowUI()
        {
            if (!this.Visible)
            {
                this.Visible = true;
            }
            if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
            }
            if (!this.ShowInTaskbar)
            {
                this.ShowInTaskbar = true;
            }
            this.BringToFront();
            TimerStop();
        }

        public void HideUI()
        {
            if (this.Visible)
            {
                this.Visible = false;
            }
            if (this.ShowInTaskbar)
            {
                this.ShowInTaskbar = false;
            }
            TimerStart();
        }

        public void ToggleMe()
        {
            if (this.Visible)
            {
                this.HideUI();
            }
            else
            {
                this.ShowUI();
            }
        }

        private void fniIcon_OnClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.ToggleMe();
            }
        }


        #endregion

        #region Timer Functions

        public void TimerStart()
        {
            if (!this.ftimTimer.Enabled)
            {
                this.ftimTimer.Start();
            }
        }

        public void TimerStop()
        {
            if (this.ftimTimer.Enabled)
            {
                this.ftimTimer.Stop();
            }
        }

        public void TimerSetInterval(TimeSpan interval)
        {
            this.ftimTimer.Interval = (int)interval.TotalMilliseconds;
        }

        #endregion

        #region Menu Handlers

        private void ExitSelected(object sender, System.EventArgs e)
        {
            this.ActuallyClose = true;
            this.Close();
        }

        private void StopSelected(object sender, System.EventArgs e)
        {
            this.TimerStop();
        }

        private void StartSelected(object sender, System.EventArgs e)
        {
            this.TimerStart();
        }

        #endregion

        #region Closing Functions

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!this.ActuallyClose)
            {
                e.Cancel = true;
                HideUI();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Password Functions

        #endregion

        #region IPasswordInterface Members

        public string Password
        {
            get
            {
                return this.tbOriginalPassword.Text;
            }
            set
            {
                this.tbOriginalPassword.Text = value;
            }
        }

        public char PasswordChar
        {
            get
            {
                return this.tbOriginalPassword.PasswordChar;
            }
            set
            {
                this.tbOriginalPassword.PasswordChar = value;
            }
        }

        public string Prompt
        {
            get
            {
                return this.btnSet.Text;
            }
            set
            {
                this.btnSet.Text = value;
            }
        }

        public void Deploy(IUIHandler handler)
        {
            IUIHandler previous = CurrentHandler;
            if (handler != null)
            {
                handler.Deploy(this, previous);
            }

            CurrentHandler = handler;

            if (previous != null)
            {
                previous.Dismissed(this, handler);
            }

            if (handler != null)
            {
                handler.Deployed(this, previous);
            }
        }

        private void RunProcessValue()
        {
            IUIHandler handler = CurrentHandler;
            if (handler != null)
            {
                handler.ProcessValue(this, Password);
            }
            else
            {
                MessageBox.Show("handler null, tell someone");
            }
        }

        #endregion

        #region Interface Handlers

        private void btnSet_Click(object sender, EventArgs e)
        {
            RunProcessValue();
        }

        private void tbOriginalPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RunProcessValue();
            }
        }

        private void fniIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.ToggleMe();
            }
        }

        private void ftimTimer_Tick(object sender, EventArgs e)
        {
            this.ftimTimer.Stop();
            ShowUI();
        }

        #endregion
    }
}
