using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            // отрисовка рамки
            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            //upLine.Drow();
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            //downLine.Drow();
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            //leftLine.Drow();
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            //rightLine.Drow();

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }
        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Drow();
            }
        }
        public bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                    return true;
            }
            return false;
        }
    }
}
