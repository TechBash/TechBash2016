using System;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Print(null);
        }

        static void Print(object x)
        {
            switch(x)
            {
                case DateTime d:
                    Console.WriteLine(d.ToShortDateString());
                    break;

                case int i when i % 2 == 0:
                    Console.WriteLine("even");
                    break;

                case int i:
                    Console.WriteLine(i);
                    break;

                case null:
                    Console.WriteLine("i've got notin'.");
                    break;
            }
        }
    }
}