using System;

/*
    Написать консольное приложение, которое проверяет
    принадлежность точки заштрихованной области.
    Пользователь вводит координаты точки (x; y) и выбирает
    букву графика (a-к). В консоли должно высветиться сообщение:
    «Точка [(x; y)] принадлежит фигуре [г]».
*/

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            string repeat;
            do
            {
                Console.Clear();

                char task;
                Console.Write("Введите букву графика (а-к): ");
                while (true)
                {
                    if (char.TryParse(Console.ReadLine(), out task) && task >= 'а' && task <= 'к')
                    {
                        break;
                    }

                    Console.Write("Введена неправильная задача. Введите еще раз: ");
                }

                double x, y;
                while (true)
                {
                    Console.Write("Введите координаты (X, Y) точки через пробел: ");
                    var readLine = Console.ReadLine();
                    var input = readLine?.Replace('.', ',').Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (input?.Length == 2 && double.TryParse(input[0], out x) && double.TryParse(input[1], out y))
                    {
                        break;
                    }

                    Console.WriteLine("Неправильной ввод координат. Введите еще раз");
                }

                var p = new DPoint(x, y);
                var correct = false;
                switch (task)
                {
                    case 'а':
                        correct = Figures.InCircle(p, new DPoint(0, 0), 1.0);
                        break;
                    case 'б':
                        correct = Figures.InCircle(p, new DPoint(0, 0), 1.0) &&
                                  !Figures.InCircle(p, new DPoint(0, 0), 0.5, false);
                        break;
                    case 'в':
                        correct = Figures.InRectange(p, new DPoint(-1, 1), new DPoint(1, -1));
                        break;
                    case 'г':
                        correct = Figures.InTriangle(p, new DPoint(0, -1), new DPoint(-1, 0), new DPoint(0, 1)) &&
                                  Figures.InTriangle(p, new DPoint(0, -1), new DPoint(1, 0), new DPoint(0, 1));
                        break;
                    case 'д':
                        correct = Figures.InTriangle(p, new DPoint(0, -1), new DPoint(-0.5, 0), new DPoint(0, 1)) &&
                                  Figures.InTriangle(p, new DPoint(0, -1), new DPoint(0.5, 0), new DPoint(0, 1));
                        break;
                    case 'е':
                        correct = p.X >= 0
                            ? Figures.InCircle(p, new DPoint(0, 0), 1.0)
                            : Figures.InTriangle(p, new DPoint(-2, 0), new DPoint(0, 1), new DPoint(0, -1));
                        break;
                    case 'ж':
                        // Координаты нашел по подобным треугольникам
                        correct = Figures.InTriangle(p, new DPoint(-1.5, -1), new DPoint(0, 2), new DPoint(1.5, -1));
                        break;
                    case 'з':
                        correct = Figures.InRectange(p, new DPoint(-1, 1), new DPoint(1, -2)) &&
                                  p.Y <= Math.Abs(p.X);
                        break;
                    case 'и':
                        correct = Figures.InTriangle(p, new DPoint(-2, -1), new DPoint(-1, 1), new DPoint(0, 0)) &&
                                  Figures.InTriangle(p, new DPoint(0, 0), new DPoint(-2, -1), new DPoint(1, 0));
                        break;
                    case 'к':
                        correct = p.Y >= 1 || p.Y >= Math.Abs(p.X);
                        break;
                }

                var inside = correct ? string.Empty : "не";
                Console.WriteLine("Точка[({0}; {1})] {3} принадлежит фигуре[{2}]", x, y, task, inside);

                Console.Write("Повторить выбор задачи? [Y/y - да]: ");
                repeat = Console.ReadLine();

            } while (repeat == "Y" || repeat == "y");
        }
    }
}
