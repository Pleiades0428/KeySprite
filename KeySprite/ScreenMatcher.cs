using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace KeySprite
{
    class ScreenMatcher
    {
        private List<Tuple<Point, Color, Color?>> matchers;
        private int matchThreshold;

        public ScreenMatcher(int matchThreshold = 10)
        {
            this.matchThreshold = matchThreshold;
            matchers = new List<Tuple<Point, Color, Color?>>();
        }

        public void AddMatcher(Point p, Color c)
        {
            this.matchers.Add(Tuple.Create<Point, Color, Color?>(p, c, null));
        }

        public void AddMatcher(Point p, Color low, Color high)
        {
            this.matchers.Add(Tuple.Create<Point, Color, Color?>(p, low, high));
        }

        public void Clear()
        {
            this.matchers.Clear();
        }

        public Point? GetFirstMatchFromScreen(Point begin, Point end, Color color)
        {
            Bitmap bitmap = ScreenService.GetLineFromScreen(begin, end);
            for (int i = 0; i < bitmap.Width; i++)
            {
                Color c = bitmap.GetPixel(i, 0);
                if (IsColorMatch(c, color))
                {
                    return new Point(begin.X + i, begin.Y);
                }
            }
            return null;
        }

        public bool IsMatch()
        {
            foreach (var item in matchers)
            {
                Color color = ScreenService.GetColorFromPoint(item.Item1);

                if (item.Item3 != null)
                {
                    if (!IsColorMatch(color, item.Item2, item.Item3.Value))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!IsColorMatch(color, item.Item2))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsColorMatch(Color color, Color dest)
        {
            int dr = Math.Abs(color.R - dest.R);
            int dg = Math.Abs(color.G - dest.G);
            int db = Math.Abs(color.B - dest.B);


            if (dr + dg + db > matchThreshold)
            {
                return false;
            }
            return true;
        }

        public bool IsColorMatch(Color color, Color low, Color high)
        {
            if (color.R >= low.R && color.R <= high.R &&
                color.G >= low.G && color.G <= high.G &&
                color.B >= low.B && color.B <= high.B)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
