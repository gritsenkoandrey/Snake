﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            // установка размера окна
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            
            // отрисовка рамки
            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            upLine.Drow();
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            downLine.Drow();
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            leftLine.Drow();
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            rightLine.Drow();

            // отрисовка начальной точки змеи
            Point p = new Point(4, 5, '*');

            // респавн змеи и ее направления
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();
            snake.Move();

            while(true)
            {
                if(Console.KeyAvailable) // Возвращает или задает значение, указывающее, доступно ли нажатие клавиши во входном потоке.
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                Thread.Sleep(100);
                snake.Move();
            }            

            Console.ReadKey();
        }
    }
}
