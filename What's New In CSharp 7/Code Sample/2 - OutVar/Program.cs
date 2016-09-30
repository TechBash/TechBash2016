using System;

namespace OutVar
{
    class Program
    {
        static void Main(string[] args)
        {
            CSharp6AndBelow();
            CSharp7();
        }

        static void CSharp6AndBelow()
        {
            int number;
            if (int.TryParse("1337", out number))
                Console.WriteLine(number);
        }

        static void CSharp7()
        {
            if (int.TryParse("1337", out var number))
                Console.WriteLine(number);
        }
    }
}