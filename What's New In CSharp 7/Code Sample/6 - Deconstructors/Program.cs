using System;

namespace Deconstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            var (x, y) = new Point(4, 8);
        }
    }

    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        // FYI: Also Works As An Extension Method
        public void Deconstruct(out int a, out int y)
        {
            a = this.X;
            y = this.Y;
        }
    }
}