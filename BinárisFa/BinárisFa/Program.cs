using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinárisFa
{
    class Program
    {
        class KeresoFa<T>
        {
            Func<T, T, int> reláció;
            private Elem<T> Gyoker;

            class Elem<T>
            {
                public T ertek { get; set; }
                public Elem<T> bal { get; set; }
                public Elem<T> jobb { get; set; }
                public void HelyezdEl(T dolog)
                {
                    switch (reláció(this.Gyoker.ertek, dolog))
                    {
                        case 0:
                            break;
                        case -1:
                            break;
                        case 1:
                            break;
                    }
                }
            }


            public KeresoFa(Func<T,T,int>rel)
            {
                this.reláció = rel;
            }

            public void Add(T dolog)
            {
                
                    
            }


        }
        static void Main(string[] args)
        {
            KeresoFa<int> halmaz = new KeresoFa<int>((x,y)=> x.CompareTo(y));
            




            Console.WriteLine("Some UK drill for you <3");
            Console.WriteLine("Another day another DRILL for you: Mayhem x Grizzy - Justin Bieber");
        }
    }
}
