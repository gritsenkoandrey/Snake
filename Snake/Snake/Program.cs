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
            Walls wall = new Walls(80, 25);
            wall.Draw();

            // отрисовка начальной точки змеи
            Point p = new Point(4, 5, '*');

            // респавн змеи и ее направления
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();

            // создаем еду в пределах координат 80/25 и символом еды $
            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            // создаем точку с едой в рандмном месте в пределах координат
            Point food = foodCreator.Createfood();
            // выводим на поле точку
            food.Draw();

            while(true)
            {
                if (wall.IsHit(snake) || snake.IsHitTail())
                    break;
                if(snake.Eat(food))
                {
                    food = foodCreator.Createfood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable) // Возвращает или задает значение, указывающее, доступно ли нажатие клавиши во входном потоке.
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            WriteGameOver();
            Console.ReadKey();
        }
        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Автор: Андрей Гриценко", xOffset + 2, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
