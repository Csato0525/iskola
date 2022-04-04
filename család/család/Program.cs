using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace család
{
    class Kalap<T>
    {
        Random r = new Random();
        List<T> lista;

        public Kalap(List<T> lista) => this.lista = lista;
        public Kalap() : this(new List<T>()) { }

        public T Peek() => lista[r.Next(lista.Count)];
        public T Pop() => Pop(r.Next(lista.Count));

        private T Pop(int i)
        {
            T result = lista[i];
            lista.RemoveAt(i);
            return result;
        }

        private T Pop(T result)
        {
            lista.Remove(result);
            return result;
        }

        public int Count { get => lista.Count; }

        public void Push(T elem) => lista.Add(elem);
        public void Push(List<T> lista) => this.lista.AddRange(lista);
    }



    class Program
    {
        static void Main(string[] args)
        {

            Kalap<string> család_név_kalap = new Kalap<string>();
            

            string[] család_név;
            //Beolvassuk az összes sort.
            család_név = File.ReadAllLines("veznev.txt");

            for (int i = 0; i < család_név.Length; i++)
            {
                /*Console.WriteLine(név[i]);*/
                család_név_kalap.Push(család_név[i]);
            }


            Kalap<string> egyéni_név_f_kalap = new Kalap<string>();
            string[] egyéni_név_f;

            egyéni_név_f = File.ReadAllLines("sokfiunev.txt");
            for (int i = 0; i < egyéni_név_f.Length; i++)
            {
                egyéni_név_f_kalap.Push(egyéni_név_f[i]);
            }

             
            Kalap<string> egyéni_név_l_kalap = new Kalap<string>();
            string[] egyéni_név_l;
            egyéni_név_l = File.ReadAllLines("soklanynev.txt");
            for (int i = 0; i < egyéni_név_l.Length; i++)
            {
                egyéni_név_l_kalap.Push(egyéni_név_l[i]);
            }

            Console.WriteLine(család_név_kalap.Pop() + egyéni_név_l_kalap.Pop() + egyéni_név_f_kalap.Pop());

            


        }
    }
}
