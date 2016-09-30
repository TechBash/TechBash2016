using System;

namespace LocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new NodeLinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.PrintRecursiveCSharp6AndBelow();
            list.PrintRecursiveCSharp7();
        }
    }

    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }

    class NodeLinkedList
    {
        private Node head;

        public void Add(int value)
        {
            if (head == null)
            {
                head = new Node { Value = value };
            }
            else
            {
                var tail = head;
                while (tail.Next != null)
                {
                    tail = tail.Next;
                }
                tail.Next = new Node { Value = value };
            }
        }

        public void PrintRecursiveCSharp6AndBelow()
        {
            PrintRecursiveHelper(head);
            Console.WriteLine();
        }

        private void PrintRecursiveHelper(Node node)
        {
            if (node == null)
                return;

            Console.Write(node.Value + " ");
            PrintRecursiveHelper(node.Next);
        }

        public void PrintRecursiveCSharp7()
        {
            void Iterate(Node node)
            {
                if (node == null)
                    return;

                Console.Write(node.Value + " ");
                Iterate(node.Next);
            };

            Iterate(head);
            Console.WriteLine();
        }
    }
}