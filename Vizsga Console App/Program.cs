    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga_Console_App
{
    class Program
    {
        static List<User> users = new List<User>();
        static void Main(string[] args)
        {
            adatokBeolvasasa();
            feladat01();
            feladat02();
            feladat03();
            feladat04();

            Console.WriteLine("\nProgram vege");
            Console.ReadKey();
        }

        private static void adatokBeolvasasa()
        {
            string inputFajl = "todousers.csv";
            using (StreamReader sr = new StreamReader(inputFajl))
            {
                string sor = null;
                sr.ReadLine();
                while ((sor = sr.ReadLine()) != null)
                {
                    string[] adatok = sor.Split(';');
                    User user = new User();
                    user.user_id = int.Parse(adatok[0]);
                    user.name = adatok[1];
                    user.email = adatok[2];
                    user.birthday = DateTime.Parse(adatok[3]);
                    users.Add(user);
                }
            }
        }

        private static void feladat01()
        {
            Console.WriteLine("\n1. Feladat");
            foreach (User user in users)
            {
                Console.WriteLine($"\tNév: {user.name}\tKora: {user.age}");
            }
        }

        private static void feladat02()
        {
            Console.WriteLine("\n2. Feladat");
            double atlag = users.Average(user => user.age);
            Console.WriteLine($"\tFelhasználók átlag életkora: {atlag.ToString("#,##0.0")}");
        }

        private static void feladat03()
        {
            Console.WriteLine("\n3. Feladat");
            foreach (var item in users.GroupBy(a => a.birthday.Year).Select(b => new { evszam = b.Key, db = b.Count() }))
            {
                Console.WriteLine($"\tÉv: {item.evszam} = {item.db}");
            }
        }

        private static void feladat04()
        {
            Console.WriteLine("\n4. Feladat");
        }
    }
}
