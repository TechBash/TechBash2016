using System;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Syntical Sugar For 'new Tuple<int,int>(1,2)'
            var xDeclare = (1, 2);

            // Named Items, Just An IDE Mirage
            var xDeclareWithNames = (a: 1, b: 2);

            // Value Equality (== Not Yet Supported)
            Console.WriteLine((1, 2).Equals((1, 2)));

            // Value Equality, Named Items Irrelevant
            Console.WriteLine((foo: 1, bar: 2).Equals((1, 2)));

            // Declare & Deconstruct
            (int foo1, int bar1) = xDeclareWithNames;
            (var foo2, var bar2) = xDeclareWithNames;
            var (foo3, bar3) = xDeclareWithNames;

            // Deconstruct & Assign
            int foo4, bar4;
            (foo4, bar4) = xDeclareWithNames;
        }

        static (int x, int y) MethodReturnExample()
        {
            return (4, 8);
        }
    }
}