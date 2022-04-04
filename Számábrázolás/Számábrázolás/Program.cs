using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Számábrázolás
{
    struct Természetes
    {
        static readonly byte pontosság = 5;

        public sbyte[] t;
        public byte h;
        public byte sz;
        private int v;

        public Természetes(string szöveg)
        {
            this.t = new sbyte[pontosság];
            this.h = Convert.ToByte(szöveg.Length);
            this.sz = 10;

            for (int i = szöveg.Length - 1; 0 <= i; i--)
            {
                t[szöveg.Length - i] = sbyte.Parse(szöveg[i].ToString());
            }
        }
        public Természetes(byte h, sbyte[] t, byte sz)
        {
            this.t = t;
            this.h = h;
            this.sz = sz;
        }
        public Természetes(int szám) : this(szám.ToString()) { }

        public override string ToString()
        {
            string sum = "";
            for (int i = pontosság-1; 0 <= i; i--)
            {
                sum += t[i].ToString();
            }
            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Természetes szam1 = new Természetes(5, new sbyte[] { 1, 5, 6, 4, 2 }, 10);
            Természetes szam2 = new Természetes(65432);
            Természetes szam3 = new Természetes("65432");
            //Számrendszerek megadásával.
            /*
            Természetes szam4 = new Természetes(65432, 12);
            Természetes szam5 = new Természetes("632", 16);
            */



            Console.WriteLine(szam3);
        }
    }
}
