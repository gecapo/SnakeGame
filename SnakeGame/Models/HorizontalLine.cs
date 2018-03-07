using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Models
{
    class HorizontalLine : Figure
    {
        public HorizontalLine(int xRight, int xLeft, int y, char symbol)
        {
            PointsList = new List<Block>();
            for (int x = xRight; x <= xLeft; x++)
            {
                Block p = new Block(x, y, symbol);
                PointsList.Add(p);
            }
        }
    }
}
