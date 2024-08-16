using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class ChainList : BaseList
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

        public override void Sort()
        {
            if (count <= 1)
            {
                return;
            }
            for (int i = 0; i < count; i++)
            {
                Node CurNode = head;
                while (CurNode != null && CurNode.Next != null)
                {
                    if (CurNode.Data > CurNode.Next.Data)
                    {
                        int t = CurNode.Data;
                        CurNode.Data = CurNode.Next.Data;
                        CurNode.Next.Data = t;
                    }
                    CurNode = CurNode.Next;
                }
            }
        }

        Node head = null;
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
        protected override BaseList EmptyClone()
        {
            return new ChainList();
        }



        public override void Add(int value)
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
        public override void Insert(int data, int pos)
        {
            if (pos < 0 || pos > count)
            {
                return; // проверка позиции
            }

            Node newNode = new Node(data); // создаем новый узел с указынными данными
            if (pos == 0) //вставка в начало
            {
                //делаем его головным
                newNode.Next = head;
                head = newNode;
            }
            else //вставка в середину или в конец списка
            {
                //находим узел, который находится до позиции вставки
                Node current = head;
                for (int i = 0; i < pos - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next; // вставляем новый узел между current и current.Next
                current.Next = newNode;
            }
            count++;
        }
        public override void Delete(int pos)
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
        public override void Clear()
        {
            count = 0;
            head = null;
        }
        public override int this[int pos]
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

    }

    


}
