using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class ChainList<T> : BaseList<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Data; //данные в узле
            public Node Next; // ссылка на след. элемент

            //конструктор для создания узла с заданными нач. условиями 
            public Node(T data)
            {
                Data = data;
                Next = null; //нач. условие 
            }
        }
        private Node head; //голова списка 1 узел


        //сам цепной список
        public ChainList()
        {
            head = null; //создание пустого списка
            count = 0;
        }

        //метод для добавления узлов
        public override void Add(T item)
        {
            Node newNode = new Node(item); //создаем новый список
            if (head == null)
            {
                head = newNode;//создание 1-ого узла, если его нет (newNode становится головой списка)
            }
            else
            {
                Node current = head; // current - голова списка
                while (current.Next != null) //идем к последнему узлу
                {
                    current = current.Next;
                }
                current.Next = newNode; //добавляем новый узел в конец
            }
            count++;
            OnChange(EventArgs.Empty);
        }

        //метод для добавления узла на указанную позицию
        public override void Insert(int pos, T item)
        {
            if (pos < 0 || pos > count)
            {
                throw new BadIndexException("Position is out of range");
                //return; // проверка позиции
            }

            Node newNode = new Node(item); // создаем новый узел с указынными данными
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
            OnChange(EventArgs.Empty);
        }

        //метод для удаления узла с указанной позиции
        public override void Delete(int pos)
        {
            if (pos < 0 || pos > count)
            {
                throw new BadIndexException("Position is out of range");
                //return; //проверка позиции
            }
            if (pos == 0)
            {
                head = head.Next; //удаление головы списка
            }
            else // удаление из середины или конца списка
            {
                //находим узел, который находится до позиции удаления
                Node current = head;
                for (int i = 0; i < pos - 1; i++)
                {
                    current = current.Next;
                }
                // проверяем, не является ли current.Next последним элементом
                if (current.Next != null)
                {
                    // если удаляем последний элемент, то устанавливаем Next предпоследнего элемента в null
                    if (current.Next.Next == null)
                    {
                        current.Next = null;
                    }
                    else
                    {
                        current.Next = current.Next.Next; //пропускаем узел, который хотим удалить 
                    }
                }
            }
            count--;
            OnChange(EventArgs.Empty);
        }

        //метод для очистки 
        public override void Clear()
        {
            head = null; //удаляем ссылку на голову списка
            count = 0;
            OnChange(EventArgs.Empty);
        }
        // получение кол-ва элементов списка

        //индексатор для доступа к узлам списка
        public override T this[int i]
        {
            get
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException("Index is out of range");
                }
                //начинаем с головного узла
                Node current = head;
                for (int j = 0; j < i; j++)
                {
                    // переходим к след. узлу, пока не достигнем нужного индекса
                    if (current != null)
                    {
                        current = current.Next;
                    }
                    else
                    {
                        throw new BadIndexException("Index is out of range");
                        //throw new ArgumentOutOfRangeException("Index out of range");
                    }
                }
                //возвращаем данные узла по указанному индексу
                return current.Data;
            }
            set
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException("Index is out of range");
                }
                //начинаем с головного узла
                Node current = head;
                for (int j = 0; j < i; j++)
                {
                    //переходим к след. узлу, пока не достигнем нужного индекса
                    if (current != null)
                    {
                        current = current.Next;
                    }
                    else
                    {
                        throw new BadIndexException("Index is out of range");
                        //throw new ArgumentOutOfRangeException("Index out of range");
                        //return;
                    }
                }
                //проверяем, что узел существует
                if (current != null)
                {
                    current.Data = value; //присваиваем новое значение
                }
                else
                {
                    throw new BadIndexException("Index is out of range");
                    //throw new ArgumentOutOfRangeException("Index out of range");
                    //return;
                }
                OnChange(EventArgs.Empty);
            }
        }
        protected override BaseList<T> EmptyClone()
        {
            ChainList<T> clone = new ChainList<T>();
            Node current = head;
            Node cloneCurrent = null;
            while (current != null)
            {
                if (clone.head == null)
                {
                    clone.head = new Node(current.Data);
                    cloneCurrent = clone.head;
                }
                else
                {
                    cloneCurrent.Next = new Node(current.Data);
                    cloneCurrent = cloneCurrent.Next;
                }
                current = current.Next;
            }
            clone.count = count;
            return clone;
        }

        // гномья сортировка с использованием IComparable<T>
        public override void Sort()
        {
            if (head == null || head.Next == null)
                return; // если список пуст или содержит только один элемент, сортировка не требуется 

            Node current = head;


            while (current.Next != null) // до предпоследнего элемента
            {
                if (current.Data.CompareTo(current.Next.Data) <= 0)
                {
                    current = current.Next; // если порядок правильный, идем дальше
                }
                else
                {
                    // если порядок неправильный, меняем значения местами
                    T temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;

                    // возвращаемся к началу списка после обмена
                    current = head;
                }
            }

            OnChange(EventArgs.Empty); // уведомляем об изменении
        }
    }
    
}
