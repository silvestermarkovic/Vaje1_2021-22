using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    
    class Program
    {
        
        static void Main(string[] args)
        {

            int limit = 42;
          
            List<int> seznam = new List<int>();
            seznam.Add(1);
            seznam.Add(1);
           
            Fibonachi(seznam, 0, 1, limit);

            foreach (int element in seznam)
            {
                Console.WriteLine($"{element}");
            }
            

            Console.ReadKey();

            
            foreach (var element in FibonachiYield(42))
            {
                Console.WriteLine($"{element}");
            }

        }

        static void Fibonachi(List<int> p_seznam,  int a , int b, int p_limit)
        {

            if (p_seznam.Count < p_limit)  {

                p_seznam.Add(a + b);
                Fibonachi(p_seznam, b, a + b, p_limit);

            }

        }

        static IEnumerable<int> FibonachiYield(int p_limit)
        {

            int prva = 1;
            int druga = 1;

            for (int i = 0; i < p_limit; i++)
            {
                int sum = prva + druga;
                prva = druga;
                druga = sum;

                yield return sum;

            }
        }
    }
}
