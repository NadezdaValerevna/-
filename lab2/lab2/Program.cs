using System;
using System.Collections;

namespace Lab1
{
    internal class Pr
    {
        static void Main(string[] args)
        {


            ArrList Arr = new ArrList();
            ChainList Chi = new ChainList();
            Random rn = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int a = rn.Next();
                Arr.Add(a);
                Chi.Add(a);

            }

            

            for (int i = 0; i < 10000; i++)
            {
                int a = rn.Next();
                int j = rn.Next(0, 1000);

                int opr = rn.Next(0, 4);

                switch (opr)
                {
                    case 0:
                        Arr.Add(a);
                        Chi.Add(a);
                        break;

                    case 1:
                        Arr.Insert(j, a);// инсерт ошибается
                        Chi.Insert(j, a);
                        break;

                    case 2:
                        Arr.Delete(j);
                        Chi.Delete(j);
                        break;

                    case 3:
                        Arr[j] = a;
                        Chi[j] = a;
                        break;

                }

            }
           
            BaseList NewArr = new ArrList();
            BaseList NewChi = new ChainList();

            NewArr = Arr.Clone();
            NewChi.Assign(Chi);

            NewArr.Sort();
            NewChi.Sort();

            if (Arr.Count != Chi.Count)
            {
                Console.WriteLine("Длина не совпала");


            }
            else
            {
                Console.WriteLine("Длина  совпала");
            }


            for (int c = 0; c < Arr.Count; c++)
            {

                if (Arr[c] != Chi[c])
                {

                    Console.WriteLine("не совпали");
                    Console.WriteLine($"arr[{c}] = {Arr[c]}, chi[{c}] = {Chi[c]}, c = {c}");
                    break;
                }
            }

            if (NewArr.Equal(NewChi))
            {
                Console.WriteLine("+");
            }
            else
            {
                Console.WriteLine("-");
            }
        }
    }

}
