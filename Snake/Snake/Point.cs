using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
        }
        public Point()
        {

        }
        //создаем конструктор, который задает параметры для змеи в конструкторе Snake
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }
        // offset - смещение точки
        public void Move(int offset, Direction direction)
        {
            switch(direction)
            {
                case Direction.RIGHT:
                    x += offset;
                    break;
                case Direction.LEFT:
                    x -= offset;
                    break;
                case Direction.UP:
                    y += offset;
                    break;
                case Direction.DOWN:
                    y -= offset;
                    break;
            }            
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
        // отображение координат в данном формате
        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
        public void Clear()
        {
            sym = ' ';
            Draw();
        }
    }
}
