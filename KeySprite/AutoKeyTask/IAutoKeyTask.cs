using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeySprite.AutoKeyTask
{
    interface IAutoKeyTask
    {
        void Init(params object[] args);

        void Execute(int num, params object[] args);
    }
}
