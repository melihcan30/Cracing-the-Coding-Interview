using System;
using System.Collections.Generic;

namespace SortStack
{
    class Program
    {
        public static Stack<int> SortStack(Stack<int> input)
        {
            Stack<int> TempStack = new Stack<int>();
            while (input.Count > 0)
            {
                int temp = input.Pop();

                while (TempStack.Count > 0 && TempStack.Peek() > temp)
                {
                    input.Push(TempStack.Pop());
                }
                TempStack.Push(temp);
            }
            return TempStack;
        }

        static void Main(string[] args)
        {
            Stack<int> input = new Stack<int>();
            input.Push(31);
            input.Push(13);
            input.Push(30);
            input.Push(54);
            input.Push(11);
            input.Push(3);
            input.Push(23);

            Stack<int> tempStack = SortStack(input);
            Console.WriteLine("Sorted numbers are : ");

            while (tempStack.Count > 0)
            {
                Console.WriteLine(tempStack.Pop() + " ");
            }
        }
    }
}
