using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeySprite
{
    class InvokeHelper
    {
        private Control ctrl;

        public static readonly InvokeHelper Instance = new InvokeHelper();
        public void SetControl(Control c)
        {
            this.ctrl = c;
        }

        public void Invoke(Action action)
        {
            this.ctrl.Invoke(action);
        }
    }
}
