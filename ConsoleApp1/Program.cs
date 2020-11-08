using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    
    class Program
    {
        
        static void Main(string[] args)
        {

            int limit = 42;
          
            //1. način
            //kreiramo seznam, s klicem metode, seznam je podan kot parameter
            List<int> seznamOsnovni = new List<int>();
            seznamOsnovni.Add(1);
            seznamOsnovni.Add(1);
            Fibonachi(seznamOsnovni, 0, 1, limit);

            foreach (int element in seznamOsnovni)
            {
                Console.WriteLine($"{element}");
            }
            

            Console.ReadKey();
            System.Environment.Exit(1);
            
            Console.WriteLine("Klic metode, ki vrne seznam:");

            Console.ReadKey();

            List<int> seznamIzMetode = FibonacciList(limit);

            //uporabljen je Lambda
            seznamIzMetode.ForEach(p => Console.WriteLine($"{p}"));

            System.Environment.Exit(1);

            Console.WriteLine("Uporaba Yield Return");
            foreach (var element in FibonachiYield(42))
            {
                Console.WriteLine($"{element}");
            }

        }

        static List<int> FibonacciList(int p_limit)
        {
            List<int> seznam = new List<int>();

            seznam.Add(1);
            seznam.Add(1);

            for (int i = 1; i < 42; i++)
            {
                seznam.Add(seznam.ElementAt(i - 1) + seznam.ElementAt(i));
            }

            return seznam;
        }

        static void Fibonachi(List<int> p_seznam,  int predhodnoStevilo , int trenutnoStevilo, int p_limit)
        {
            //števili, sta podani, kot parametra, vendar bi ju lahko prebrali, tudi iz samega seznama
            //TODO Uporabi metodo ElementAt
            if (p_seznam.Count < p_limit)  {
                p_seznam.Add(predhodnoStevilo + trenutnoStevilo);
                //predhodno število, dobi vrednost trenutnega števila
                //trenutno število, dobi vrednost seštevek trenutnega in predhodnega števila
                Fibonachi(p_seznam, trenutnoStevilo, predhodnoStevilo + trenutnoStevilo, p_limit);
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
