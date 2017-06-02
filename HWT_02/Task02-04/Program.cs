using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Ёлочки и пирамидки...
*/


namespace Task02_04
{
    class Program
    {
        static void Triangle(int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.Write(new string('*', i + 1) + '\n');
            }
        }

        static void Pyramid(int height, int center = -1)
        {
            if (center < 0) center = height;
            for (int i = 0; i < height; i++)
            {
                Console.Write(new string(' ', center - i - 1) + new string('*', i * 2 + 1) + '\n');
            }
        }

        static void Tree(int height)
        {
            for (int i = 0; i < height; i++)
            {
                Pyramid(i + 1, height);
            }
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string repeat;
            do
            {
                int n; 
                do
                {
                    Console.Clear();

                    Console.Write("Введите высоту (n): ");
                    if (!int.TryParse(Console.ReadLine(), out n)) continue;

                    if (n <= 0) 
                    {
                        Console.Write("Высота должна быть больше 0!");
                        Console.ReadKey();
                        continue;
                    }

                    break;

                } while (true);

                int task;
                Console.Write("Выберите задание:\n1 - Треугольник\n2 - Пирамида\n3 - Ёлка\n>> ");
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out task) || task <= 0 || task > 3)
                    {
                        Console.Write("Неправильный ввод! Введите снова: ");
                        continue;
                    }

                    break;

                } while (true);


                switch (task)
                {
                    case 1:
                        Console.WriteLine("Треугольник:");
                        Triangle(n);
                        break;
                    case 2:
                        Console.WriteLine("Пирамида:");
                        Pyramid(n);
                        break;
                    case 3:
                        Console.WriteLine("Ёлка:");
                        Tree(n);
                        break;
                }

                Console.Write("Повторить? [Y/y - да]: ");
                repeat = Console.ReadLine();
            } while (repeat == "Y" || repeat == "y");
        }
    }
}
