using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace KeySprite.AutoKeyTask
{
    class AddCupaaUsbKeyLogonTask : IAutoKeyTask
    {
        public void Init(params object[] args)
        {
            //
        }

        public void Execute(int num, params object[] args)
        {
            DoKeyForAddUsbKeyLogon();
        }

        private void DoKeyForAddUsbKeyLogon()
        {
            Point selectUser = new Point(485, 322);
            KeyService.Instance.Click(selectUser);
            Thread.Sleep(100);
            Point tbUserFullPath = new Point(897, 317);
            KeyService.Instance.Click(tbUserFullPath);
            Thread.Sleep(100);
            KeyService.Instance.Input("4224270");
            Thread.Sleep(100);
            string logonName = "4224270611234567";
            KeyService.Instance.KeyDown("Alt");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("E");
            Thread.Sleep(100);
            KeyService.Instance.KeyUp("Alt");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Enter");
            //450, 384
            Point userName = new Point(450, 384);
            KeyService.Instance.MouseMove(userName);
            Thread.Sleep(100);
            KeyService.Instance.RightClick();
        }
    }
}
