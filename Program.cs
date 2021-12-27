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
            int rotation = 0;

            int x = 61; int y = 3;
            int exX = x; ; int exY = y;
            int[,] shape = drawShape(shapeId, rotation, x, y);
            int[,] currentShape = shape;

            while (true)
            {
                //currentShape 
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
                            if (y + currentShape.GetLength(0) < 23)
                            {
                                rotation++;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (y + currentShape.GetLength(0) < 23)
                            {
                                y += 1;
                            }
                            break;

                        case ConsoleKey.RightArrow:

                            if (x + currentShape.GetLength(1) * 2 < 82)
                            {
                                x += 1;
                            }
                            break;

                        case ConsoleKey.LeftArrow:
                            if (x != 61 )
                            {
                                x -= 1;
                            }
                            break;
                    }
                }

                if (y + currentShape.GetLength(0) < 23)
                {
                    y += 1;
                }

                destroyShape(currentShape,exX,exY);
                //drawShape(shapeId, rotation, x, y);

                currentShape = drawShape(shapeId, rotation, x, y);

                if (y+currentShape.GetLength(0) == 23)
                {
                    shapeId = random.Next(1,8);
                    x = 61; y = 3;
                    currentShape = drawShape(shapeId, rotation, x, y);
                }
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(1000);
            }
        }

        static void drawFrame()
        {
            for (int y = 2; y <= 23; y++)
            {
                for (int x = 60; x <= 82; x++)
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
                    if (x == 82 && y == 2)
                    {
                        Console.Write("╗");
                    }
                    if (x == 82 && y == 23)
                    {
                        Console.Write("╝");
                    }

                    if ((x == 60 || x == 82) && (y > 2 && y < 23))
                    {
                        Console.Write("║");
                    }
                    else if ((y == 2 || y == 23) && (x < 82))
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
        static int[,] drawShape(int id, int rot, int x, int y)
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

            rot = rot % 4;
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
            return shape;
        }

        static void destroyShape(int[,] shape, int x, int y)
        {

            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    Console.SetCursorPosition(x,y);

                       Console.Write("  ");
                x = x + 2;

                }
                x = x - shape.GetLength(1) * 2;
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
