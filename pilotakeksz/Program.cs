namespace pilotakeksz
{
    internal class Program
    {
        internal class Versenyzo
        {
            public string nev;
            public string szuletesiEv;
            public string nemzetiseg;
            public int rajtszam;

            public Versenyzo(string nev, string szuletesiEv, string nemzetiseg, int rajtszam)
            {
                this.nev = nev;
                this.szuletesiEv = szuletesiEv;
                this.nemzetiseg = nemzetiseg;
                this.rajtszam = rajtszam;
            }


        }

        static void Main(string[] args)
        {

            //Versenyzo versenyzok;
            //versenyzok = new Versenyzo("Teszt Elek", "1990.05.15", "HUN", 27);  

            //versenyzok.rajtszam = 99;    



            //Console.WriteLine("Hello, World!");
            List<Versenyzo> versenyzok = new();

            versenyzok = Olvaso();

            Szamlalo(versenyzok);
            UtolsoSor(versenyzok);
            XIXElott(versenyzok);
            LegkisebbRajtszam(versenyzok);
            RajtszamokDuplikalasa(versenyzok);

            Console.WriteLine("\nKiegészítés\n");

            MindenEvbenSzuletettE(versenyzok);
            HonapokSzuletesei(versenyzok);

        }

        static List<Versenyzo> Olvaso()
        {
            StreamReader sr = new StreamReader("pilotak.csv");
            List<Versenyzo> versenyzok = new List<Versenyzo>();
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                if (adatok[3] == "")
                {
                    Versenyzo v = new Versenyzo(adatok[0], adatok[1], adatok[2], -1);
                    versenyzok.Add(v);
                }
                else
                {
                    Versenyzo v = new Versenyzo(adatok[0], adatok[1], adatok[2], Convert.ToInt32(adatok[3]));
                    versenyzok.Add(v);
                }
            }
            return versenyzok;
        }

        static void Szamlalo(List<Versenyzo> versenyzok)
        {
            int count = 0;
            foreach (var v in versenyzok) count++;
            Console.WriteLine($"3. Feladat: {count}");
        }
        static void UtolsoSor(List<Versenyzo> versenyzok)
        {
            Console.WriteLine($"4. Feladat: {versenyzok[versenyzok.Count - 1].nev}");
        }
        static void XIXElott(List<Versenyzo> versenyzok)
        {
            Console.WriteLine("5. Feladat:");
            foreach (var v in versenyzok)
            {
                if (Convert.ToInt32(v.szuletesiEv.Split(".")[0]) < 1901)
                {
                    Console.WriteLine($"\t{v.nev} ({v.szuletesiEv}.)");
                }
            }
        }
        static void LegkisebbRajtszam(List<Versenyzo> versenyzok)
        {
            int minRajtszam = int.MaxValue;
            string nemzetiseg = "";
            foreach (var v in versenyzok)
            {
                if (v.rajtszam < minRajtszam && v.rajtszam!=-1)
                {
                    minRajtszam = v.rajtszam;
                    nemzetiseg = v.nemzetiseg;
                }
            }
            Console.WriteLine($"6. Feladat: {nemzetiseg}");
        }
        static void RajtszamokDuplikalasa(List<Versenyzo> versenyzok)
        {
            var rajtszamok = new HashSet<int>();
            var duplikaltRajtszamok = new HashSet<int>();
            foreach (Versenyzo obj in versenyzok)
            {
                if (!rajtszamok.Add(obj.rajtszam) && obj.rajtszam !=-1)
                {
                    duplikaltRajtszamok.Add(obj.rajtszam);
                }
            }
            Console.Write("7. feladat: ");
            if (duplikaltRajtszamok.Count > 0)
            {
                
                foreach (var rajtszam in duplikaltRajtszamok)
                {
                    Console.Write($"{rajtszam},");
                }
            }
            else
            {
                Console.Write("Nincs duplikált rajtszám.");
            }
            Console.WriteLine();
        }
        static void MindenEvbenSzuletettE(List<Versenyzo> versenyzok)
        {
            Dictionary<int, int> evSzuletesek = new Dictionary<int, int>();
            foreach (var v in versenyzok)
            {
                int ev = Convert.ToInt32(v.szuletesiEv.Split(".")[0]);
                if (evSzuletesek.ContainsKey(ev))
                {
                    evSzuletesek[ev]++;
                }
                else
                {
                    evSzuletesek[ev] = 1;
                }
            }

            foreach (var ev in evSzuletesek.Keys)
            {
                Console.WriteLine($"{ev} : {evSzuletesek[ev]}");
            }
        }
        static void HonapokSzuletesei(List<Versenyzo> versenyzok)
        {
            StreamWriter Januar = new StreamWriter("01.txt");
            StreamWriter Februar = new StreamWriter("02.txt");
            StreamWriter Marcius = new StreamWriter("03.txt");
            StreamWriter Aprilis = new StreamWriter("04.txt");
            StreamWriter Majus = new StreamWriter("05.txt");
            StreamWriter Junius = new StreamWriter("06.txt");
            StreamWriter Julius = new StreamWriter("07.txt");
            StreamWriter Augusztus = new StreamWriter("08.txt");
            StreamWriter Szeptember = new StreamWriter("09.txt");
            StreamWriter Oktober = new StreamWriter("10.txt");
            StreamWriter November = new StreamWriter("11.txt");
            StreamWriter December = new StreamWriter("12.txt");

            //StreamWriter[] streamWriters = 

            foreach (var versenyzo in versenyzok)
            {
                string honap = versenyzo.szuletesiEv.Split(".")[1];
                switch(honap)
                {
                    case "01":
                        Januar.WriteLine($"{versenyzo.nev};{versenyzo.nemzetiseg}");
                        break;
                    case "02":
                        Februar.WriteLine($"{versenyzo.nev};{versenyzo.nemzetiseg}");
                        break;
                    case "03":
                        Marcius.WriteLine($"{versenyzo.nev};{versenyzo.nemzetiseg}");
                        break;
                    case "04":
                        Aprilis.WriteLine($"{versenyzo.nev};{versenyzo.nemzetiseg}");
                        break;
                    case "05":
                        Majus.WriteLine($"{versenyzo.nev};{versenyzo.nemzetiseg}");
                        break;
                    case "06":
                        Junius.WriteLine($"{versenyzo.nev};{versenyzo.nemzetiseg}");
                        break;
                    case "07":
                        Julius.WriteLine($"{versenyzo.nev};{versenyzo.nemzetiseg}");
                        break;
                    case "08":
                        Augusztus.WriteLine($"{versenyzo.nev};{versenyzo.nemzetiseg}");
                        break;
                    case "09":
                        Szeptember.WriteLine($"{versenyzo.nev};{versenyzo.nemzetiseg}");
                        break;
                    case "10":
                        Oktober.WriteLine($"{versenyzo.nev};{versenyzo.nemzetiseg}");
                        break;
                    case "11":
                        November.WriteLine($"{versenyzo.nev};{versenyzo.nemzetiseg}");
                        break;
                    case "12":
                        December.WriteLine($"{versenyzo.nev};{versenyzo.nemzetiseg}");
                        break;
                }
            }



            Januar.Close();
            Februar.Close();
            Marcius.Close();
            Aprilis.Close();
            Majus.Close();
            Junius.Close();
            Julius.Close();
            Augusztus.Close();
            Szeptember.Close();
            Oktober.Close();
            November.Close();
            December.Close();

        }
    }

}
