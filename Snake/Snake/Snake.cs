using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;

        // tail - начальная точка змеи, ее хвост
        // lenght - длинна змеи
        // direction - направление движения змеи
        public Snake(Point tail, int lenght, Direction direction) // конструктор создания змеи
        {
            this.direction = direction;

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
        public void Move()
        {
            // метод First() возвращает первый элемент списка
            Point tail = pList.FirstOrDefault(); // firstordefault

            // метод Remove() удаляет хвост змеи, ее крайнюю точку, т.к. змея ползет всегда прямо
            pList.Remove(tail);

            // head должна куда то переместится, для этого нужно написать метод GetNextPoint()
            Point head = GetNextPoint();

            // создаем новый pList
            pList.Add(head);

            // с помощью метода Clear() удаляем первый элемент змеи ее хвост
            tail.Clear();

            // отрисовываем новую точку 
            head.Draw();
        }
        public Point GetNextPoint()
        {
            // head змеи равна последней точке в pList
            Point head = pList.LastOrDefault(); // lastordefault

            // создаем новую точку, которая будет head
            Point nextPoint = new Point(head);

            // двигаем ее на одну клетку
            nextPoint.Move(1, direction);

            return nextPoint;
        }
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
        }
    }
}
