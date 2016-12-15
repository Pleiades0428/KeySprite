using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KeySprite
{
    [Flags]
    enum MouseEventFlag : uint
    {
        Move = 0x0001,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        XDown = 0x0080,
        XUp = 0x0100,
        Wheel = 0x0800,
        VirtualDesk = 0x4000,
        Absolute = 0x8000
    }

    public class KeyService
    {
        //[DllImport("USER32.DLL")]
        //public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);  //导入寻找windows窗体的方法
        //[DllImport("USER32.DLL")]
        //public static extern bool SetForegroundWindow(IntPtr hWnd);  //导入为windows窗体设置焦点的方法
        [DllImport("USER32.DLL")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);  //导入模拟键盘的方法

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        static int KeyDownDWord = 0;
        static int KeyUpDWord = 2;
        Dictionary<string, Byte> keys;
        Dictionary<char, int> dicSymbols;

        public static readonly KeyService Instance = new KeyService();

        private KeyService()
        {
            keys = new Dictionary<string, byte>();
            keys.Add("LMouse", 0x1);
            keys.Add("RMouse", 0x2);
            keys.Add("Back", 0x8);
            keys.Add("Tab", 0x9);
            keys.Add("Enter", 0x0D);
            keys.Add("Shift", 0x10);
            keys.Add("Ctrl", 0x11);
            keys.Add("Alt", 0x12);
            keys.Add("Esc", 0x1B);
            keys.Add("End", 0x23);
            keys.Add("Left", 0x25);
            keys.Add("Up", 0x26);
            keys.Add("Right", 0x27);
            keys.Add("Down", 0x28);
            //keys.Add("A", 65);
            //keys.Add("B", 66);

            for (int i = 0; i < 26; i++)
            {
                int ascii = i + 65;
                char c = Convert.ToChar(ascii);
                keys.Add(c.ToString(), (byte)ascii);
            }

            for (int i = 0; i < 10; i++)
            {
                int ascii = i + 48;
                char c = Convert.ToChar(ascii);
                keys.Add(c.ToString(), (byte)ascii);
            }

            keys.Add("Space", 32);

            dicSymbols = new Dictionary<char, int>();
            dicSymbols.Add('!', 1);
            dicSymbols.Add('@', 2);
            dicSymbols.Add('#', 3);
            dicSymbols.Add('$', 4);
            dicSymbols.Add('%', 5);
            dicSymbols.Add('^', 6);
            dicSymbols.Add('&', 7);
            dicSymbols.Add('*', 8);
            dicSymbols.Add('(', 9);
            dicSymbols.Add(')', 0);
        }

        public void Click()
        {
            mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }

        public void Click(Point p)
        {
            MouseMove(p);
            mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }

        public void RightClick()
        {
            mouse_event(MouseEventFlag.RightDown | MouseEventFlag.RightUp, 0, 0, 0, UIntPtr.Zero);
        }

        public void MouseMove(Point p)
        {
            MouseMove(p.X, p.Y);
        }

        public void MouseMove(int dx, int dy)
        {
            SetCursorPos(dx, dy);
        }

        public void KeyPress(string keyChar)
        {
            byte keyByte = GetKeyByteByChar(keyChar);
            if (keyByte == 0)
            {
                throw new Exception("未找到按键" + keyChar + "的代码");
            }
            else
            {
                keybd_event(keyByte, 0, KeyDownDWord, 0);
                keybd_event(keyByte, 0, KeyUpDWord, 0);
            }
        }

        public void KeyDown(string keyChar)
        {
            byte keyByte = GetKeyByteByChar(keyChar);
            if (keyByte == 0)
            {
                throw new Exception("未找到按键" + keyChar + "的代码");
            }
            else
            {
                keybd_event(keyByte, 0, KeyDownDWord, 0);
            }
        }

        public void KeyUp(string keyChar)
        {
            byte keyByte = GetKeyByteByChar(keyChar);
            if (keyByte == 0)
            {
                throw new Exception("未找到按键" + keyChar + "的代码");
            }
            else
            {
                keybd_event(keyByte, 0, KeyUpDWord, 0);
            }
        }

        private bool IsSymbol(char c, out int num)
        {
            return dicSymbols.TryGetValue(c, out num);
        }

        public void Input(string str)
        {
            foreach (char c in str)
            {
                int num;
                if (IsSymbol(c, out num))
                {
                    KeyDown("Shift");
                    Thread.Sleep(100);
                    KeyPress(num.ToString());
                    Thread.Sleep(100);
                    KeyUp("Shift");
                }
                else if (char.IsUpper(c))
                {
                    KeyDown("Shift");
                    Thread.Sleep(100);
                    KeyPress(c.ToString());
                    Thread.Sleep(100);
                    KeyUp("Shift");
                }
                else
                {
                    KeyPress(c.ToString().ToUpper());
                }
                Thread.Sleep(100);
            }
        }

        private byte GetKeyByteByChar(string keyChar)
        {
            byte b;
            if (!keys.TryGetValue(keyChar, out b))
            {
                b = 0;
            }
            return b;
        }
    }
}
