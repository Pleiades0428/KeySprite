using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KeySprite.AutoKeyTask
{
    class InputRandomNumberForWebAppraisementTask : AutoKeyTaskBase, IAutoKeyTask
    {
        private int range;
        private Random rand = new Random();
        public void Init(params object[] args)
        {
            range = int.Parse(args[0].ToString());
        }

        public void Execute(int num, params object[] args)
        {
            Do();
        }

        private void Do()
        {
            int score = rand.Next(range);
            Input(score.ToString());
            Wait(10);
            Key("Tab");
        }
    }
}
