using System;

/*
    Дано действительно число h.
    Выяснить имеет ли уравнение ax^2+bx+c=0 действительные корни.
*/

namespace Task02
{
    class Program
    {
        private static double[] QuadraticEquation(double a, double b, double c, out double discr)
        {
            discr = b * b - 4 * a * c;
            if (a.Equals(0.0))
            {
                return new[] { -c / b};
            }

            if (discr < 0)
            {
                return new double[] { };
            }

            if (discr.Equals(0.0))
            {
                return new[] { -b / (2 * a) };
            }

            return new[] { (Math.Sqrt(discr) - b) / (2 * a), (-Math.Sqrt(discr) - b) / (2 * a) };
        }

        static void Main(string[] args)
        {
            var repeat = "Y";
            do
            {
                Console.Clear();

                double h;
                Console.Write("Введите число h: ");
                while (true)
                {
                    var readLine = Console.ReadLine();
                    if (readLine != null && double.TryParse(readLine.Replace('.', ','), out h))
                    {
                        break;
                    }

                    Console.Write("Число введено неверно. Введите еще раз: ");
                }

                var a = 1 - Math.Sin(4 * h) * Math.Cos(h * h + 18);
                if (a.Equals(0.0))
                {
                    Console.WriteLine("Деление на 0 в выражении [а]");
                    continue;
                }

                a = Math.Sqrt((Math.Abs(Math.Sin(8 * h)) + 17) / Math.Pow(a, 2));

                var b = 1 - Math.Sqrt(3 / (3 + Math.Abs(Math.Tan(a * h * h) - Math.Sin(a * h))));

                var c = a * h * h * Math.Sin(b * h) + b * Math.Pow(h, 3) * Math.Cos(a * h);

                var roots = QuadraticEquation(a, b, c, out var d);
                Console.WriteLine("А = {0}; B = {1}; C = {2}; Discr = {3}", a, b, c, d);
                switch (roots.Length)
                {
                    case 0:
                        Console.WriteLine("Действительных корней нет");
                        break;
                    case 1:
                        Console.WriteLine("Корень уравнения: {0}", roots[0]);
                        break;
                    case 2:
                        Console.WriteLine("Корни уравнения: {0} и {1}", roots[0], roots[1]);
                        break;
                }

                Console.Write("Повторить? [Y/y - да]: ");
                repeat = Console.ReadLine();

            } while (repeat == "Y" || repeat == "y");
        }
    }
}
