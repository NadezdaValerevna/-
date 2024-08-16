using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics.Metrics;
using System.Net;

namespace Lab1
{
    internal class Pr
    {

        static void Main(string[] args)
        {


            ArrList Arr = new ArrList();
            ChainList Chi = new ChainList();
            Random rn = new Random();

            for (int i = 0; i < 50; i++)
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
                        Arr.Insert(j, a);
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


            
        }
    }
}