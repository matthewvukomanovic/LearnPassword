﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomLibrary.Forms;
using Learn_Password.Interfaces;

namespace Learn_Password.Implementations
{
    public class SetPasswordHandler : UIHandlerBase
    {
        public override void Deploy(Interfaces.IPasswordInterface ui, Interfaces.IUIHandler current)
        {
            base.Deploy(ui, current);

            ui.Password = "Enter Password";
            ui.PasswordChar = (char)'\0';
            ui.Prompt = "Set Password";
        }

        public override void ProcessValue(IPasswordInterface ui, string value)
        {
            string passwordText = value;
            if (passwordText.Length == 0)
            {
                TextDisplay.ShowDialog("Password is not there");
            }
            else
            {
                ui.HideUI();
                ui.Deploy(new TestPasswordHandler(value));
            }
        }
    }
}
