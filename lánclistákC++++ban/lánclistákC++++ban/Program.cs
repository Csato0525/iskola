using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lánclistákC____ban
{
    class Program
    {
        class Lancoltlista
        {
            class Elem
            {
                public Elem bal;
                public int ertek;
                public Elem jobb;
                public Elem(Elem b, int e, Elem j)
                {
                    this.bal = b;
                    this.jobb = j;
                    this.ertek = e;
                }
                public Elem()
                {
                    bal = this;
                    //ertek
                    jobb = this;

                }
                public Elem(Elem ezele, int e)
                {
                    this.jobb = ezele;
                    this.bal = ezele.bal;
                    ezele.bal.jobb = this;
                    ezele.bal = this;
                    this.ertek = e;
                }
            }
            //public int GetCount() => Count;
            private int count = 0;
            
            public int Count { get { return count; }  }


            Elem fejelem = new Elem();
            //public uint count = 0;



            public void Add(int szam)
            {
                //Elem ujelem = new Elem(fejelem, szam);
                new Elem(fejelem, szam);
                count++;
            }
            public void Kiír() { Console.WriteLine(this.ToString()); }

            public override string ToString()
            {
                string str = "";
                Elem aktelem = fejelem.jobb;
                while (aktelem != fejelem)
                {

                    str+=$"{aktelem.ertek} ";
                    aktelem = aktelem.jobb;
                }
                return str;
            }

            public bool Empty()
            {
                return fejelem.jobb != fejelem;
            }

            private Elem Helye(int e)
            {
                Elem aktelem = fejelem.jobb; // i=0
                while (aktelem != fejelem && aktelem.ertek != e) // lista.count feltetel
                {
                    aktelem = aktelem.jobb; // i++

                }
                return aktelem;
            }

            /// <summary>
            /// Az első előfordulást kiszedi
            /// </summary>
            /// <param name="ertek">az eltavolandító elem</param>
            public void Remove(int e)
            {
                if (!Empty())
                {
                    Elem aktelem = Helye(e);
                    //memory leak , server problemak
                    aktelem.bal.jobb = aktelem.jobb;
                    aktelem.jobb.bal = aktelem.bal;
                    count--;
                }
            }
            //
            public void RemoveAt(int e)
            {
                int i = 0;

                if (i != e)
                {
                    i++;
                }
                else
                {
                    Remove(i);
                }
            }
            //

            public bool Contains(int e)
            {
                return Helye(e) != fejelem;
            }

            private Elem GetElemByIndex(int i)
            {
                if (i < 0)
                {
                    Console.WriteLine("pizitiv index");
                    throw new IndexOutOfRangeException();
                    //return -1;

                }
                if (i >= count)
                {
                    Console.WriteLine("tul nagy index");
                    throw new IndexOutOfRangeException();
                }

                Elem aktelem = fejelem.jobb;
                for (int j = 0; j < i; j++)
                {
                    aktelem = aktelem.jobb;
                }
                return aktelem;
            }

            public void SetByIndex(int i, int e)
            {
                GetElemByIndex(i).ertek = e;
            }
            public int GetByIndex(int i) => GetElemByIndex(i).ertek;
            public int this[int i]
            {
                get => GetElemByIndex(i).ertek;
                set { GetElemByIndex(i).ertek = value; }
            }
        }



        
        static void Main(string[] args)
        {

            Lancoltlista lista = new Lancoltlista();
            lista.Add(5);
            lista.Add(6);
            lista.Add(7);

            //lista.Kiír();
            Console.WriteLine(lista);

            Console.WriteLine(lista.Count);

            lista.Remove(6);

            Console.WriteLine(lista);

            Console.WriteLine(lista.Count);
            Console.WriteLine("Hetes benne van?");
            Console.WriteLine(lista.Contains(7));
            //int i = 2;
            //Console.WriteLine(lista.GetByIndex(i));


            /** /
            Elem aktelem = fejelem.jobb;
            while (aktelem != fejelem)
            {

                Console.Write($"{aktelem.ertek} ");
                aktelem = aktelem.jobb;
            }

            Console.WriteLine();
            /**/
            /** /
            Elem f = new Elem();
            Elem e1 = new Elem();
            Elem e2 = new Elem();
            Elem e3 = new Elem();

            f.bal = e3;
            f.jobb = e1;

            e1.bal = f;
            e1.ertek = 2;
            e1.jobb = e2;
            
            e2.bal = e1;
            e2.ertek = 3;
            e2.jobb = e3;

            e3.bal = e2;
            e3.ertek = 5;
            e3.jobb = f;

            Console.WriteLine(f.jobb.jobb.jobb.ertek);

            // Új elemet adunk hozzá!
            Elem e4 = new Elem(e3, 8, f);
            /** /
            e4.ertek = 8;
            e4.bal = e3;
            e4.jobb = f;
            
            e3.jobb = e4;
            f.bal = e4;

            Elem e5 = new Elem(e4, 13);

            Console.WriteLine(f.ertek);
            Console.WriteLine(f.jobb.ertek);
            Console.WriteLine(f.jobb.jobb.ertek);
            Console.WriteLine(f.jobb.jobb.jobb.ertek);
            Console.WriteLine(f.jobb.jobb.jobb.jobb.ertek);
            Console.WriteLine(f.jobb.jobb.jobb.jobb.jobb.ertek);
            /**/
            lista.RemoveAt(1);
            Console.WriteLine(lista);
        }
    }
}
