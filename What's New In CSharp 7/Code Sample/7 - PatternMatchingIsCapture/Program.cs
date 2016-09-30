using System;

namespace PatternMatchingIsCapture
{
    class Program
    {
        static void Main(string[] args)
        {
            object foo = "hello world";

            TypeCheckCSharp6AndBelow(foo);
            TypeCheckCSharp7(foo);
        }

        static void TypeCheckCSharp6AndBelow(object foo)
        {
            var s = foo as string;
            if (s != null)
                Console.WriteLine(s);
        }

        static void TypeCheckCSharp7(object foo)
        {
            if (foo is string s)
                Console.WriteLine(s);
        }
    }
}