using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Models
{
    class Block
    {
        public Block()
        {
        }

        public Block(Block el)
        {
            Cordinates = new Cordinates(){ X = el.Cordinates.X, Y = el.Cordinates.Y};
            Symbol = el.Symbol;
        }

        public Block(int x, int y, char symbol)
        {
            Cordinates = new Cordinates() {X = x, Y = y};
            Symbol = symbol;
        }

        public Cordinates Cordinates;
        public char Symbol;

        public void Draw()
        {
            Console.SetCursorPosition(Cordinates.X,Cordinates.Y);
            Console.Write(Symbol);
        }

        public bool IsHit(Block p)
        {
            return p.Cordinates.X == Cordinates.X && p.Cordinates.Y == Cordinates.Y;
        }

        public void Clear()
        {
            Symbol = ' ';
            Draw();
        }

        public void Move(int offset, Direction direct)
        {
            if (direct == Direction.Right)
            {
                Cordinates.X += offset;
            }
            else if (direct == Direction.Left)
            {
                Cordinates.X -= offset;
            }
            else if (direct == Direction.Up)
            {
                Cordinates.Y -= offset;
            }
            else if (direct == Direction.Down)
            {
                Cordinates.Y += offset;
            }

        }

    }
}
