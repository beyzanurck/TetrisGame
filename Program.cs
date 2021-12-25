using System;
using System.Text;
using System.Threading;

namespace tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;

            drawFrame();
            int x = 80;
            int y = 3;

            int exY, exX;

            int[,] oldShapes = new int[4, 4];
            int[,] newShapes = new int[4, 4];

            int orient = 1;
            while (true)
            {
                int timer = 1000;

                putShape(2, orient, x, y, newShapes);

                exX = x;
                exY = y;


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    while (Console.KeyAvailable)
                    {
                        keyInfo = Console.ReadKey();
                    }

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:

                            orient++;

                            break;

                        case ConsoleKey.RightArrow:

                            x = x + 2;

                            break;

                        case ConsoleKey.LeftArrow:

                            x = x - 2;

                            break;

                        case ConsoleKey.DownArrow:

                            timer = 100;

                            break;
                    }
                }

                if (y <= 36)
                {
                    y = y + 1;
                }

                Thread.Sleep(timer);

            }
           

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

        static void putShape(int id, int orient, int x, int y, int[,] oldShape)
        {
            if (id == 1)
            {
                oldShape = new int[,] { { 1, 1, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            }

            if (id == 2)
            {
                if (orient % 2 != 0)
                {
                    oldShape = new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 1, 1, 1, 1 } };

                }
                if (orient % 2 == 0)
                {
                    oldShape = new int[,] { { 1, 0, 0, 0 }, { 1, 0, 0, 0 }, { 1, 0, 0, 0 }, { 1, 0, 0, 0 } };

                }
            }

            if (id == 3)
            {
                oldShape = new int[,] { { 0, 1, 1, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            }
            if (id == 4)
            {
                oldShape = new int[,] { { 1, 1, 0, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            }
            if (id == 5)
            {
                oldShape = new int[,] { { 0, 1, 0, 0 }, { 1, 1, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            }
            if (id == 6)
            {
                oldShape = new int[,] { { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 } };
            }
            if (id == 7)
            {
                oldShape = new int[,] { { 1, 0, 0, 0 }, { 1, 0, 0, 0 }, { 1, 1, 0, 0 }, { 0, 0, 0, 0 } };
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.SetCursorPosition(x,y);
                    if (oldShape[i, j] == 1)
                    {
                        Console.Write("██");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    x = x + 2;
                }
                y = y + 1;
                x = x - 8;
            }
        }

        static void eraseShape(int id, int orient, int x, int y, int[,] oldShape)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.SetCursorPosition(x, y);
                    if (oldShape[i, j] == 1)
                    {
                        Console.Write("  ");
                    }
                    x = x + 2;
                }
                y = y + 1;
                x = x - 8;
            }
        }
    }
    
}
