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

            ZobrazitTabulkuNejHracu();

            while (stavHry == StavHry.Bezi)
            {
                //SmazatObrazovku();
                //ZobrazitNadpis();

                //ZobrazitHerniPlochu();
                //ZobrazitKurzor();

                //stavHry = InterakceSUzivatelem();
            }

            TimeSpan dobaHry = DateTime.Now - casZacatku;

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
