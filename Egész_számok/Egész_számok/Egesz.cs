using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamok
{
    struct Egész
    {
        const int MaxPontosság = 255;
        public bool e { get; set; }
        public Természetes t { get; private set; }
        public int CompareTo(Egész b) => 0;
        static Random r = new Random();
        static int Véletlen_előjel() => (2 * r.Next(2) - 1);
        int ToInt32() => /* ez még nem működik, de könnyen javítható!*/ t.ToInt32();



        public void Diagnosztika(string megj = "")
        {
            Console.WriteLine($"============ szám: {megj} ==============");
            Console.WriteLine(this.ToString());
            Console.WriteLine($"----------------------------------------");
            Console.WriteLine($"előjel: {2}"); // ez még nyilván rossz, javítsd ki!
            Console.WriteLine($"hossz: {t.hossz}");
            Console.WriteLine($"számrendszer: {t.számrendszer}");
            Console.WriteLine($"========================================\n");
        }




        /*
        public static bool Konkrét_Teszt(int ia, int ib, Func<int, int, int> f, Func<Egész, Egész, Egész> g, string megj = "", bool loud = true)
        {
            string hibatípus = "ismeretlen";
            bool megegyezik;
            try
            {
                megegyezik = f(ia, ib) == g(new Egész(ia), new Egész(ib)).ToInt32();
            }
            catch (OverflowException)
            {
                megegyezik = false;
                hibatípus = "túlcsordulási";
            }
            if (loud)
            {
                if (megegyezik)
                    Console.WriteLine($" f({ia},{ib}) = {f(ia, ib)} tesztje sikeres");
                else
                {
                    Console.WriteLine($"{megj} tesztelése során {hibatípus} hiba történt: ");
                    int fiaib = f(ia, ib);
                    (Egész a, Egész b) = (new Egész(ia), new Egész(ib));
                    try
                    {
                        Console.WriteLine($"====== {ia},{ib} esetében int szerint {fiaib} kellett volna legyen. De ehelyett {g(a, b)} lett:");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine($"====== {ia},{ib} esetében int szerint {fiaib} kellett volna legyen. De ehelyett túlcsordult:");
                    }
                    a.Diagnosztika($"a = {ia}");
                    b.Diagnosztika($"b = {ib}");
                    if (hibatípus != "túlcsordulási")
                        new Egész(fiaib).Diagnosztika($"f(a,b) = {f(ia, ib)}");
                    try
                    {
                        g(a, b).Diagnosztika($"g(a,b) = {g(a, b)}");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine($"g(a, b) túlcsordult.");
                    }
                }
            }
            return !megegyezik;
        }
        public static void Teszt(int db, int max, Func<int, int, int> f, Func<Egész, Egész, Egész> g, string megj = "")
        {
            List<(int, int)> hibák = new List<(int, int)>();
            for (int i = 0; i < db; i++)
            {
                int a = Véletlen_előjel() * r.Next(max);
                int b = Véletlen_előjel() * r.Next(max);
                //Console.Error.WriteLine($"Tesztszámok kisorsolva: {a},{b}");
                if (Konkrét_Teszt(a, b, f, g, megj, false))
                    hibák.Add((a, b));
            }
            Console.WriteLine($"{megj} tesztelése során {db} db  [0-{max}) intervallumon való teszt után ennyi hiba történt: {hibák.Count}");
            for (int i = 0; i < hibák.Count; i++)
            {
                Console.WriteLine($"{i + 1}. hiba: ");
                (int ia, int ib) = hibák[i];
                Konkrét_Teszt(ia, ib, f, g, megj, true);
            }
        }
        */
    }
    class Egesz
    {


    }
}
