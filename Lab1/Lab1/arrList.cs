using System;
using System.Data;

namespace Lab1
{
    public class ArrList
    {
        int[] buf = null; // элементы списка
        int count = 0; //кол-во элементов списка

        public void Add(int a)
        {
            if (buf == null)
            {
                buf = new int[1];
            }
            if (count == buf.Length)
            {
                Expand();
            }
            buf[count++] = a;
        }
        void Expand()
        {
            if (buf == null)
            {
                buf = new int[1];
                return;
            }
            if (count < buf.Length)
            {
                return;
            }
            int newSize = buf.Length * 2;
            int[] newBuf = new int[newSize];
            Array.Copy(buf, newBuf, buf.Length);
            buf = newBuf;
        }

        public void Clear()
        {
            count = 0;
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(buf[i] + " ");
            }
            Console.WriteLine();
        }

        public void Delete(int pos)
        {
            if (pos >= count)
            {
               //onsole.WriteLine("Выход за пределы массива");
                //throw new IndexOutOfRangeException();
            }
            else
            {
                count--;
                int[] MACCUB1 = new int[count];
                for (int i = 0; i < count; i++)
                {
                    if (i < pos)
                    {
                        MACCUB1[i] = buf[i];
                    }
                    if (i >= pos)
                    {
                        MACCUB1[i] = buf[i + 1];
                    }
                }
                buf = MACCUB1;
            }
        }
        public void Insert(int pos, int a)
        {
            if (pos >= count)
            {
               //onsole.WriteLine("Выход за пределы массива");
                //throw new IndexOutOfRangeException();
            }
            else
            {
                count++;
                int[] MACCUB1 = new int[count];
                for (int i = 0; i < count - 1; i++)
                {
                    if (i < pos)
                    {
                        MACCUB1[i] = buf[i];
                    }
                    else
                    {
                        MACCUB1[i + 1] = buf[i];
                    }
                }
                MACCUB1[pos] = a;
                buf = MACCUB1;
            }
        }
        public int this[int pos]
        {
            get
            {
                if (pos < count)
                {
                    return buf[pos];
                }
                else
                {
                  //Console.WriteLine("Выход за пределы массива");
                    //throw new IndexOutOfRangeException();
                    return -1;
                }

            }
            set
            {
                if (pos < count)
                {
                    buf[pos] = value;
                }
                else
                {
                  //Console.WriteLine("Выход за пределы массива");
                    //throw new IndexOutOfRangeException();
                }
            }
        }

    }
}