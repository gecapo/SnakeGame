using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.Models
{
    class Snake : Figure
    {
        public Snake(Block tail, int length, Direction direct)
        {
            this.direct = direct;
            PointsList = new List<Block>();

            for (int i = 0; i < length; i++)
            {
                Block p = new Block(tail);
                p.Move(i, direct);
                PointsList.Add(p);
            }
        }

        Direction direct;

        public void Move()
        {
            Block tail = PointsList.First();
            PointsList.Remove(tail);

            Block head = GetNextPoint();
            PointsList.Add(head);

            tail.Clear();
            head.Draw();

        }

        internal bool IsHitTall()
        {
            Block head = PointsList.Last();
            for (int i = 0; i < PointsList.Count - 2; i++)
            {
                if (head.IsHit(PointsList[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public Block GetNextPoint()
        {
            Block head = PointsList.Last();
            Block nextBlock = new Block(head);

            nextBlock.Move(1, direct);
            return nextBlock;
        }

        public void HandalKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                direct = Direction.Left;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                direct = Direction.Right;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                direct = Direction.Up;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                direct = Direction.Down;
            }
        }
        public bool IsEat(Block food)
        {
            Block head = GetNextPoint();
            Block secondHead = PointsList[PointsList.Count - 2];

            if (head.IsHit(food))
            {
                food.Symbol = head.Symbol;
                PointsList.Add(food);
                return true;
            }
            if (secondHead.IsHit(food))
            {
                food = GetNextPoint();
                food.Symbol = secondHead.Symbol;
                PointsList.Add(food);
                return true;
            }
            return false;
        }
    }
}
