using System;
using System.Data;

namespace Lab1
{
    public class ArrList<T> : BaseList<T> where T : IComparable<T>
    {
        private T[] buf; // массив для хранения элементов 
                         // private int count;
                         // Переопределение свойства для получения количества элементов в списке
        public ArrList()
        {
            buf = new T[5]; // задаем нач. размер
            count = 0;
        }
        // метод для добавления элементов в список
        public override void Add(T item)
        {
            if (buf.Length <= count) //проверка заполности буфера
            {
                T[] newBuf = new T[buf.Length * 2]; // создаем новый буфер увеличив его(если надо) и копируем в него элементы
                for (int i = 0; i < buf.Length; i++)
                {
                    newBuf[i] = buf[i];
                }
                buf = newBuf;
            }
            //добавляем элемент и увеливаем кол-во элементов
            buf[count] = item;
            count++;
            OnChange(EventArgs.Empty);
        }

        // метод для добавления элемента на определенную позицию
        public override void Insert(int pos, T item)
        {
            if (pos < 0 || pos > count)
            {
                throw new BadIndexException("Pos is out of range"); // позиция вне диапазона списка
            }
            if (buf.Length <= count)  //проверка заполности буфера
            {
                // создаем новый буфер увеличив его(если надо) и копируем в него элементы
                T[] newBuf = new T[buf.Length * 2];
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
            buf[pos] = item;
            count++;
            OnChange(EventArgs.Empty);
        }

        // метод для удаления элемента с определенной позиции
        public override void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                throw new BadIndexException("Pos is out of range"); //проверка позиции
            }
            //сдвигаем элементы влево для удаления
            for (int i = pos; i < count - 1; i++)
            {
                buf[i] = buf[i + 1];
            }
            //уменьшаем кол-во элементов
            count--;
            OnChange(EventArgs.Empty);
        }

        // метод очистки списка
        public override void Clear()
        {
            buf = new T[5];
            count = 0; //сбрасываем кол-во элементов
            OnChange(EventArgs.Empty);
        }

        //индексатор для доступа к элементам списка
        public override T this[int i]
        {
            get
            {
                if (i >= count || i < 0)
                {
                    throw new BadIndexException("Element is out of range");
                }
                return buf[i]; //возращаем элемент списка по указанному индексу
            }

            set
            {
                if (i >= count || i < 0)
                {
                    //throw new ArgumentOutOfRangeException("Element is out of range");
                    //retutn;
                    throw new BadIndexException("Element is out of range");
                }
                buf[i] = value; //присваиваем новое значение элементу списка по указанному индексу
                OnChange(EventArgs.Empty);
            }
        }
        // переопределение метода EmptyClone для создания пустой копии текущего списка
        protected override BaseList<T> EmptyClone()
        {
            // создание нового объекта ArrList в качестве пустой копии списка.
            ArrList<T> copy = new ArrList<T>();
            copy.buf = new T[buf.Length];
            Array.Copy(buf, copy.buf, count);
            copy.count = count;
            return copy;
        }
    }   
}