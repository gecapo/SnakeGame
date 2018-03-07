using System;

namespace BetterSnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 120;
            int height = 30;
            Console.SetBufferSize(width,height);
            Wall wall = new Wall(width, height);

            
        }
    }

    class Block
    {
        public Cordinates Cordinates;
        public char symbol;

        public bool IsHit(Block el)
        {
            return el.Cordinates.x == Cordinates.x && el.Cordinates.y == Cordinates.y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(Cordinates.x, Cordinates.y);
            Console.Write(symbol);
        }

        public void Clear()
        {
            symbol = ' ';
            Draw();
        }
    }

    class Food : Block
    {
        
    }

    enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }

    interface IMovable
    {
        void Move();
    }

    struct Cordinates
    {
        public int x;
        public int y;
    } 
}
