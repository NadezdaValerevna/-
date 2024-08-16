using System;
using System.Data;

namespace Lab1
{
    public class ArrList: BaseList
    {
        int[] buf = null; // элементы списка

        public override void Add(int a)
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

        public override void Clear()
        {
            count = 0;
        }

        protected override BaseList EmptyClone()
        {
            return new ArrList();
        }
        public override void Delete(int pos)
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
        public override void Insert(int a, int pos)
        {
            if (pos < 0 || pos > count)
            {
                return; // позиция вне диапазона списка
            }
            if (buf.Length <= count)  //проверка заполности буфера
            {
                // создаем новый буфер увеличив его(если надо) и копируем в него элементы
                int[] newBuf = new int[buf.Length * 2];
                for (int i = 0; i < buf.Length; i++)
                {
                    newBuf[i] = buf[i];
                }
                buf = newBuf;
            }
            //сдвигаем элементы вправо, чтобы освободить место
            for (int i = count; i > pos; i--)
            {
                buf[i] = buf[i - 1];
            }
            //вставляем элемент на указанную позицию и увеличиваем кол-во элементов 
            buf[pos] = a;
            count++;
        }

        public override int this[int pos]
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