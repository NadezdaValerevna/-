using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class ChainList
    {
        public class Node
        {
            public int Data { set; get; }
            public Node Next { set; get; }

            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }
        Node head = null;
        int count = 0;

        public Node Find(int pos)
        {
            if (pos >= count)
            {
                return null;
            }
            int i = 0;
            Node p = head;
            while (p != null && i < pos)
            {
                p = p.Next;
                i++;
            }
            if (i == pos)
            {
                return p;
            }
            else
            {
                return null;
            }
        }
        public void Add(int value)
        {
            if (head == null)
            {
                head = new Node(value);
            }
            else
            {
                Node lastNode = Find(count - 1);
                lastNode.Next = new Node(value);
            }
            count++;
        }
        public void Insert(int pos, int value )
        {
            if (pos > count)
                return;
        
            if (pos != 0)
            {
                Node PrevNode = Find(pos - 1);
                Node NewNode = new Node(value);
                NewNode.Next = PrevNode.Next;
                PrevNode.Next = NewNode;
            }
            else
            {
                Node NewNode = new Node(value);
                NewNode.Next = head;
                head = NewNode;
            }
            count++;
        }
        public void Delete(int pos)
        {
            if (pos >= count || pos < 0 || count == 0)
            {
               //onsole.WriteLine("Данной позиции не существует.");
            }
            else
            {
                if (pos == 0)
                {
                    head = head.Next;
                }
                else if (pos == count - 1)
                {
                    Find(pos - 1).Next = null;
                }
                else
                {
                    Find(pos - 1).Next = Find(pos + 1);
                }
                count--;
            }
        }
        public void Clear()
        {
            count = 0;
            head = null;
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
        public int this[int pos]
        {
            get
            {
                if (pos < count && pos >= 0 && count != 0)
                {
                    return Find(pos).Data;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (pos < count && pos >= 0 && count != 0)
                {
                    Find(pos).Data = value;
                }
                else
                {
                    if (pos >= count || pos < 0 || count == 0)
                    {
                        //Console.WriteLine("Данной позиции не существует.");
                    }
                    else
                    {
                        Find(pos).Data = 0;
                    }
                }
            }

        }
        public void Print()
        {
            Node CurNode = head;
            while (CurNode != null)
            {
                Console.Write("{0} ", CurNode.Data);
                CurNode = CurNode.Next;
            }
            Console.WriteLine();
        }
      

    }

    


}
