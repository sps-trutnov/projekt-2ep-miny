using System.Security.AccessControl;

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

        static readonly int SirkaHerniPlochy = 3;
        static readonly int VyskaHerniPlochy = 3;

        static int[,] MinovePole;
        static TypPolicka[,] Maska;

        static int KurzorX = 0;
        static int KurzorY = 0;

        static void Main(string[] args)
        {
            MinovePole = new int[3, 3] {
                { -1, 1, 0 },
                { 1, 1, 0 },
                { 0, 0, 0 }
            };
            Maska = new TypPolicka[3, 3] {
                { TypPolicka.Vlajka, TypPolicka.Odkryte, TypPolicka.Zakryte },
                { TypPolicka.Zakryte, TypPolicka.Odkryte, TypPolicka.Zakryte },
                { TypPolicka.Zakryte, TypPolicka.Zakryte, TypPolicka.Zakryte }
            };



            for (int x = 0; x < 3; x++)
            {
                Console.WriteLine(MinovePole[0, x]);
            }

            System.Environment.Exit(0);

            VygenerovatHerniPlochu();

            StavHry stavHry = StavHry.Bezi;
            DateTime casZacatku = DateTime.Now;

            while (stavHry == StavHry.Bezi)
            {
                SmazatObrazovku();
                ZobrazitNadpis();

                ZobrazitHerniPlochu();
                ZobrazitKurzor();

                stavHry = InterakceSUzivatelem();
            }

            TimeSpan dobaHry = DateTime.Now - casZacatku;

            ZobrazitTabulkuNejHracu();
            ZobrazitDobuProbehleHry(dobaHry);

            if (stavHry == StavHry.Vyhra)
            {
                ZapisDoTabulkyNejHracu(dobaHry);
            }

            ZobrazitRozlouceni();
        }

        static void VygenerovatHerniPlochu()
        {
            throw new NotImplementedException();
        }

        static void ZapisDoTabulkyNejHracu(TimeSpan dobaHry)
        {
            throw new NotImplementedException();
        }

        static void ZobrazitDobuProbehleHry(TimeSpan dobaHry)
        {
            throw new NotImplementedException();
        }

        static void ZobrazitTabulkuNejHracu()
        {
            throw new NotImplementedException();
        }

        static StavHry InterakceSUzivatelem()
        {
            throw new NotImplementedException();
        }

        static void ZobrazitKurzor()
        {
            throw new NotImplementedException();
        }

        static void ZobrazitHerniPlochu()
        {
            throw new NotImplementedException();
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
