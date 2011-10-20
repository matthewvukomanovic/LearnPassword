using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomLibrary.Forms;

namespace Learn_Password.Implementations
{
    class TestPasswordHandler : UIHandlerBase
    {

        #region SuccessfulCount

        private int _successfulCount = 0;

        public int SuccessfulCount
        {
            get { return _successfulCount; }
            set { _successfulCount = value; }
        }

        #endregion


        #region StoredPassword

        private string _storedPassword;

        public string StoredPassword
        {
            get { return _storedPassword; }
            set
            {
                _storedPassword = Encryption.Encrypt(value);
            }
        }

        #endregion

        public TestPasswordHandler()
        {
            StoredPassword = null;
        }

        public TestPasswordHandler(string initialPasswordValue)
        {
            StoredPassword = initialPasswordValue;
        }

        public override void Deploy(Interfaces.IPasswordInterface ui, Interfaces.IUIHandler current)
        {
            base.Deploy(ui, current);

            ui.Password = string.Empty;
            ui.PasswordChar = '*';
            ui.Prompt = "Test Password";
            ui.HideUI();
            CheckChangeIntervalCount(ui);
        }

        public override void ProcessValue(Interfaces.IPasswordInterface ui, string value)
        {
            string passwordText = value;
            if (passwordText.Length == 0)
            {
                TextDisplay.ShowDialog("Password Entered Is Blank");
            }
            else
            {
                if (passwordText == Encryption.Decrypt(StoredPassword))
                {
                    ui.Password = null;
                    ui.HideUI();
                    SuccessfulCount = SuccessfulCount+1;
                }
                else
                {
                    SuccessfulCount = 0;
                    TextDisplay.ShowDialog("Password Entered Is Not The Same Password");
                }
                
            }
        }

        private void CheckChangeIntervalCount(Interfaces.IPasswordInterface ui)
        {
            switch (SuccessfulCount)
            {
                case 0: // First time through to 30 minutes
                    ui.TimerSetInterval(new TimeSpan(0, 5, 0));
                    ui.TimerStart();
                    break;
                case 6: // 30 minutes though to an hour
                    ui.TimerSetInterval(new TimeSpan(0, 10, 0));
                    ui.TimerStart();
                    break;
                case 9: // hour through to 2 hours
                    ui.TimerSetInterval(new TimeSpan(0, 30, 0));
                    ui.TimerStart();
                    break;
                case 11: // 2 hours onwards
                    ui.TimerSetInterval(new TimeSpan(1, 0, 0));
                    ui.TimerStart();
                    break;
            }
        }
    }
}
