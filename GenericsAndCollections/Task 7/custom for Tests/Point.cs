using System;

namespace GenericsAndCollections.Task_7.custom_for_Tests
{
    public struct Point : IComparable//<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point Add(Point first, Point second)
        {
            return new Point(first.X + second.X, first.Y + second.Y);
        }

        public int CompareTo(object obj)
        {
            Point point = (Point)obj;

            int lengthFirst = (int)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            int lengthSecond = (int)Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));

            if (lengthFirst > lengthSecond)
            {
                return 1;
            }
            else if  (lengthFirst < lengthSecond)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}