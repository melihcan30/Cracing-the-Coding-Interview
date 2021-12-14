using System;

namespace Intersection
{
    class Intersection
    {
        static Node Dummy = null;
        static Node Tail = null;

        public class Node
        {
            public int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
                next = null;
            }
        }

        Node GroupA = null, GroupB = null;

        void PrintList(Node start)
        {
            Node node = start;
            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
            Console.WriteLine();
        }

        void Push(int data)
        {
            Node temp = new Node(data);
            if (Dummy == null)
            {
                Dummy = temp;
                Tail = temp;
            }
            else
            {
                Tail.next = temp;
                Tail = temp;
            }
        }

        void SortedIntersect()
        {
            Node node = GroupA, node1 = GroupB;
            while (node != null && node1 != null)
            {
                if (node.data == node1.data)
                {
                    Push(node.data);
                    node = node.next;
                    node1 = node1.next;
                }
                else if (node.data < node1.data)
                {
                    node = node.next;
                }
                else
                {
                    node1 = node1.next;
                }
            }
        }
        static void Main(string[] args)
        {
            Intersection list = new Intersection();

            // creating first linked list
            list.GroupA = new Node(3);
            list.GroupA.next = new Node(6);
            list.GroupA.next.next = new Node(9);
            list.GroupA.next.next.next = new Node(12);
            list.GroupA.next.next.next.next = new Node(15);
            list.GroupA.next.next.next.next.next = new Node(18);

            // creating second linked list
            list.GroupB = new Node(6);
            list.GroupB.next = new Node(12);
            list.GroupB.next.next = new Node(18);
            list.GroupB.next.next.next = new Node(24);

            // function call for intersection
            list.SortedIntersect();

            // print required intersection
            Console.WriteLine("Linked list containing common items of Group a & Group b");
            list.PrintList(Dummy);
        }
    }
}
