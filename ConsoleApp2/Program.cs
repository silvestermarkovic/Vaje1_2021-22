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
            
            // A
            int minvred = 100;
            int maxvred = 200;
            /*
            Console.WriteLine("Naključna števila med {0} in {1}", minvred, maxvred);
            Console.WriteLine(vrniNakljucnoStevilo(minvred, maxvred));
            Console.WriteLine(vrniNakljucnoStevilo(minvred, maxvred));
            Console.WriteLine(vrniNakljucnoStevilo(minvred, maxvred));

            Console.WriteLine("Naključna števila med -10 in 20");
            Console.WriteLine(vrniNakljucnoStevilo(-10, 20));
            Console.WriteLine(vrniNakljucnoStevilo(-10, 20));
            Console.WriteLine(vrniNakljucnoStevilo(-10, 20));
            
            Console.WriteLine("Naključna števila med 0 in 10");
            Console.WriteLine(String.Format("{0,15:N9}", vrniNakljucnoStevilo(0, 10)));
            Console.WriteLine(String.Format("{0,15:N9}", vrniNakljucnoStevilo(0, 10)));
            Console.WriteLine(String.Format("{0,15:N9}", vrniNakljucnoStevilo(0, 10)));

            Console.ReadKey();
            //System.Environment.Exit(1);
            */

            string imeDatoteke;
            Console.WriteLine("Vnesite ime datoteke (npr. test.txt)!");
            imeDatoteke = Console.ReadLine();

            Console.ReadKey();
            //če datoteka ne obstaja kreiramo vsebino
            if (!File.Exists(imeDatoteke)) {
                Console.WriteLine("Datoteka ne obstaj: Datoteka bo ustvarjena!");

                kreirajDatotekoZNakljucnimiStevili(imeDatoteke, 10, minvred, maxvred);
                Console.WriteLine("Datoteko ustvarjena!");
            } else
            {
                Console.WriteLine("Datoteko obstaja!");
            }
            //izpišermo vsebino datoteke
       
          
            preberiInIzpisiDatoteko(imeDatoteke);
            Console.WriteLine("Vsebina datoteke: {0:30}", imeDatoteke);

            Console.ReadKey();
            Console.WriteLine("Povprečne vrednosti prebrane datoteke!");

            List<double> seznam = preberiVSeznamDatoteko(imeDatoteke);

            Console.WriteLine("Max: " + seznam.Max() + "   " + String.Format("{0,15:N5}", najvecja(seznam)));
            Console.WriteLine("Min: " + seznam.Min() + String.Format("{0,15:N5}", najmanjsa(seznam)));
            Console.WriteLine("Avg: " + seznam.Average() + String.Format("{0,15:N5}", povprecna(seznam)));
            Console.WriteLine("Sum: " + seznam.Sum());
             
            Console.ReadKey();

            Console.WriteLine("Povprečne vrednosti prebrane datoteke!");
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

        static void kreirajDatotekoZNakljucnimiStevili(string imedatoteke, int stevilo, int minvred, int maxvred)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(imedatoteke))
            {
                //kreiramo 100 naključnih števil
                for (int i = 0; i < stevilo; i++)
                {

                    file.WriteLine(vrniNakljucnoStevilo(minvred, maxvred).ToString());

                }
            }
            
        }
        static List<double> preberiVSeznamDatoteko(string imedatoteke)
        {
            List<double> seznam = new List<double>();

            System.IO.StreamReader datoteka = new System.IO.StreamReader(imedatoteke);
            string vrstica;
            while ((vrstica = datoteka.ReadLine()) != null)
            {
                seznam.Add (Double.Parse(vrstica));
            }

            datoteka.Close();
            return seznam;

        }

        static double najmanjsa(List<double> pseznam)
        {
            double trenMin = 9999999;

            foreach (double vrednost in pseznam)
            {
                trenMin = trenMin > vrednost ? trenMin = vrednost : trenMin;
            }
            return trenMin;
        }
        static double najvecja(List<double> pseznam)
        {
            double trenMax = -9999999;

            foreach (double vrednost in pseznam)
            {
                trenMax = trenMax < vrednost ? trenMax = vrednost : trenMax;
            }
            return trenMax;
        }

        static double povprecna(List<double> pseznam)
        {
            double sestevek = 0;

            foreach (double vrednost in pseznam)
            {
                sestevek += vrednost;
                
            }
            return (pseznam.Count> 0 ? sestevek / pseznam.Count : 0);
        }

    }
}
