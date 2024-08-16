using System;
using System.Collections;

namespace DopzadanieNN
{
    public class DZ
    {
        static void Permute(int[] array, int start, int end)
        {
            if (start == end)
            {
                Console.WriteLine(String.Join(",", array));
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    Swap(ref array[start], ref array[i]);
                    Permute(array, start + 1, end);
                    Swap(ref array[start], ref array[i]); 
                }
            }
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
          
            int[] arr = { 1, 2, 3};
            Permute(arr, 0, arr.Length - 1);
        } 
    }
}
