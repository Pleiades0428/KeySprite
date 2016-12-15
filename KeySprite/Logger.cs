using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeySprite
{
    class Logger
    {
        private TextBox tbLog;

        public Logger(TextBox tb)
        {
            this.tbLog = tb;
        }

        public void Log(string log)
        {
            tbLog.Invoke(new Action(() =>
            {
                tbLog.AppendText("\r\n" + log);
            }));
        }
    }
}
