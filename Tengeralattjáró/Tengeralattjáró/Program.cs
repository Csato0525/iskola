using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengeralattjáró
{
    class Tengeralattjáró
    {
        protected int H;
        protected int D;

        public virtual void Forward(int x)
        {

        }
        public virtual void Down(int x)
        {

        }
        public virtual void Up(int x)
        {

        }
        public void Parancs_végrehajtása(string parancs)
        {
            string[] parancssplit = parancs.Split(' ');

            switch (parancssplit[0].ToLower())
            {
                case "forward":
                    Forward(int.Parse(parancssplit[1]));
                    break;
                case "down":
                    Down(int.Parse(parancssplit[1]));
                    break;
                case "up":
                    Up(int.Parse(parancssplit[1]));
                    break;
                default:
                    Console.Error.WriteLine("ezt nem tudom értelmezni :'(");
                    break;
            }
        }

        public void Parancslista_fájlból(string path)
        {
            string[] parancsok = System.IO.File.ReadAllLines(path);
            foreach (string parancs in parancsok)
                Parancs_végrehajtása(parancs);
        }

        public override string ToString() => $"({H};{D}) szorzata: {H * D}";
    }
    class Tengeralattjáró1 : Tengeralattjáró
    {
        public Tengeralattjáró1(int h = 0, int d = 0)
        {
            this.H = h;
            this.D = d;
        }

        private void Forward(int x) => H += x;
        private void Down(int x) => D += x;
        private void Up(int x) => D -= x;

        

    }
    /*_____________________________________________*/
    class Tengeralattjáró2 : Tengeralattjáró
    {
        private int A;
        public Tengeralattjáró2(int h = 0, int d = 0, int a=0)
        {
            this.H = h;
            this.D = d;
            this.A = a;
        }

        private override void Forward(int x)
        {
            D += H;
            A = D * H;
        }
        private override void Down(int x) => D += x;
        private override void Up(int x) => D -= x;
    }


    class Program
    {
        static void Main(string[] args)
        {
            Tengeralattjáró1 gyongy = new Tengeralattjáró1();
            gyongy.Parancslista_fájlból("input.txt");
            Console.WriteLine(gyongy);

            /*____________________*/

            Tengeralattjáró2 Anna = new Tengeralattjáró2();

            

        }
    }
}
