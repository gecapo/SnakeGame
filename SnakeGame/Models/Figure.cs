using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame.Models
{
    class Figure
    {
        public List<Block> PointsList;

        public virtual void Draw()
        {
            foreach (var item in PointsList)
            {
                item.Draw();
            }
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var p in PointsList)
            {
                if (figure.IsHit(p))
                {
                    return true;
                }
            }
            return false;

        }

        bool IsHit(Block block)
        {
            foreach (var p in PointsList)
            {
                if (block.IsHit(p))
                {
                    return true;
                }
            }
            return false;

        }
    }
}
