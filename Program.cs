using System;
using System.Collections.Generic;
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

            List<Shape> currentShapes = new List<Shape>();
            List<int> xLine = new List<int>();
            List<int> yLine = new List<int>();

            while (true)
            {
                int[,] board = new int[20, 10];
                foreach (var item in currentShapes)
                {
                    board = item.toBoard(board);
                }
               
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

                            int[,] temShape = shape.rotate();

                            if (temShape.GetLength(0) + shape.y < 23 && temShape.GetLength(1) * 2 + shape.x < 82)
                            {
                                
                                shape.rotation++;

                                if (shape.isColliding(board, temShape))
                                {
                                    shape.rotation--;
                                }
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (shape.y + shape.shape.GetLength(0) < 23)
                            {
                                shape.y += 1;

                                if (shape.isColliding(board,shape.shape))
                                {
                                    shape.y -= 1;
                                }
                            }
                            break;

                        case ConsoleKey.RightArrow:

                            if (shape.x + 2 + shape.shape.GetLength(1) * 2 <= 81)
                            {
                                shape.x += 2;

                                if (shape.isColliding(board, shape.shape))
                                {
                                    shape.x -= 2;
                                }
                            }
                            break;

                        case ConsoleKey.LeftArrow:
                            if (shape.x != 61)
                            {
                                shape.x -= 2;

                                if (shape.isColliding(board, shape.shape))
                                {
                                    shape.x += 2;
                                }

                            }
                            break;
                    }
                }

                bool collision = shape.isColliding(board, shape.shape);
                bool nextCollision = false;

                if (shape.y + shape.shape.GetLength(0) < 23 && (collision == false))
                {
                    shape.y += 1;
                    if (shape.isColliding(board, shape.shape))
                    {
                        nextCollision = true;
                        shape.y -= 1;
                    }
                }

                shape.destroyShape();

                shape.drawShape();

                if (shape.y + shape.shape.GetLength(0) == 23 || collision || nextCollision)
                {
                    currentShapes.Add(shape);

                    shapeId = random.Next(1, 8);
                    shape = new Shape(shapeId);
                    shape.drawShape();
                }

                xLine = new List<int>();
                yLine = new List<int>();
                bool isFull = shape.checkLine(board, xLine, yLine);

                if (isFull)
                {
                    foreach (var item in currentShapes)
                    {
                        item.y++;
                        item.destroyShape();
                        item.drawShape();
                    }
                }

                Console.SetCursorPosition(0, 0);
                Thread.Sleep(500);
            }
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
    }

    public class Shape
    {
        public int[,] shape;
        public ConsoleColor color;        

        public int rotation = 0; 
        int currRot = 0;

        public int x = 69; public int y = 3;
        int exX = 0; int exY = 0;     
        
        public int[,] toBoard(int [,] board)
        {
            for (int y = 0; y < shape.GetLength(0); y++)
            {
                for (int x = 0; x < shape.GetLength(1); x++)
                {
                    if (this.y - 3 + y < board.GetLength(0))
                    {
                        if (shape[y, x] == 1)
                            board[this.y - 3 + y, (this.x - 61) / 2 + x] = shape[y, x];
                    }
                }
            }
            return board;
        }

        public bool isColliding(int [,] board, int[,] shape)
        {
            for (int y = 0; y < shape.GetLength(0); y++)
            {
                for (int x = 0; x < shape.GetLength(1); x++)
                {
                    if (board[this.y - 3 + y, (this.x - 61) / 2 + x] == 1 && shape[y, x] == 1)
                        return true;
                }
            }
            return false;
        }

        public bool checkLine(int[,] board, List<int> x, List<int> y)
        {
            int count = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 1)
                    {
                        count++;
                        x.Add((61 + j * 2));
                        y.Add(3 + i);
                    }

                    if (count == 10)
                    {
                        return true;
                    }
                }
                count = 0;
            }
            return false;
        }
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
                    if (shape[i, j] == 1 && ty < 23)
                    {
                        Console.ForegroundColor = color;
                        Console.Write("██");
                        Console.ForegroundColor = ConsoleColor.White;
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

                    if (shape[i, j] == 1)
                    {
                        Console.Write("  ");
                    }
                    exX = exX + 2;
                }
                exX = exX - shape.GetLength(1) * 2;
                exY = exY + 1;
            }
        }
    }
}
