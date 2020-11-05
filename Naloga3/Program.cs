using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace Naloga3
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Zaposleni> seznam = new List<Zaposleni>();

            seznam.Add(new Zaposleni() {id = 1, employee_name = "Naziv 1", employee_age = 45, employee_salary = 30000 });
            seznam.Add(new Zaposleni() { id = 2, employee_name = "Naziv 2", employee_age = 55, employee_salary = 45000 });
            seznam.Add(new Zaposleni() { id = 3, employee_name = "Naziv 3", employee_age = 60, employee_salary = 39000 });
            //TODO: saldjlkasda
            foreach (var zap in seznam)
            {
                Console.WriteLine($"{zap.id} {zap.employee_name }");
            }

            Console.WriteLine("Branje in izpis Json");
            Console.ReadLine();

            string vsebina = Vrnivsebino("http://dummy.restapiexample.com/api/v1/employees");
            

            //vsebina povezave
            Console.WriteLine($"{vsebina}");


            JToken token = JToken.Parse(vsebina);
            JArray zaposleni = (JArray)token.SelectToken("data");
            foreach (JToken zap in zaposleni)
            {
                Console.Write("id: " + zap["id"] + " " + zap["id"] );
                Console.Write(" employee_name: " + zap["employee_name"]);
                Console.Write(" employee_salary: " + zap["employee_salary"]);
                Console.Write(" employee_age: " + zap["employee_age"]);
                Console.WriteLine();



                seznam.Add(new Zaposleni() { id = (int)zap["id"], employee_name = (string)zap["employee_name"],  employee_age = (int)zap["employee_age"], employee_salary = (double)zap["employee_salary"] });

            }

            foreach (Zaposleni zap in seznam)
            {
                Console.WriteLine($"{zap.id},{zap.employee_name},{zap.employee_salary},{zap.employee_age} ");
            }
            Console.WriteLine("Zaposleni s plačo od 10000 do 40000:");
            izpisi_seznam(vrni_zaposlene_filter_placa(seznam, 10000, 40000));


            Console.WriteLine("Zaposleni nad 40let:");
            izpisi_seznam(vrni_zaposlene_filter_starost (seznam, 40, 99999));


            Console.WriteLine("Zaposleni nad 40let Select:");
            var seznam_nad40  = from s in seznam
                                 where s.employee_age >= 40 && s.employee_age < 999999
                                 select s;
            foreach (Zaposleni zap in seznam_nad40)
            {
                Console.WriteLine($"{zap.id},  {zap.employee_name}, {zap.employee_salary}, {zap.employee_age }");
            }

            Console.WriteLine("Zaposleni nad 40let SelectLamda:");
            var seznam_nad40_lamda = seznam.Where(s => s.employee_age > 40 && s.employee_age < 999999);
            foreach (Zaposleni zap in seznam_nad40)
            {
                Console.WriteLine($"{zap.id},  {zap.employee_name}, {zap.employee_salary}, {zap.employee_age }");
            }

            //   Console.WriteLine("Data");
            //  Console.WriteLine($"{json.SelectToken("data")}");

            //  vsebina = json.SelectToken("data").ToString();

            //  JObject json1 = JObject.Parse(vsebina);

            //  Console.WriteLine($"{vsebina}");

            //  Console.WriteLine($"{json1.Count}");

        }


        static string Vrnivsebino(string url)
        {
            string vsebina = "";
            using (var webClient = new System.Net.WebClient())
            {
                vsebina = webClient.DownloadString(url);
            }
        return vsebina;
        }

        static List<Zaposleni> vrni_zaposlene_filter_placa(List<Zaposleni> p_seznam, double placa_od, double placa_do)
        {
            List<Zaposleni> sez = new List<Zaposleni>();

            foreach (Zaposleni zap in p_seznam)
            {
                if (zap.employee_salary >= placa_od && zap.employee_salary<= placa_do)
                {
                    sez.Add(zap);
                }
            }
            return sez;
        }

        static List<Zaposleni> vrni_zaposlene_filter_starost(List<Zaposleni> p_seznam, double starost_od, double starost_do)
        {
            List<Zaposleni> sez = new List<Zaposleni>();

            foreach (Zaposleni zap in p_seznam)
            {
                if (zap.employee_age >= starost_od && zap.employee_age <= starost_do)
                {
                    sez.Add(zap);
                }
            }
            return sez;
        }

        static void izpisi_seznam(List<Zaposleni> p_seznam)
        {
        
            foreach (Zaposleni zap in p_seznam)
            {
                Console.WriteLine($"{zap.id},  {zap.employee_name}, {zap.employee_salary}, {zap.employee_age }");
            }
        }
         
    }
     
}
