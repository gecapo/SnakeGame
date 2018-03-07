using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Models
{
    class Wall : Figure
    {
        List<Figure> wallList;

        public Wall(int widthMap, int heightMap)
        {
            wallList = new List<Figure>();
            char symbol = 'X';

            HorizontalLine hl1 = new HorizontalLine(0, widthMap - 2, 0, symbol);
            VertiсalLine vl1 = new VertiсalLine(widthMap - 2, 0, heightMap - 2, symbol);
            HorizontalLine hl2 = new HorizontalLine(0, widthMap - 2, heightMap - 2, symbol);
            VertiсalLine vl2 = new VertiсalLine(0, 0, heightMap - 2, symbol);

            wallList.Add(hl1);
            wallList.Add(vl1);
            wallList.Add(hl2);
            wallList.Add(vl2);

            foreach (var item in wallList)
            {
                item.Draw();
            }
        }

        public bool IsHit(Figure figur)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figur))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
