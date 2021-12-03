using System;
using System.Collections.Generic;
using System.Text;

namespace CracingTheCodingInterview
{
    class ReturnKthToLast
    {
        Node head;

        public class Node
        {
            public int data;
            public Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        void PrintNthFromLast(int n)
        {
            Node MainPtr = head;
            Node RefPtr = head;

            int count = 0;
            if (head != null)
            {
                while (count < n)
                {
                    if (RefPtr == null)
                    {
                        Console.WriteLine(n + " hayırdan daha büyük " + " listedeki düğüm sayısı");
                        return;
                    }

                    RefPtr = RefPtr.next;
                    count++;
                }
            }

            if (RefPtr == null)
            {
                head = head.next;
                if (head != null)
                {
                    Console.WriteLine("Node no. " + n + " sondan itibaren " + MainPtr.data);
                }

                else
                {
                    while (RefPtr != null)
                    {
                        MainPtr = MainPtr.next;
                        RefPtr = RefPtr.next;
                    }
                    Console.WriteLine("Node no. " + n + " sondan itibaren " + MainPtr.data);
                }
            }
        }

        public void Push(int NewData)
        {
            Node NewNode = new Node(NewData);
            NewNode.next = head;
            head = NewNode;
        }

        public static void Main(String[] args)
        {
            ReturnKthToLast llist = new ReturnKthToLast();
            llist.Push(20);
            llist.Push(4);
            llist.Push(15);
            llist.Push(35);

            llist.PrintNthFromLast(4);
        }
    }
}
