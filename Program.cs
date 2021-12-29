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

            Shape shape = new Shape(shapeId);
            int[,] currentShape = shape.shape;

            while (true)
            {
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
                            //TODO: suank, şekile değil bir defa daha döndürdükten sonraki
                            // şeklin y+c si ile kontrol yap
                            if (shape.y + shape.shape.GetLength(0) < 23)
                            {
                                shape.rotation++;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (shape.y + shape.shape.GetLength(0) < 23)
                            {
                                shape.y += 1;
                            }
                            break;

                        case ConsoleKey.RightArrow:

                            if (shape.x + shape.shape.GetLength(1) * 2 < 82)
                            {
                                shape.x += 1;
                            }
                            break;

                        case ConsoleKey.LeftArrow:
                            if (shape.x != 61)
                            {
                                shape.x -= 1;
                            }
                            break;
                    }
                }

                if (shape.y + shape.shape.GetLength(0) < 23)
                {
                    shape.y += 1;
                }

                shape.destroyShape();

                shape.drawShape();               
               
                if (shape.y + shape.shape.GetLength(0) == 23)
                {
                    shapeId = random.Next(1, 8);
                    shape = new Shape(shapeId);
                    shape.drawShape();
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
    }

    public class Shape
    {
        public int[,] shape;
        public ConsoleColor color;

        public int rotation = 0; 
        int currRot = 0;

        public int x = 61; public int y = 3;
        int exX = 0; int exY = 0;     
        
        public Shape(int id)
        {
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
        }
        public void drawShape()
        {
            int tx = x, ty = y;
            exX = x; exY = y;

            rotation = rotation % 4;
            while(currRot != rotation)
            {
                shape = rotate();
                currRot++;
                currRot = currRot % 4;
            }
            currRot = rotation;            

            int r = shape.GetLength(0);
            int c = shape.GetLength(1);

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.SetCursorPosition(tx, ty);
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
                    tx = tx + 2;
                }
                tx = tx - c * 2;
                ty = ty + 1;
            }
        }

        public int[,] rotate()
        {
            int[,] tr = new int[shape.GetLength(1), shape.GetLength(0)];

            for (int c = 0; c < shape.GetLength(1); c++)
            {
                for (int r = 0; r < shape.GetLength(0); r++)
                {
                    tr[c, shape.GetLength(0) - r - 1] = shape[r, c];
                }
            }
            return tr;
        }

        public void destroyShape()
        {
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    Console.SetCursorPosition(exX, exY);

                    Console.Write("  ");
                    exX = exX + 2;
                }
                exX = exX - shape.GetLength(1) * 2;
                exY = exY + 1;
            }
        }

        public void moveShape()
        {
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
                        //TODO: suank, şekile değil bir defa daha döndürdükten sonraki
                        // şeklin y+c si ile kontrol yap
                        if (y + shape.GetLength(0) < 23)
                        {
                            rotation++;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (y + shape.GetLength(0) < 23)
                        {
                            y += 1;
                        }
                        break;

                    case ConsoleKey.RightArrow:

                        if (x + shape.GetLength(1) * 2 < 82)
                        {
                            x += 2;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (x != 61)
                        {
                            x -= 2;
                        }
                        break;
                }
            }

            if (y + shape.GetLength(0) < 23)
            {
                y += 1;
            }
        }
    }
}
