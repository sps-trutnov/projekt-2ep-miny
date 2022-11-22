namespace Miny
{
    class Program
    {
        // vyctovy datovy typ
        enum TypPolicka
        {
            Zakryte,
            Odkryte,
            Vlajka,
        }

        enum StavHry
        {
            Bezi,
            Vyhra,
            Prohra,
        }

        static readonly int SirkaHerniPlochy = 9;
        static readonly int VyskaHerniPlochy = 9;

        static readonly int PocetMin = 10;

        static int[,] MinovePole;
        static TypPolicka[,] Maska;

        static int KurzorX = 0;
        static int KurzorY = 0;

        static void Main(string[] args)
        {
            VygenerovatHerniPlochu();

            DateTime casZacatku = DateTime.Now;
            StavHry stavHry = StavHry.Bezi;

            while (stavHry == StavHry.Bezi)
            {
                SmazatObrazovku();
                ZobrazitNadpis();

                ZobrazitHerniPlochu();

                stavHry = InterakceSUzivatelem();
            }

            TimeSpan dobaHry = DateTime.Now - casZacatku;

            OkdrytHerniPlochu();

            ZobrazitNadpis();
            ZobrazitHerniPlochu();

            Console.WriteLine();
            Console.WriteLine($"Hra skončila {(stavHry == StavHry.Vyhra ? "výhrou" : "prohrou")}.");
            Console.WriteLine();
            Console.WriteLine("Stiskněte <ENTER> pro pokračování...");
            Console.ReadLine();
            Console.Clear();

            ZobrazitNadpis();
            ZobrazitTabulkuNejHracu();

            if (stavHry == StavHry.Vyhra)
            {
                ZobrazitDobuProbehleHry(dobaHry);
                ZapisDoTabulkyNejHracu(dobaHry);
            }

            ZobrazitRozlouceni();
        }

        static void VygenerovatHerniPlochu()
        {
            MinovePole = new int[SirkaHerniPlochy, VyskaHerniPlochy];
            Maska = new TypPolicka[SirkaHerniPlochy, VyskaHerniPlochy];

            Random nahoda = new Random();
            int z = 0;
            while (z < PocetMin)
            {
                int Random_x = nahoda.Next(MinovePole.GetLength(0));
                int Random_y = nahoda.Next(MinovePole.GetLength(1));
                if (MinovePole[Random_x, Random_y] != -1)
                {
                    MinovePole[Random_x, Random_y] = -1;
                    z++;
                }
            }

            for (int a = 0; a < MinovePole.Length; a++)
            {
                int x = a % VyskaHerniPlochy;
                int y = a / SirkaHerniPlochy;
                if (MinovePole[(x % SirkaHerniPlochy), y] != -1)
                {
                    if (y != 0 && y % VyskaHerniPlochy != VyskaHerniPlochy - 1)
                    {
                        if (x % SirkaHerniPlochy != 0 && x % SirkaHerniPlochy != SirkaHerniPlochy - 1)
                        {
                            if (MinovePole[x + 1, y] == -1) MinovePole[x, y]++;
                            if (MinovePole[x - 1, y] == -1) MinovePole[x, y]++;
                            if (MinovePole[x, y - 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x + 1, y - 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x - 1, y - 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x, y + 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x + 1, y + 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x - 1, y + 1] == -1) MinovePole[x, y]++;
                        }
                        else if (x % SirkaHerniPlochy == 0)
                        {
                            if (MinovePole[x + 1, y] == -1) MinovePole[x, y]++;
                            if (MinovePole[x, y - 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x + 1, y - 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x, y + 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x + 1, y + 1] == -1) MinovePole[x, y]++;
                        }
                        else if (x % SirkaHerniPlochy == SirkaHerniPlochy - 1)
                        {
                            if (MinovePole[x - 1, y] == -1) MinovePole[x, y]++;
                            if (MinovePole[x, y - 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x - 1, y - 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x, y + 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x - 1, y + 1] == -1) MinovePole[x, y]++;
                        }
                    }
                    else if (y == 0)
                    {
                        if (x % SirkaHerniPlochy != 0 && x % SirkaHerniPlochy != SirkaHerniPlochy - 1)
                        {
                            if (MinovePole[x + 1, y] == -1) MinovePole[x, y]++;
                            if (MinovePole[x - 1, y] == -1) MinovePole[x, y]++;
                            if (MinovePole[x, y + 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x + 1, y + 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x - 1, y + 1] == -1) MinovePole[x, y]++;
                        }
                        else if (x % SirkaHerniPlochy == 0)
                        {
                            if (MinovePole[x + 1, y] == -1) MinovePole[x, y]++;
                            if (MinovePole[x, y + 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x + 1, y + 1] == -1) MinovePole[x, y]++;
                        }
                        else if (x % SirkaHerniPlochy == SirkaHerniPlochy - 1)
                        {
                            if (MinovePole[x - 1, y] == -1) MinovePole[x, y]++;
                            if (MinovePole[x, y + 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x - 1, y + 1] == -1) MinovePole[x, y]++;
                        }
                    }
                    else if (y % SirkaHerniPlochy == SirkaHerniPlochy - 1)
                    {
                        if (x % SirkaHerniPlochy != 0 && x % SirkaHerniPlochy != SirkaHerniPlochy - 1)
                        {
                            if (MinovePole[x + 1, y] == -1) MinovePole[x, y]++;
                            if (MinovePole[x - 1, y] == -1) MinovePole[x, y]++;
                            if (MinovePole[x, y - 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x + 1, y - 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x - 1, y - 1] == -1) MinovePole[x, y]++;
                        }
                        else if (x % SirkaHerniPlochy == 0)
                        {
                            if (MinovePole[x + 1, y] == -1) MinovePole[x, y]++;
                            if (MinovePole[x, y - 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x + 1, y - 1] == -1) MinovePole[x, y]++;
                        }
                        else if (x % SirkaHerniPlochy == SirkaHerniPlochy - 1)
                        {
                            if (MinovePole[x - 1, y] == -1) MinovePole[x, y]++;
                            if (MinovePole[x, y - 1] == -1) MinovePole[x, y]++;
                            if (MinovePole[x - 1, y - 1] == -1) MinovePole[x, y]++;
                        }
                    }
                }
            }
        }

        static void ZobrazitTabulkuNejHracu()
        {
            string[] lines = System.IO.File.ReadAllLines(@"TabulkaNejHracu.txt");

            System.Console.WriteLine("Nejlepší hráči: ");
            int Misto;
            Misto = 1;
            foreach (string line in lines)
            {
                Console.WriteLine(Misto + ". " + line);
                Misto = Misto + 1;
            }
            Console.WriteLine();
        }

        static void ZobrazitDobuProbehleHry(TimeSpan dobaHry)
        {
            Console.WriteLine("Hru jsi dohrál za: " + dobaHry);
            Console.WriteLine();
        }

        static void ZapisDoTabulkyNejHracu(TimeSpan dobaHry)
        {
            string[] lines = File.ReadAllLines(@"TabulkaNejHracu.txt");
            string[] jmena = new string[lines.Length];
            string[] casy = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] polozky = lines[i].Split(" ");
                jmena[i] = polozky[0];
                casy[i] = polozky[1];
            }

            for (int i = 0; i < casy.Length; i++)
            {
                string[] hodinyMinutyNeceleSekundy = casy[i].Split(":");
                string[] sekundyMilisekundy = hodinyMinutyNeceleSekundy[2].Split(".");

                int hodiny = Convert.ToInt32(hodinyMinutyNeceleSekundy[0]);
                int minuty = Convert.ToInt32(hodinyMinutyNeceleSekundy[1]);
                int sekundy = Convert.ToInt32(sekundyMilisekundy[0]);
                int milisekundy = Convert.ToInt32(sekundyMilisekundy[1]);

                TimeSpan dobaHraniHraceVTabulce = new TimeSpan(0, hodiny, minuty, sekundy, milisekundy);

                if (dobaHry < dobaHraniHraceVTabulce)
                {
                    string herniCas = dobaHry.ToString();

                    for (int p = casy.Length - 2; p >= i; p--)
                    {
                        casy[p + 1] = casy[p];
                        jmena[p + 1] = jmena[p];
                    }
                    casy[i] = herniCas;

                    Console.Write("Zadejte své jméno: ");
                    string zadani = Console.ReadLine();
                    jmena[i] = zadani;

                    string[] nejlepsiHraci = new string[casy.Length];
                    for (int k = 0; k < casy.Length; k++)
                    {
                        nejlepsiHraci[k] = jmena[k] + " " + casy[k];
                    }

                    File.WriteAllLines(@"TabulkaNejHracu.txt", nejlepsiHraci);
                    break;
                }
            }
        }

        static void ZobrazitHerniPlochu()
        {
            for (int pocitacka_radku = 0; pocitacka_radku < VyskaHerniPlochy; pocitacka_radku++)
            {
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+");

                for (int pocitacka_pozic = 0; pocitacka_pozic < SirkaHerniPlochy; pocitacka_pozic++)
                {
                    Console.Write("|");

                    if (KurzorX == pocitacka_pozic && KurzorY == pocitacka_radku)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }

                    string znak;
                    if (Maska[pocitacka_radku, pocitacka_pozic] == TypPolicka.Zakryte)
                    {
                        znak = "#";
                    }
                    else if (Maska[pocitacka_radku, pocitacka_pozic] == TypPolicka.Vlajka)
                    {
                        znak = "F";
                    }
                    else if (MinovePole[pocitacka_radku, pocitacka_pozic] == -1)
                    {
                        znak = "M";
                    }
                    else
                    {
                        znak = Convert.ToString(MinovePole[pocitacka_radku, pocitacka_pozic]);
                    }
                    Console.Write(znak);
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+");
        }

        static StavHry InterakceSUzivatelem()
        {
            Console.WriteLine("Šipky = pohyb");
            Console.WriteLine("Enter = odkrýt");
            Console.WriteLine("V = vlajka");

            ConsoleKeyInfo klavesa = Console.ReadKey();

            if (klavesa.Key == ConsoleKey.RightArrow)
            {
                Console.Clear();
                Console.WriteLine("Pravá klávesa");
                if (KurzorX < MinovePole.GetLength(1) - 1 && KurzorX >= 0)
                {
                    KurzorX += 1;
                }
            }

            if (klavesa.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            if (klavesa.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
                Console.WriteLine("Levá klávesa");
                if (KurzorX <= MinovePole.GetLength(1) && KurzorX > 0)
                {
                    KurzorX -= 1;
                }
            }

            if (klavesa.Key == ConsoleKey.DownArrow)
            {
                Console.Clear();
                Console.WriteLine("Dolní klávesa");
                if (KurzorY < MinovePole.GetLength(0) - 1 && KurzorY >= 0)
                {
                    KurzorY += 1;
                }
            }

            if (klavesa.Key == ConsoleKey.UpArrow)
            {
                Console.Clear();
                Console.WriteLine("Horní klávesa");
                if (KurzorY <= MinovePole.GetLength(0) && KurzorY > 0)
                {
                    KurzorY -= 1;
                }
            }

            if (klavesa.Key == ConsoleKey.V)
            {
                Console.Clear();
                Console.WriteLine("v");
                if (Maska[KurzorY, KurzorX] == TypPolicka.Zakryte)
                {
                    Maska[KurzorY, KurzorX] = TypPolicka.Vlajka;
                }
                else if (Maska[KurzorY, KurzorX] == TypPolicka.Vlajka)
                {
                    Maska[KurzorY, KurzorX] = TypPolicka.Zakryte;
                }
            }

            if (klavesa.Key == ConsoleKey.Enter)
            {
                Console.Clear();

                if (Maska[KurzorY, KurzorX] == TypPolicka.Zakryte)
                {
                    Maska[KurzorY, KurzorX] = TypPolicka.Odkryte;
                    if (MinovePole[KurzorY, KurzorX] == -1)
                    {

                        return StavHry.Prohra;
                    }
                }
            }
            else
            {
                Console.Clear();
            }

            for (int x = 0; x < MinovePole.GetLength(1); x++)
            {
                for (int y = 0; y < MinovePole.GetLength(0); y++)
                {
                    if (MinovePole[y, x] == 0 && Maska[y, x] != TypPolicka.Odkryte)
                    {
                        return StavHry.Bezi;
                    }

                    if (MinovePole[y, x] == -1 && Maska[y, x] != TypPolicka.Vlajka)
                    {
                        return StavHry.Bezi;
                    }
                }
            }

            return StavHry.Vyhra;
        }

        static void SmazatObrazovku()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }

        static void ZobrazitNadpis()
        {
            Console.WriteLine(" ASCII Miny ");
            Console.WriteLine(" ---------- ");
            Console.WriteLine();
        }

        static void ZobrazitRozlouceni()
        {
            Console.WriteLine();
            Console.WriteLine("Děkujeme za zahrání!");
            Console.WriteLine();
            Console.WriteLine("Stiskněte libovolnou klávesu pro ukončení...");
            Console.CursorVisible = false;
            Console.ReadKey();
        }

        static void OkdrytHerniPlochu()
        {
            for (int x = 0; x < Maska.GetLength(1); x++)
            {
                for (int y = 0; y < Maska.GetLength(0); y++)
                {
                    Maska[y, x] = TypPolicka.Odkryte;
                }
            }
        }
    }
}
