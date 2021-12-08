using System;
using System.Collections.Generic;
using System.Text;

namespace CracingTheCodingInterview
{   //Cracking-the-Coding-Interview-6th-Edition-189-Programming-Questions-and-Solutions SAYFA NO: 95 SORU: 2.5 ÇÖZÜMÜ
    class SumsList
    {
        class Node
        {
            public int val;
            public Node next;

            public Node(int val)
            {
                this.val = val;
            }
        }

        void PrintList(Node head)
        {
            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
        }

        Node head1, head2, result;
        int carry;

        void Push(int val, int list)
        {
            Node node = new Node(val);

            if (list == 1)
            {
                node.next = head1;
                head1 = node;
            }
            else if (list == 2)
            {
                node.next = head2;
                head2 = node;
            }
            else
            {
                node.next = result;
                result = node;
            }
        }

        void AddSameSize(Node x, Node y)
        {
            if (x == null)
            {
                return;
            }

            AddSameSize(x.next, y.next);

            int sum = x.val + y.val + carry;
            carry = sum / 10;
            sum = sum % 10;

            Push(sum, 3);
        }

        Node cur;

        void PropoGateCarry(Node head1)
        {
            if (head1 != cur)
            {
                PropoGateCarry(head1.next);
                int sum = carry + head1.val;
                carry = sum / 10;
                sum %= 10;

                Push(sum, 3);
            }
        }

        int GetSize(Node head)
        {
            int count = 0;
            while (head != null)
            {
                count++;
                head = head.next;
            }
            return count;
        }

        void AddLists()
        {
            if (head1 == null)
            {
                result = head1;
                return;
            }

            int Size1 = GetSize(head1);
            int Size2 = GetSize(head2);

            if (Size1 == Size2)
            {
                AddSameSize(head1, head2);
            }
            else
            {
                if (Size1 < Size2)
                {
                    Node temp = head1;
                    head1 = head2;
                    head2 = temp;
                }

                int diff = Math.Abs(Size1 - Size2);

                Node tmp = head1;

                while (diff-- >= 0)
                {
                    cur = tmp;
                    tmp = tmp.next;
                }

                AddSameSize(cur, head2);
                PropoGateCarry(head1);
            }

            if (carry > 0)
            {
                Push(carry, 3);
            }
        }

        public static void Main(String[] args)
        {
            SumsList sumsList = new SumsList();
            sumsList.head1 = null;
            sumsList.head2 = null;
            sumsList.result = null;
            sumsList.carry = 0;

            int[] Array1 = { 6, 1, 7 };
            int[] Array2 = { 2, 9, 5 };

            for (int i = Array1.Length - 1; i >= 0; --i)
            {
                sumsList.Push(Array1[i], 1);
            }

            for (int i = Array2.Length - 1; i >= 0; --i)
            {
                sumsList.Push(Array2[i], 2);
            }

            sumsList.AddLists();
            sumsList.PrintList(sumsList.result);
        }
    }
}
