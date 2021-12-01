using System;
using System.Text;

namespace tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;

            drawFrame();

            Console.ReadLine();
        }

        static void drawFrame()
        {

            for (int y = 2; y < 42; y++)
            {
                for (int x = 60; x < 100; x++)
                {
                    Console.SetCursorPosition(x, y);                                       

                    if (x == 60 && y == 2)
                    {
                        Console.Write("╔");
                    }
                    if (x == 60 && y == 41)
                    {
                        Console.Write("╚");
                    }
                    if (x == 99 && y == 2)
                    {
                        Console.Write("╗");
                    }
                    if (x == 99 && y == 41)
                    {
                        Console.Write("╝");
                    }

                    if ((x == 60 || x == 99) && (y > 2 && y < 41))
                    {
                        Console.Write("║");
                    }
                    else if ((y == 2 || y == 41) && (x < 99))
                    {
                        Console.Write("═");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                }

                Console.WriteLine();
            }

            for (int y = 10; y < 20; y++)
            {
                for (int x = 110; x < 130; x++)
                {
                    Console.SetCursorPosition(x, y);                                       

                    if (x == 110 && y == 10)
                    {
                        Console.Write("╔");
                    }
                    if (x == 110 && y == 19)
                    {
                        Console.Write("╚");
                    }
                    if (x == 129 && y == 10)
                    {
                        Console.Write("╗");
                    }
                    if (x == 129 && y == 19)
                    {
                        Console.Write("╝");
                    }

                    if ((x == 110 || x == 129) && (y > 10 && y < 19))
                    {
                        Console.Write("║");
                    }
                    else if ((y == 10 || y == 19) && (x < 129))
                    {
                        Console.Write("═");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                }

                Console.WriteLine();
            }

            for (int y = 10; y < 26; y++)
            {
                for (int x = 30; x < 50; x++)
                {
                    Console.SetCursorPosition(x, y);

                    if (x == 30 && y == 10)
                    {
                        Console.Write("╔");
                    }
                    if (x == 30 && y == 25)
                    {
                        Console.Write("╚");
                    }
                    if (x == 49 && y == 10)
                    {
                        Console.Write("╗");
                    }
                    if (x == 49 && y == 25)
                    {
                        Console.Write("╝");
                    }

                    if ((x == 30 || x == 49) && (y > 10 && y < 25))
                    {
                        Console.Write("║");
                    }
                    else if ((y == 10 || y == 25) && (x < 49))
                    {
                        Console.Write("═");
                    }
                    else if (y == 15 || y == 20)
                    {
                        Console.Write("═");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                }

                Console.WriteLine();
            }

            Console.SetCursorPosition(77,1);
            Console.WriteLine("TETRIS");

            Console.SetCursorPosition(118,11);
            Console.WriteLine("NEXT");

            Console.SetCursorPosition(38, 11);
            Console.WriteLine("SCORE"); 
            Console.SetCursorPosition(38, 16);
            Console.WriteLine("LEVEL"); 
            Console.SetCursorPosition(38, 21);
            Console.WriteLine("LINE");


        }
    }
}
