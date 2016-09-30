using System;

namespace Literals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Large Number 
            Console.WriteLine(4815162342);
            Console.WriteLine(4_815_162_342);   // Now With Literal Separators

            // Color
            Console.WriteLine(0xABCDEF);
            Console.WriteLine(0xAB_CD_EF);      // Now With Literal Separators   

            // Bitmask
            Console.WriteLine(0xF5);
            Console.WriteLine(0b1111_0101);     // Now With Binary Literals
        }
    }
}