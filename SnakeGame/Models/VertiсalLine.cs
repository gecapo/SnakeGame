using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Models
{
    class VertiсalLine : Figure
    {
        public VertiсalLine(int x, int yUp, int yDown, char symbol)
        {
            PointsList = new List<Block>();
            for (int y = yUp; y < yDown; y++)
            {
                Block p = new Block(x, y, symbol);
                PointsList.Add(p);
            }
        }
    }
}
