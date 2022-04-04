using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Új_remény
{
    class Telefon2 : Telefon
    {
        string PUK;
        public Telefon2(string telefonszam, string PIN, string PUK, string tulajdonos) : base(telefonszam, PIN, tulajdonos)
        {
            this.PUK = PUK;
            
        }
        public  override void Tipús_Kiírása()
        {
            Console.WriteLine("Új telefon.");
        }
    }


    class Telefon
    {
        public string telefonszam;
        protected string PIN;
        public string tulajdonos;
        public static List<Telefon> lista = new List<Telefon>();

        public Telefon(string telefonszam, string PIN, string tulajdonos)
        {
            this.telefonszam = telefonszam;
            this.PIN = PIN;
            this.tulajdonos = tulajdonos;

            Telefon.lista.Add(this);
            Console.WriteLine("Létrejött a telefon!");
        }
        public Telefon(string telefonszam) :this(telefonszam, "1234", "")
        {
            
        }
        public override string ToString()
        {
            return $"{tulajdonos} telefonja: {telefonszam}";
        }
        public void Nevvaltoztatas()
        {
            Console.WriteLine("Add meg a PIN kódót!");
            string megadott_pin = Console.ReadLine();
            if (this.PIN == megadott_pin)
            {
                Console.WriteLine("Helyes PIN, adja meg az új nevet!");
                string uj_nev = Console.ReadLine();
                this.tulajdonos = uj_nev;
            }
            else
            {
                Console.WriteLine("Nem a te telód XD");
            }
        }

        

        ~Telefon()
        {
            Console.WriteLine("Elpusztult a telefon!");
        }

        public virtual void Tipús_Kiírása()
        {
            Console.WriteLine("Régi telefon.");
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            ///Telefont csinálunkú
            /// -Egy telefonszám
            /// -pinkód
            /// -tulajdonos
            Telefon telefon1 = new Telefon("0650210210", "1234","Janos");
            Telefon telefon2 = new Telefon("0652131241", "1234","Mákos");
            Telefon telefon3 = new Telefon("0650210210", "1234", "Káros");

            telefon1.Nevvaltoztatas();
            Console.WriteLine(telefon1);
            //Console.WriteLine(telefon.PIN);
            Console.WriteLine(Telefon.lista.Count);
            Telefon2 t2 = new Telefon2("0650210210", "1234", "43211234", "Jeremiás");
            telefon1.Tipús_Kiírása();
            t2.Tipús_Kiírása();
        }


    }
}
