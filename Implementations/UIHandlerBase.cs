using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Learn_Password.Interfaces;

namespace Learn_Password.Implementations
{
    public class UIHandlerBase : IUIHandler
    {
        #region IUIHandler Members

        public virtual void ProcessValue(IPasswordInterface ui, string value)
        {
            throw new NotImplementedException();
        }

        public virtual bool CanTimerRun
        {
            get { return false; }
        }

        public virtual bool HideText
        {
            get { return false; }
        }

        public virtual void Deployed(IPasswordInterface ui, IUIHandler previous)
        {
            if (previous != null)
            {
                previous.Dismissed(ui, this);
            }
        }

        public virtual void Deploy(IPasswordInterface ui, IUIHandler current)
        {

        }

        public virtual void Dismissed(IPasswordInterface ui, IUIHandler next)
        {

        }

        #endregion
    }
}
