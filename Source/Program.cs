﻿namespace Miny
{
    internal class Program
    {
        // vyctovy datovy typ
        enum TypPolicka
        {
            Zakryte,
            Odkryte,
            Vlajka,
            _mina_,
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
            VygenerovatHerniPlochu();
           
            StavHry stavHry = StavHry.Bezi;

            while (stavHry == StavHry.Bezi)
            {

                Console.WriteLine("y:" + KurzorY);
                Console.WriteLine("x:" + KurzorX);
                for (int y = 0; y < Maska.GetLength(0); y++)
                {
                    for (int x = 0; x < Maska.GetLength(1); x++)
                    {
                        Console.Write(Maska[y, x] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();







                stavHry = InterakceSUzivatelem();
                if(stavHry == StavHry.Prohra)
                {
                    Console.WriteLine("mapa");
                    for (int y = 0; y < Maska.GetLength(0); y++)
                    {
                        for (int x = 0; x < Maska.GetLength(1); x++)
                        {
                            Console.Write(Maska[y, x] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("odkrytá mapa");
                    
                    for (int x = 0; x < MinovePole.GetLength(1); x++)
                    {
                        for (int y = 0; y < MinovePole.GetLength(0); y++)
                        {
                            if (MinovePole[y, x] == -1)
                            {
                                Maska[y, x] = TypPolicka._mina_;
                            }
                            if (MinovePole[y, x] == 0)
                            {
                                Maska[y, x] = TypPolicka.Odkryte;
                            }
                        }
                    }
                    for (int y = 0; y < Maska.GetLength(0); y++)
                    {
                        for (int x = 0; x < Maska.GetLength(1); x++)
                        {
                            Console.Write(Maska[y, x] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("prohra");
                }


                if (stavHry == StavHry.Vyhra)
                {
                    Console.WriteLine("mapa");
                    for (int y = 0; y < Maska.GetLength(0); y++)
                    {
                        for (int x = 0; x < Maska.GetLength(1); x++)
                        {
                            Console.Write(Maska[y, x] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("Výhra");
                }

            }
        }

        static void VygenerovatHerniPlochu()
        {
            MinovePole = new int[SirkaHerniPlochy, VyskaHerniPlochy];
            Maska = new TypPolicka[SirkaHerniPlochy, VyskaHerniPlochy];

            Random nahoda = new Random();
            int z = 0;
            while(z<10)
            {
                int Random_x = nahoda.Next(MinovePole.GetLength(0));
                int Random_y = nahoda.Next(MinovePole.GetLength(1));
                if(MinovePole[Random_x, Random_y] != -1)
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


                else if(Maska[KurzorY, KurzorX] == TypPolicka.Vlajka)
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
