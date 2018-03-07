using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace BasicSnakeGame
{
    class Program
    {
        //Game Settings
        public static int GameWidth = 120;
        public static int GameHeight = 30;
        public static int GameSpeed = 150;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetBufferSize(GameWidth, GameHeight);

            //Initial Snake Coordinates
            int[] snakeX = new int[50];
            int[] snakeY = new int[50];
            snakeX[0] = 20;
            snakeY[0] = 10;

            //Food Cordinates
            int foodX;
            int foodY;

            //Create wall
            CreateWall(GameWidth, GameHeight);

            //Generate Snake
            CreateSnake(snakeX[0], snakeY[0]);

            //Generate Food
            Random rnd = new Random();
            GenerateFood(rnd, out foodX, out foodY);
            int counter = 0;

            //Game Running Condition
            bool gameRuning = true;

            ConsoleKey command = Console.ReadKey().Key;
            do
            {
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        SnakeClear(snakeX[0], snakeY[0]);
                        snakeX[0]--;
                        break;
                    case ConsoleKey.UpArrow:
                        SnakeClear(snakeX[0], snakeY[0]);
                        snakeY[0]--;
                        break;
                    case ConsoleKey.RightArrow:
                        SnakeClear(snakeX[0], snakeY[0]);
                        snakeX[0]++;
                        break;
                    case ConsoleKey.DownArrow:
                        SnakeClear(snakeX[0], snakeY[0]);
                        snakeY[0]++;
                        break;
                }

                CreateSnake(counter, snakeX, snakeY, out snakeX, out snakeY);

                if (IsWallHit(snakeX[0], snakeY[0]))
                {
                    gameRuning = false;
                    Console.SetCursorPosition(15, 15);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("GAME OVER");
                }

                if (WasEaten(snakeX[0], snakeY[0], foodX, foodY))
                {
                    GenerateFood(rnd, out foodX, out foodY);
                    counter++;
                }

                if (Console.KeyAvailable)
                {
                    command = Console.ReadKey().Key;
                }

                Thread.Sleep(GameSpeed);

            } while (gameRuning);


        }

        private static void CreateSnake(int counter, int[] snakeXIn, int[] snakeYIn, out int[] snakeXOut, out int[] snakeYOut)
        {
            //SnakeHead
            CreateSnake(snakeXIn[0], snakeYIn[0]);

            //SnakeBody
            for (int i = 1; i < counter + 1; i++)
            {
                CreateSnake(snakeXIn[i], snakeYIn[i]);
            }

            //Clear after snake
            SnakeClear(snakeXIn[counter + 1], snakeYIn[counter + 1]);

            //Snake body move
            for (int i = counter + 1; i > 0; i--)
            {
                snakeXIn[i] = snakeXIn[i - 1];
                snakeYIn[i] = snakeYIn[i - 1];
            }

            snakeXOut = snakeXIn;
            snakeYOut = snakeYIn;
        }

        private static void CreateSnake(int snakeX, int snakeY)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(snakeX, snakeY);
            Console.Write('O');
        }

        private static bool WasEaten(int snakeX, int snakeY, int foodX, int foodY)
        {
            return snakeX == foodX && snakeY == foodY;
        }

        private static void GenerateFood(Random rnd, out int foodX, out int foodY)
        {
            foodX = rnd.Next(2, GameWidth);
            foodY = rnd.Next(2, GameHeight);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(foodX, foodY);
            Console.Write('o');
        }

        private static bool IsWallHit(int snakeX, int snakeY)
        {
            return 1 == snakeX || GameWidth - 1 == snakeX || 0 == snakeY || GameHeight - 2 == snakeY;
        }

        private static void SnakeClear(int snakeX, int snakeY)
        {
            Console.SetCursorPosition(snakeX, snakeY);
            Console.Write(' ');
        }

        private static void CreateWall(int wdth, int hght)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" " + new string('#', wdth - 2));
            for (int j = 1; j < hght - 2; j++)
            {
                Console.SetCursorPosition(1, j);
                Console.Write('#');
                Console.SetCursorPosition(wdth - 1, j);
                Console.Write('#');
            }
            Console.Write(" " + new string('#', wdth - 2));
        }
    }
}
