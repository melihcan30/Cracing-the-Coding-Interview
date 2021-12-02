using System;
using System.Collections.Generic;

namespace RemoveDups
{
    class RemoveDuplicates
    {
        class Node
        {
            public int value;
            public Node next;
            public Node(int value)
            {
                this.value = value;
            }
        }

        //unsorted linked list 
        static void RemoveDuplicate(Node head)
        {
            HashSet<int> hashSet = new HashSet<int>();

            Node current = head;
            Node prev = null;
            while (current != null)
            {
                int currentValue = current.value;

                if (hashSet.Contains(currentValue))
                {
                    prev.next = current.next;
                }
                else
                {
                    hashSet.Add(currentValue);
                    prev = current;
                }
                current = current.next;
            }
        }

        //Given link list
        static void PrintList(Node head)
        {
            while (head != null)
            {
                Console.WriteLine(head.value + " ");
                head = head.next;
            }
        }

        static void Main(string[] args)
        {
            //Link list = 30->32->31->31->32->31->30
            Node start = new Node(30);
            start.next = new Node(32);
            start.next.next = new Node(31);
            start.next.next.next = new Node(31);
            start.next.next.next.next = new Node(32);
            start.next.next.next.next.next = new Node(31);
            start.next.next.next.next.next.next = new Node(30);

            Console.WriteLine("Silinmeden önce Link list " + "Kopyalar :");

            PrintList(start);
            RemoveDuplicate(start);

            Console.WriteLine("\nLinked list kaldırıldıkan sonra" + "kopyalar :");

            PrintList(start);
        }
    }
}



