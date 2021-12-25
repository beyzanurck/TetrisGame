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

            Random random = new Random();
            int shapeId = random.Next(1, 8);


            drawShape(5, 0, 61, 3);
            drawShape(5, 1, 68, 3);
            drawShape(5, 2, 74, 3);
            drawShape(5, 3, 81, 3);


            Console.ReadLine();
        }

        static void drawFrame()
        {
            for (int y = 2; y <= 23; y++)
            {
                for (int x = 60; x <= 81; x++)
                {
                    Console.SetCursorPosition(x, y);

                    if (x == 60 && y == 2)
                    {
                        Console.Write("╔");
                    }
                    if (x == 60 && y == 23)
                    {
                        Console.Write("╚");
                    }
                    if (x == 81 && y == 2)
                    {
                        Console.Write("╗");
                    }
                    if (x == 81 && y == 23)
                    {
                        Console.Write("╝");
                    }

                    if ((x == 60 || x == 81) && (y > 2 && y < 23))
                    {
                        Console.Write("║");
                    }
                    else if ((y == 2 || y == 23) && (x < 81))
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
        }
        static void drawShape(int id, int rot, int x, int y)
        {
            ConsoleColor color = new ConsoleColor();
            int[,] shape = new int[4, 4];

            if (id == 1) //sarı
            {
                color = ConsoleColor.Yellow;
                shape = new int[,] { { 1, 1 }, { 1, 1 } };
            }
            if (id == 2) // turkuaz
            {
                color = ConsoleColor.DarkCyan;
                shape = new int[,] { { 1, 1, 1, 1 } };
            }
            if (id == 3) // yeşil
            {
                color = ConsoleColor.Green;
                shape = new int[,] { { 0, 1, 1 }, { 1, 1, 0 } };
            }
            if (id == 4) //kırmızı
            {
                color = ConsoleColor.DarkRed;
                shape = new int[,] { { 1, 1, 0 }, { 0, 1, 1 } };
            }
            if (id == 5) // mor
            {
                color = ConsoleColor.Magenta;
                shape = new int[,] { { 0, 1, 0 }, { 1, 1, 1 } };
            }
            if (id == 6) // mavi
            {
                color = ConsoleColor.DarkBlue;
                shape = new int[,] { { 1, 0, 0 }, { 1, 1, 1 } };
            }
            if (id == 7) //turuncu
            {
                color = ConsoleColor.DarkYellow;
                shape = new int[,] { { 0, 0, 1 }, { 1, 1, 1 } };
            }

            for (int i = 0; i < rot; i++)
            {
                shape = rotate(shape);
            }

            int r = shape.GetLength(0);
            int c = shape.GetLength(1);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.SetCursorPosition(x, y);
                    if (shape[i, j] == 1)
                    {
                        Console.ForegroundColor = color;
                        Console.Write("██");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    x = x + 2;
                }
                x = x - c * 2;
                y = y + 1;
            }

        }

        static int[,] rotate(int[,] matris)
        {
            int[,] tr = new int[matris.GetLength(1), matris.GetLength(0)];

            for (int c = 0; c < matris.GetLength(1); c++)
            {
                for (int r = 0; r < matris.GetLength(0); r++)
                {
                    tr[c, matris.GetLength(0) - r - 1] = matris[r, c];
                }
            }

            return tr;

        }

    }

}
