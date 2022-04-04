using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamok
{
    struct Természetes
    {
        const int MaxPontosság = 255;

        public byte hossz { get; private set; }
        public byte számrendszer { get; }
        public sbyte[] jegy { get; private set; }
        public sbyte this[int i]
        {
            get
            {
                try
                {
                    return jegy[i];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new OverflowException();
                }
            }
            set => jegy[i] = value;
        }
        public sbyte this[int i, Természetes a, Természetes b]
        {
            get
            {
                Console.WriteLine($"a,b={a},{b}");
                return jegy[i];
            }
            set => jegy[i] = value;
        }
        static (byte, sbyte[], byte) Számjegyei(int i)
        {
            i = Math.Abs(i);
            byte hossz = 0;
            sbyte[] számjegyek = new sbyte[MaxPontosság];
            while (0 < i)
                (számjegyek[hossz++], i) = ((sbyte)(i % 10), i / 10);
            if (hossz == 0)
                (hossz, számjegyek[0]) = (1, 0);
            return (hossz, számjegyek, 10);
        }
        static (byte, sbyte[], byte) Számjegyei(string s)
        {
            int hossz = s.Length - 1;
            sbyte[] számjegyek = new sbyte[MaxPontosság];
            for (int i = 0; i < hossz; i++)
                számjegyek[i] = sbyte.Parse(s[hossz - i].ToString());
            return (Convert.ToByte(hossz), számjegyek, 10);
        }
        public Természetes(Természetes a) : this(a.hossz, new sbyte[MaxPontosság], a.számrendszer) { a.jegy.CopyTo(jegy, 0); }
        public Természetes(string s) : this(Számjegyei(s)) { }
        public Természetes(int i) : this(Számjegyei(i)) { }
        public Természetes((byte, sbyte[], byte) t) : this(t.Item1, t.Item2, t.Item3) { }
        public Természetes(byte hossz, sbyte[] jegy, byte számrendszer) => (this.hossz, this.számrendszer, this.jegy) = (hossz, számrendszer, jegy);
        public override string ToString()
        {
            string s = "";
            for (int i = hossz - 1; 0 <= i; i--)
                s += this[i].ToString();
            return s;
        }
        public void Kiírás() => Console.WriteLine(ToString());
        public void Diagnosztika(string megj = "")
        {
            Console.WriteLine($"============ szám: {megj} ==============");
            Console.WriteLine(this.ToString());
            Console.WriteLine($"----------------------------------------");
            Console.WriteLine($"hossz: {hossz}");
            Console.WriteLine($"számrendszer: {számrendszer}");
            Console.WriteLine($"========================================\n");
        }
        public int CompareTo(Természetes b)
        {
            if (hossz != b.hossz)
                return hossz < b.hossz ? -1 : 1;
            for (int i = hossz - 1; i >= 0; i--)
                if (this[i] != b[i])
                    return this[i] < b[i] ? -1 : 1;
            return 0;
        }
        public static bool operator ==(Természetes a, Természetes b) => a.CompareTo(b) == 0;
        public static bool operator !=(Természetes a, Természetes b) => a.CompareTo(b) != 0;
        public static bool operator <(Természetes a, Természetes b) => a.CompareTo(b) == -1;
        public static bool operator <=(Természetes a, Természetes b) => a.CompareTo(b) < 1;
        public static bool operator >(Természetes a, Természetes b) => a.CompareTo(b) == 1;
        public static bool operator >=(Természetes a, Természetes b) => a.CompareTo(b) > -1;
        public bool pozitív_átvitel(int innen)
        {
            int jint;
            sbyte átvitel = (sbyte)Math.DivRem(this[innen], számrendszer, out jint);
            bool result = 0 < átvitel;
            if (innen + 1 != MaxPontosság)
                this[innen + 1] += átvitel;
            else if (result)
                throw new OverflowException();
            this[innen] = (sbyte)jint;
            return result;
        }
        public void összeadás_átvitel(int innen)
        {
            if (this[innen] > számrendszer)
            {
                this[innen] -= (sbyte)számrendszer;
                if (innen + 1 != MaxPontosság)
                    this[innen + 1] += 1;
                else
                    throw new OverflowException();
            }
        }
        public static Természetes operator +(Természetes a, Természetes b)
        {
            if (a.hossz < b.hossz)
                return b + a;

            Természetes r = new Természetes(a);
            int i = 0;
            while (i < b.hossz)
            {
                r[i] += b[i];
                r.összeadás_átvitel(i++);
            }

            while (i < r.hossz && r.számrendszer <= r[i])
                r.pozitív_átvitel(i++);

            if (r.hossz < MaxPontosság && r[r.hossz] != 0)
                r.hossz++;

            return r;
        }
        public static Természetes operator *(Természetes a, Természetes b)
        {
            Természetes szorzat = new Természetes(1, new sbyte[MaxPontosság], a.számrendszer);
            int eddig = a.hossz + b.hossz + 1;
            for (int ö = 0; ö < eddig; ö++)
                for (int i = 0; i <= ö; i++)
                {
                    szorzat[ö] += (sbyte)(a[i] * b[ö - i]);
                    szorzat.pozitív_átvitel(ö);
                }
            szorzat.hossz = (byte)(szorzat[eddig - 1] == 0 ? eddig - 1 : eddig);
            return szorzat;
        }
        bool negatív_átvitel(int i)
        {
            if (this[i] < 0)
            {
                this[i] += (sbyte)számrendszer;
                this[i + 1] -= 1;
                return true;
            }
            return false;
        }
        int első_nemnulla_számjegy_helye_innen() { int i = hossz - 1; while (i >= 0 && this[i] == 0) i--; return i; }
        public static Természetes operator -(Természetes a, Természetes b)
        {
            if (a < b)
                return b - a;
            Természetes r = new Természetes(a);
            int i = 0;
            bool van_átvitel = false;
            while (i < b.hossz)
            {
                r[i] -= b[i];
                van_átvitel = r.negatív_átvitel(i++);
            }

            while (van_átvitel)
                van_átvitel = r.negatív_átvitel(i++);

            i = r.első_nemnulla_számjegy_helye_innen();
            r.hossz = (byte)(i == -1 ? 1 : i + 1);

            return r;
        }


        static Random r = new Random();
        public int ToInt32()
        {
            try
            {
                int s = 0;
                for (int i = hossz - 1; i >= 0; i--)
                {
                    s *= 10;
                    s += this[i];
                }
                return s;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Túl nagy a szám ahhoz, hogy meg lehessen jeleníteni!");
                return -1;
                //throw new OverflowException();
            }
        }
        public static bool Konkrét_Teszt(int ia, int ib, Func<int, int, int> f, Func<Természetes, Természetes, Természetes> g, string megj = "", bool loud = true)
        {
            string hibatípus = "ismeretlen";
            bool megegyezik;
            try
            {
                megegyezik = f(ia, ib) == g(new Természetes(ia), new Természetes(ib)).ToInt32();
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
                    (Természetes a, Természetes b) = (new Természetes(ia), new Természetes(ib));
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
                        new Természetes(fiaib).Diagnosztika($"f(a,b) = {f(ia, ib)}");
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
        public static void Teszt(int db, int max, Func<int, int, int> f, Func<Természetes, Természetes, Természetes> g, string megj = "")
        {
            List<(int, int)> hibák = new List<(int, int)>();
            for (int i = 0; i < db; i++)
            {
                int a = r.Next(max);
                int b = r.Next(max);
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
    }
}
