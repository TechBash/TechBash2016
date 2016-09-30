using System;
using System.Linq;

namespace RefReturnRefLocal
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            PrintArray(array);

            ref var item1 = ref Find(array, 3);
            item1 = 99;
            PrintArray(array);

            ref var item2 = ref array[3];
            item2 = 88;
            PrintArray(array);
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine(String.Join(", ", array.Select(x => x.ToString())));
        }

        static ref int Find(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    return ref array[i];
            }

            throw new IndexOutOfRangeException($"{nameof(number)} not found.");
        }
    }
}