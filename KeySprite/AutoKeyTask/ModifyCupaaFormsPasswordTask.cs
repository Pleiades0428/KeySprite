using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace KeySprite.AutoKeyTask
{
    class ModifyCupaaFormsPasswordTask : AutoKeyTaskBase, IAutoKeyTask
    {
        int startNum;
        private string unifyPwd = "H2000h2000";
        Dictionary<string, string> dicLogon;

        public void Init(params object[] args)
        {
            startNum = int.Parse(args[0].ToString());
            dicLogon = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines("C:\\Users\\wang_teng.QDC\\Desktop\\HGHQPwd.txt");
            foreach (string item in lines)
            {
                string[] tokens = item.Split(' ');
                if (tokens.Length >= 2)
                {
                    dicLogon.Add(tokens[0], tokens[1]);
                }
            }
        }

        public void Execute(int num, params object[] args)
        {
            string logonName = "99" + (startNum + num).ToString();
            
            Point ptLogonTypeSelect = new Point(422, 376);
            Click(ptLogonTypeSelect);
            Wait(200);

            Input(logonName);
            Key("Tab");

            string pwd = dicLogon[logonName];

            Input(pwd);
            Key("Enter");
            Wait(2000);

            Input(pwd);
            Key("Tab");
            Input(unifyPwd);
            
            Key("Tab");
            Input(unifyPwd);
            Alt("S");
            Wait(2000);
            Key("Space");
            Wait(1000);
        }
    }
}
