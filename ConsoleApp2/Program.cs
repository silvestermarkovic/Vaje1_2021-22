using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            
         
            double minvred = 100;
            double maxvred = 200;


            string ime_datoteke;
            Console.WriteLine("Vnesite ime datoteke (npr. test.txt)!");
            ime_datoteke = Console.ReadLine();

//            Console.WriteLine($"{rnd.NextDouble() * maxvred + minvred}");
  //          Console.WriteLine($"{rnd.Next(0, 10)}");
    //        Console.WriteLine($"{rnd.Next(0, 10)}");

            //če datoteka ne obstaja kreiramo vsebino
            if (!File.Exists(ime_datoteke)) {
                Console.WriteLine("Kreiramo datoteko!");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(ime_datoteke))
                {

                    //kreiramo 100 naključnih števil
                    for (int i = 0; i < 100; i++)
                    {
                        
                            file.WriteLine(vrniNakljucnoStevilo(minvred, maxvred).ToString());
                         
                    }
                }
            } else
            {
                Console.WriteLine("Datoteko obstaja!");
            }
            //izpišermo vsebino datoteke
            preberiInIzpisiDatoteko(ime_datoteke);

            List<double> seznam = preberiVSeznamDatoteko(ime_datoteke);

            Console.WriteLine("Max: " + seznam.Max());
            Console.WriteLine("Min: " + seznam.Min());
            Console.WriteLine("Avg: " + seznam.Average());
            Console.WriteLine("Sum: " + seznam.Sum());

             

            //shranimo v seznam
            List<double> seznam1 = seznam.Where(e => (e > seznam.Average())).ToList();
            foreach (double stevilo in seznam1)
            {
                Console.WriteLine($"{stevilo}");
            }


            Console.ReadKey();
            System.Environment.Exit(1);

          
            //vrniNakljucnoStevilo(1, 2);

        }

        static  double vrniNakljucnoStevilo(double p_od, double p_do)
        {
            Random rnd = new Random();
            return (rnd.NextDouble() * (p_do-p_od) + p_od);

        }

        static void preberiInIzpisiDatoteko(string imedatoteke)
        {
            System.IO.StreamReader datoteka = new System.IO.StreamReader(imedatoteke);
            string vrstica = "";
            int i = 0;
            while ((vrstica = datoteka.ReadLine()) != null)
            {

                System.Console.WriteLine(++i + ". " + vrstica);
                 
            }

            datoteka.Close();
        }

        static List<double> preberiVSeznamDatoteko(string imedatoteke)
        {
            List<double> seznam = new List<double>();

            System.IO.StreamReader datoteka = new System.IO.StreamReader(imedatoteke);
            string vrstica;
            while ((vrstica = datoteka.ReadLine()) != null)
            {
                seznam.Add ( Double.Parse(vrstica));
            }

            datoteka.Close();
            return seznam;

        }
        
    }
}
