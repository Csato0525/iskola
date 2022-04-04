using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPGszimuláció
{
    class Lény
    {
        public string nev;
        public int hp;
        protected int min_dmg;
        protected int max_dmg;
        protected static Random g = new Random();
        public static List<Lény> lista = new List<Lény>();
        public Lény(string nev,int hp, int min_dmg, int max_dmg)
        {
            this.nev = nev;
            this.hp = hp;
            this.min_dmg = min_dmg;
            this.max_dmg = max_dmg;
            Lény.lista.Add(this);
        }
        public override string ToString()
        {
            return $"név: {nev}\n hp:{hp} sebzés:{min_dmg}-{max_dmg}\n";
        }
        public virtual void Attack(Lény ellen)
        {

        }
        public bool Él { get => 0 < hp; }



        public static void Randomsorrend()
        {
            for (int i = 0; i < Lény.lista.Count-1; i++)
            {
                int r = g.Next(i + 1, lista.Count);
                (lista[i], lista[r]) = (lista[r], lista[i]);
            }
        }
    }
    class Barbár : Lény
    {
        bool kipihent;


        public Barbár(string nev,int hp, int min_dmg, int max_dmg): base(nev, hp, min_dmg, max_dmg)
        {
            this.hp = hp;
            this.min_dmg = min_dmg;
            this.max_dmg = max_dmg;
            //---------------------
            kipihent = true;
        }
        public override string ToString()
        {
            return $"kaszt: Barbár\n" +base.ToString();
        }

        public override void Attack(Lény ellen)
        {
            if (kipihent)
            {
                ellen.hp -= g.Next(min_dmg, max_dmg);
                kipihent = false;
            }
            else
            {
                kipihent = true;
            }
        }
    }
    class Mágus : Lény
    {
        public Mágus(string nev, int hp, int min_dmg, int max_dmg) : base(nev, hp, min_dmg, max_dmg)
        {
            this.hp = hp;
            this.min_dmg = min_dmg;
            this.max_dmg = max_dmg;
        }
        public override void Attack(Lény ellen)
        {
            ellen.hp -= g.Next(min_dmg, max_dmg);
        }
    }
    /** /

    class Trubadúr : Lény
    {

    }
    class Gyógyító : Lény
    {

    }
    class Íjász : Lény
    {

    }
    class BBB : Lény
    {

    }
    /**/
    class Program
    {
        static void Main(string[] args)
        {
            Lény Bence = new Lény("Bence",40, 9, 20);
            Barbár Gyuszó = new Barbár("Gyuszó",60, 15, 35);
            Mágus Csege = new Mágus("Csege", 20, 30, 40);

            while (Gyuszó.Él && Csege.Él)
            {
                Lény.Randomsorrend();
                Lény.lista[0].Attack(Lény.lista[1]);
                if (Lény.lista[1].Él)
                {

                }
            }


        }
    }
}
