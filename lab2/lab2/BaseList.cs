using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public abstract class BaseList
    {
        protected int count;
        public int Count { get { return count; } }
        public abstract void Add(int a);
        public abstract void Insert(int pos, int a);
        public abstract void Delete(int pos);
        public abstract void Clear();
        public abstract int this[int i] { set; get; }
        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(this[i] + " ");
            }
            Console.WriteLine();
        }

        public void Assign(BaseList source)
        {
            Clear();
            for (int i = 0; i < source.Count; i++)
            {
                Add(source[i]);
            }
        }


        public void AssignTo(BaseList test)
        {
            test.Clear();
            for (int i = 0; i < Count; i++)
            {
                test.Add(this[i]);
            }
        }
        
        protected abstract BaseList EmptyClone();

        public BaseList Clone()
        {
            BaseList clone = EmptyClone();
            clone.Assign(this);
            return clone;
        }

        public virtual void Sort()
        {
            for (int i = 0; i < Count; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (this[i] > this[j])
                    {
                        int t = this[i];
                        this[i] = this[j];
                        this[j] = t;
                    }
                }
            }
        }


        public virtual bool Equal(BaseList other)
        {
            if (other == null || !(other is BaseList))
            {
                return false;
            }
            
            BaseList llist = (BaseList)other;
            
            if (this.Count != llist.Count)
            {
                return false;
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] != llist[i])
                {
                    return false;
                }
            }

            return true;

        }
    }
}
