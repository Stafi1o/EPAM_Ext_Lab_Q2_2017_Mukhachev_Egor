using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var param = new List<string>();
            var styles = new Dictionary<Styles, string>
            {
                {Styles.Bold, "Bold"},
                {Styles.Italic, "Italic"},
                {Styles.Underline, "Underline"}
            };

            do
            {
                const int clear = 4;
                const int exit = 0;

                Console.Clear();

                Console.Write("Параметры надписи: ");
                Console.WriteLine(!param.Any() ? "None" : string.Join(", ", param.ToArray()));

                Console.WriteLine("Введите: \n\t 1: Bold \n\t 2: italic \n\t 3: underline \n\t 4: clear \n\t 0: Выход");
                if (!int.TryParse(Console.ReadLine(), out var chosen) || chosen < 0 || chosen > 4 )
                {
                    Console.Write("Неправильный ввод!");
                    Console.ReadKey();
                    continue;
                }

                switch (chosen)
                {
                    case exit:
                        return;
                    case clear:
                        param.Clear();
                        continue;
                    default:
                        var style = styles[(Styles) chosen];
                        if (param.Contains(style))
                        {
                            param.Remove(style);
                        }
                        else
                        {
                            param.Add(style);
                        }
                        break;
                }

            } while (true);
        }
    }

    enum Styles
    {
        Bold = 1,
        Italic = 2,
        Underline = 3
    }
}
