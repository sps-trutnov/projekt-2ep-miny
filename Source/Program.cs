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
            mina,
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
            MinovePole = new int[4, 3] {
                {-1, 0, 0 },
                {0, 0, 0 },
                {-1, -1, 0 },
                {-1, 0, 0 },
            };
            Maska = new TypPolicka[4, 3]
            {
                {TypPolicka.Zakryte, TypPolicka.Zakryte,TypPolicka.Zakryte},
                {TypPolicka.Zakryte, TypPolicka.Zakryte,TypPolicka.Zakryte},
                {TypPolicka.Zakryte, TypPolicka.Zakryte,TypPolicka.Zakryte},
                {TypPolicka.Zakryte, TypPolicka.Zakryte,TypPolicka.Zakryte},
            };

            StavHry stavHry = StavHry.Bezi;

            while (stavHry == StavHry.Bezi)
            {
                
                for (int y = 0; y < Maska.GetLength(0); y++)
                {
                    for (int x = 0; x < Maska.GetLength(1); x++)
                    {
                        Console.Write(Maska[y, x] + " ");
                    }
                    Console.WriteLine();
                }






                stavHry = InterakceSUzivatelem();
                if(stavHry == StavHry.Prohra)
                {
                    Console.WriteLine("prohra");
                    for (int y = 0; y < Maska.GetLength(0); y++)
                    {
                        for (int x = 0; x < Maska.GetLength(1); x++)
                        {
                            Console.Write(Maska[y, x] + " ");
                        }
                        Console.WriteLine();
                    }
                }

                if (stavHry == StavHry.Vyhra)
                {
                    Console.WriteLine("Výhra");
                }

            }
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
            Console.Write("Stiskni klávesu");
            ConsoleKeyInfo klavesa = Console.ReadKey();
            Console.WriteLine();
            if (klavesa.Key == ConsoleKey.RightArrow)
            {
                Console.WriteLine("Pravá klávesa");
                if (KurzorX < MinovePole.GetLength(1) - 1 && KurzorX >= 0)
                {
                    KurzorX += 1;
                }
                Console.WriteLine("y:" + KurzorY);
                Console.WriteLine("x:" + KurzorX);

            }

            if (klavesa.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            if (klavesa.Key == ConsoleKey.LeftArrow)
            {
                Console.WriteLine("Levá klávesa");
                if (KurzorX <= MinovePole.GetLength(1) && KurzorX > 0)
                {
                    KurzorX -= 1;
                }
                Console.WriteLine("y:" + KurzorY);
                Console.WriteLine("x:" + KurzorX);
            }

            if (klavesa.Key == ConsoleKey.DownArrow)
            {
                Console.WriteLine("Dolní klávesa");
                if (KurzorY < MinovePole.GetLength(0) - 1 && KurzorY >= 0)
                {
                    KurzorY += 1;
                }
                Console.WriteLine("y:" + KurzorY);
                Console.WriteLine("x:" + KurzorX);
            }

            if (klavesa.Key == ConsoleKey.UpArrow)
            {
                Console.WriteLine("Horní klávesa");
                if (KurzorY <= MinovePole.GetLength(0) && KurzorY > 0)
                {
                    KurzorY -= 1;
                }
                Console.WriteLine("y:" + KurzorY);
                Console.WriteLine("x:" + KurzorX);
            }

            if (klavesa.Key == ConsoleKey.V)
            {
                Console.WriteLine("v");
                if (Maska[KurzorY, KurzorX] == TypPolicka.Zakryte)
                {
                    Maska[KurzorY, KurzorX] = TypPolicka.Vlajka;
                }


                else if(Maska[KurzorY, KurzorX] == TypPolicka.Vlajka)
                {
                    Maska[KurzorY, KurzorX] = TypPolicka.Zakryte;
                }
            }   
            
            if (klavesa.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Enter");
                if (Maska[KurzorY, KurzorX] == TypPolicka.Zakryte)
                {
                    Maska[KurzorY, KurzorX] = TypPolicka.Odkryte;
                    if (MinovePole[KurzorY, KurzorX] == -1)
                    {
                        Maska[KurzorY, KurzorX] = TypPolicka.mina;
                        return StavHry.Prohra;
                    }
                }
                
            }
            for (int x = 0; x < MinovePole.GetLength(1); x++)
            {
               for (int y = 0; y < MinovePole.GetLength(0); y++)
                {   
                    if (MinovePole[y, x] == 0 && Maska[y, x] != TypPolicka.Odkryte)
                    {
                        return StavHry.Bezi;
                    }
                    
                    if (MinovePole[y, x] == -1 && Maska[y, x] != TypPolicka.Vlajka )
                    {
                      return StavHry.Bezi;
                    }
                }
            }

            


            return StavHry.Vyhra;
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
