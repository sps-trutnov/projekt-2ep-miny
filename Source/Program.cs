namespace Miny
{
    internal class Program
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

        static int[,] MinovePole;
        static TypPolicka[,] Maska;

        static int KurzorX = 0;
        static int KurzorY = 0;

        static void Main(string[] args)
        {
            MinovePole = new int[SirkaHerniPlochy, VyskaHerniPlochy];
            Maska = new TypPolicka[SirkaHerniPlochy, VyskaHerniPlochy];


            StavHry stavHry = StavHry.Bezi;
            DateTime casZacatku = DateTime.Now;

            TimeSpan dobaHry = DateTime.Now - casZacatku;

            ZobrazitDobuProbehleHry(dobaHry);
            ZobrazitTabulkuNejHracu();
            ZapisDoTabulkyNejHracu(dobaHry);
            ZobrazitTabulkuNejHracu();

            while (stavHry == StavHry.Bezi)
            {
                //SmazatObrazovku();
                //ZobrazitNadpis();

                //ZobrazitHerniPlochu();
                //ZobrazitKurzor();

                //stavHry = InterakceSUzivatelem();
            }


            ZobrazitRozlouceni();
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
            string[] lines = System.IO.File.ReadAllLines(@"TabulkaNejHracu.txt");

            string[] jmena = new string[lines.Length];
            string[] casy = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] polozky = lines[i].Split(" ");
                jmena.Append(polozky[0]);
                casy.Append(polozky[1]);
            }
            Console.WriteLine(jmena);
            Console.WriteLine(casy);

            int mujCas = 5;
            int[] tabHracu;
            tabHracu = new int[] { 1, 2, 3, 6, 9 };

            //   prvni proměnná; jak dlouho; i++ aby se postupně vše projelo
            for (int i = 0; i < tabHracu.Length; i++)
            {
                if (mujCas < tabHracu[i])
                {
                    for (int p = i; p < tabHracu.Length - 1; p++)
                    {
                        int zachrana = tabHracu[p];
                        tabHracu[p + 1] = zachrana;
                    }
                    tabHracu[i] = mujCas;
                    break;
                }
            }
            for (int i = 0; i < tabHracu.Length; i++)
            {
                Console.WriteLine(tabHracu[i]);
            }



            Console.Write("Zadejte své jméno: ");
            string zadani = Console.ReadLine();

            
            string[] nejlepsiHraci =
            
            {
                
                zadani + " " + dobaHry,
            };

            File.WriteAllLines(@"TabulkaNejHracu.txt", nejlepsiHraci);
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
            Console.WriteLine("Děkujeme za zahrání!");
            Console.WriteLine();
            Console.WriteLine("Stiskněte libovolnou klávesu pro ukončení...");
            Console.CursorVisible = false;
            Console.ReadKey();
        }
    }
}
