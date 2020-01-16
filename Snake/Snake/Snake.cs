using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        // tail - начальная точка змеи, ее хвост
        // lenght - длинна змеи
        // direction - направление движения змеи
        public Snake(Point tail, int lenght, Direction direction) // конструктор создания змеи
        {
            pList = new List<Point>();

            for(int i = 0; i < lenght; i++)
            {
                // создаем новую точку, начало змеи и ее конец
                Point p = new Point(tail);
                // двигаем точку на i, с помощью метода
                p.Move(i, direction);
                // добавляем точку в лист
                pList.Add(p);
            }
        }
    }
}
