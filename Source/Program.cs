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

                string[] hodinyMinutyNeceleSekundy = polozky[1].Split(":");
                string[] sekundyMilisekundy = hodinyMinutyNeceleSekundy[2].Split(".");

                Console.WriteLine(hodinyMinutyNeceleSekundy[0]); // hodiny
                Console.WriteLine(hodinyMinutyNeceleSekundy[1]); // minuty
                Console.WriteLine(sekundyMilisekundy[0]); // sekundy
                Console.WriteLine(sekundyMilisekundy[1]); // miliskeundy

                int hodiny = Convert.ToInt32(hodinyMinutyNeceleSekundy[0]);
                int minuty = Convert.ToInt32(hodinyMinutyNeceleSekundy[1]);
                int sekundy = Convert.ToInt32(sekundyMilisekundy[0]);
                int milisekundy = Convert.ToInt32(sekundyMilisekundy[1]);

                TimeSpan dobaHraniHraceVTabulce = new TimeSpan(0, hodiny, minuty, sekundy, milisekundy);

                Console.WriteLine(dobaHraniHraceVTabulce);
                Console.WriteLine();
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
