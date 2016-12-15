using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace KeySprite.AutoKeyTask
{
    class AddCupaaWJUsersTask : IAutoKeyTask
    {
        Point ptAddUserButton;
        int startNum;
        public void Init(params object[] args)
        {
            startNum = int.Parse(args[0].ToString());
            ptAddUserButton = new Point(268, 215);
        }

        public void Execute(int num, params object[] args)
        {
            KeyService.Instance.MouseMove(ptAddUserButton);
            Thread.Sleep(100);
            KeyService.Instance.Click();
            Thread.Sleep(1000);

            KeyService.Instance.KeyPress("Space");
            Thread.Sleep(500);

            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(100);
            KeyService.Instance.Input("99");
            Thread.Sleep(500);
            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(500);

            string lastName = (startNum + num).ToString();
            KeyService.Instance.Input(lastName);
            Thread.Sleep(1000);

            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(1000);
            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(1000);
            KeyService.Instance.KeyPress("Tab");
            Thread.Sleep(1000);

            KeyService.Instance.Input("99" + lastName);
            Thread.Sleep(500);

            KeyService.Instance.KeyDown("Alt");
            Thread.Sleep(500);
            KeyService.Instance.KeyPress("S");
            Thread.Sleep(100);
            KeyService.Instance.KeyUp("Alt");

            //KeyService.Instance.MouseMove(ptAddUserConfirm);
            //Thread.Sleep(100);
            //KeyService.Instance.Click();
            Thread.Sleep(2000);
            KeyService.Instance.KeyPress("Space");
            Thread.Sleep(3000);
        }
    }
}
