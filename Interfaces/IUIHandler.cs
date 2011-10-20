using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learn_Password.Interfaces
{
    public interface IUIHandler
    {
        void ProcessValue(IPasswordInterface ui, string value);
        bool CanTimerRun{get;}
        bool HideText { get; }
        void Deployed(IPasswordInterface ui, IUIHandler previous);
        void Deploy(IPasswordInterface ui, IUIHandler current);
        void Dismissed(IPasswordInterface ui, IUIHandler next);
    }
}
