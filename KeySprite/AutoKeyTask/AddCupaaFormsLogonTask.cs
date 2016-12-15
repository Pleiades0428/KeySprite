using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KeySprite.AutoKeyTask
{
    class AddCupaaFormsLogonTask : IAutoKeyTask
    {
        int startNum;
        public void Init(params object[] args)
        {
            startNum = int.Parse(args[0].ToString());
        }

        public void Execute(int num, params object[] args)
        {
            DoKeyForAddLogon(num);
        }

        private void DoKeyForAddLogon(int num)
        {
            string personId = "99" + (startNum + num).ToString();
            string path = "海关总署\\青岛海关\\黄岛海关\\执勤武警\\" + personId;
            InvokeHelper.Instance.Invoke(new Action(() =>
            {
                Clipboard.SetText(path);
            }));
            Point ptUserFullPath = new Point(1290, 76);
            KeyService.Instance.Click(ptUserFullPath);
            Thread.Sleep(100);
            KeyService.Instance.KeyDown("Ctrl");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("A");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("V");
            Thread.Sleep(100);
            KeyService.Instance.KeyUp("Ctrl");
            //KeyService.Instance.Input(path);
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Enter");
            Thread.Sleep(2000);

            Point ptBtnAddLogon = new Point(37, 134);
            KeyService.Instance.Click(ptBtnAddLogon);
            Thread.Sleep(2000);
            KeyService.Instance.Input(personId);
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Down");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Space");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Space");

            KeyService.Instance.KeyDown("Alt");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("S");
            Thread.Sleep(100);
            KeyService.Instance.KeyUp("Alt");
            Thread.Sleep(2000);
            KeyService.Instance.KeyPress("Space");
        }
    }
}
