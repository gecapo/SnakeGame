using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Models
{
    class FoodCreate
    {
        public FoodCreate(int widthMap, int heightMap, char symbol)
        {

            this.widthMap = widthMap;
            this.heightMap = heightMap;
            this.symbol = symbol;
        }

        readonly int widthMap;
        readonly int heightMap;
        readonly char symbol;

        Random _rnd = new Random();

        public Block CreateFood()
        {
            int x = _rnd.Next(4, widthMap - 4);
            int y = _rnd.Next(4, heightMap - 4);
            return new Block(x, y, symbol);
        }
    }
}
