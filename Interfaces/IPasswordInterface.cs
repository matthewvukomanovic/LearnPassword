using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learn_Password.Interfaces
{
    public interface IPasswordInterface
    {
        string Password { get; set; }
        char PasswordChar { get; set; }
        string Prompt { get; set; }
        string Title { get; set; }

        void Deploy(IUIHandler handler);

        void HideUI();
        void ShowUI();

        void TimerStop();
        void TimerStart();
        void TimerSetInterval(TimeSpan interval);
    }
}
