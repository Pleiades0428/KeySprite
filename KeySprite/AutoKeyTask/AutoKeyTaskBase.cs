using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace KeySprite.AutoKeyTask
{
    class AutoKeyTaskBase
    {
        protected void Key(string key)
        {
            KeyService.Instance.KeyPress(key);
        }

        protected void KeyDown(string key)
        {
            KeyService.Instance.KeyDown(key);
        }

        protected void KeyUp(string key)
        {
            KeyService.Instance.KeyUp(key);
        }

        protected void Move(Point point)
        {
            KeyService.Instance.MouseMove(point);
        }

        protected void Click(Point point)
        {
            KeyService.Instance.Click(point);
        }

        protected void RightClick()
        {
            KeyService.Instance.RightClick();
        }

        protected void Alt(string key)
        {
            KeyService.Instance.KeyDown("Alt");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress(key);
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Alt");
        }

        protected void Shift(string key)
        {
            KeyService.Instance.KeyDown("Shift");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress(key);
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Shift");
        }

        protected void Ctrl(string key)
        {
            KeyService.Instance.KeyDown("Ctrl");
            Thread.Sleep(100);
            KeyService.Instance.KeyPress(key);
            Thread.Sleep(100);
            KeyService.Instance.KeyPress("Ctrl");
        }

        protected void Input(string content)
        {
            KeyService.Instance.Input(content);
        }

        protected void Wait(int miliseconds)
        {
            Thread.Sleep(miliseconds);
        }
    }
}
