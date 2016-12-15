using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KeySprite.AutoKeyTask
{
    class ResetFormsPasswordTask : AutoKeyTaskBase, IAutoKeyTask
    {
        int startNum;
        public void Init(params object[] args)
        {
            startNum = int.Parse(args[0].ToString());
        }

        public void Execute(int num, params object[] args)
        {
            DoKeyForResetPwd(num);
        }

        private void DoKeyForResetPwd(int num)
        {
            string personId = "99" + (startNum + num).ToString();
            Point ptUserFullPath = new Point(1290, 76);
            KeyService.Instance.Click(ptUserFullPath);
            Thread.Sleep(100);

            KeyService.Instance.KeyDown("Ctrl");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("A");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Ctrl");
            Thread.Sleep(500);
            KeyService.Instance.Input(personId);
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Enter");
            Thread.Sleep(3000);
            
            KeyService.Instance.KeyDown("Alt");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("M");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Alt");
            Thread.Sleep(1000);

            KeyService.Instance.KeyDown("Ctrl");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("C");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Ctrl");
            Thread.Sleep(500);
            KeyService.Instance.KeyPress("Space");
            Thread.Sleep(500);

            KeyService.Instance.KeyDown("Alt");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("E");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Alt");
            Thread.Sleep(1000);

            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(100);

            KeyService.Instance.KeyDown("Ctrl");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("End");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Ctrl");

            Thread.Sleep(500);
            KeyService.Instance.Input(personId);
            KeyService.Instance.KeyPress("Space");

            KeyService.Instance.KeyDown("Ctrl");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("V");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Ctrl");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Enter");
            Thread.Sleep(500);
        }
    }
}
