using System;
using System.Text;

/*
    Написать программу, которая определяет площадь прямоугольника со
    сторонами a и b. Если пользователь вводит некорректные значения
    (отрицательные, или 0), должно выдаваться сообщение об ошибке.
    Возможность ввода пользователем строки вида «абвгд», или нецелых
    чисел игнорировать. */

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            string repeat;
            do
            {
                int a, b;
                do
                {
                    Console.Clear();

                    Console.Write("Введите стороны прямоугольника (а,b) через пробел: ");
                    var readLine = Console.ReadLine();
                    var input = readLine?.Replace('.', ',').Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                    if (input?.Length != 2 || !int.TryParse(input[0], out a) || !int.TryParse(input[1], out b)) continue;

                    if (a <= 0 || b <= 0)
                    {
                        Console.Write("Стороны должны быть больше 0. Введите еще раз!");
                        Console.ReadKey();
                        continue;
                    }

                    break;

                } while (true);

                Console.WriteLine($"Площадь прямоугольника по введенным сторонам [{a},{b}] равна: {a * b}");

                Console.Write("Повторить? [Y/y - да]: ");
                repeat = Console.ReadLine();
            } while (repeat == "Y" || repeat == "y");

        }
    }
}
