using System;
using System.Collections.Generic;
using System.Text;

namespace DeleteMiddleNode
{
    class DeleteMiddleNode
    {
        class Node
        {
            public int data;
            public Node next;
        }

        static Node DeleteMiddle(Node head)
        {
            if (head == null)
            {
                return null;
            }
            if (head.next == null)
            {
                return null;
            }

            Node SlowPointer = head;
            Node FastPointer = head;

            Node prev = null;

            while (FastPointer != null && FastPointer.next != null)
            {
                FastPointer = FastPointer.next.next;
                prev = SlowPointer;
                SlowPointer = SlowPointer.next;
            }

            prev.next = SlowPointer.next;

            return head;
        }

        static void PrintList(Node pointer)
        {
            while (pointer != null)
            {
                Console.Write(pointer.data + "->");
                pointer = pointer.next;
            }
            Console.WriteLine("NULL");
        }

        static Node NewNode(int data)
        {
            Node temp = new Node();
            temp.data = data;
            temp.next = null;
            return temp;
        }

        public static void Main(String[] args)
        {
            Node head = NewNode(1);
            head.next = NewNode(2);
            head.next.next = NewNode(3);
            head.next.next.next = NewNode(4);
            head.next.next.next.next = NewNode(5);
            head.next.next.next.next.next = NewNode(6);

            Console.WriteLine("İlk Linked List");
            PrintList(head);

            head = DeleteMiddle(head);

            Console.WriteLine("Ortanca eleman silindikten sonra Linked List: ");
            PrintList(head);
        }
    }
}
