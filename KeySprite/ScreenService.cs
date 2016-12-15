using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace KeySprite
{
    class ScreenService
    {
        [DllImport("user32.dll")]//取设备场景
        private static extern IntPtr GetDC(IntPtr hwnd);//返回设备场景句柄

        [DllImport("gdi32.dll")]//取指定点颜色
        private static extern int GetPixel(IntPtr hdc, Point p);

        public static Color GetColor(int x, int y)
        {
            Point p = new Point(x, y);//取置顶点坐标
            IntPtr hdc = GetDC(new IntPtr(0));//取到设备场景(0就是全屏的设备场景)
            int c = GetPixel(hdc, p);//取指定点颜色
            int r = (c & 0xFF);//转换R
            int g = (c & 0xFF00) / 256;//转换G
            int b = (c & 0xFF0000) / 65536;//转换B
            Color result = Color.FromArgb(r, g, b);//设置颜色框 
            return result;
        }

        private static Bitmap cache = new Bitmap(1, 1);
        private static Graphics tempGraphics = Graphics.FromImage(cache);
        private static object lockObj = new object();
        /// <summary>
        /// Gets the Color from the screen at the given point.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Color GetColorFromPoint(Point point)
        {
            lock (lockObj)
            {
                tempGraphics.CopyFromScreen((int)point.X, (int)point.Y, 0, 0, new Size(1, 1));
            }

            return cache.GetPixel(0, 0);
        }

        public static Bitmap GetLineFromScreen(Point begin, Point end)
        {
            int width = end.X - begin.X;
            Bitmap bitmap = new Bitmap(width, 1);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(begin, new Point(0, 0), new Size(width, 1));
            return bitmap;
        }
    }
}
