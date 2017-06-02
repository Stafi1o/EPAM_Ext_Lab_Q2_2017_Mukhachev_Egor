using System;
using System.Text;

/*
    Если выписать все натуральные числа меньше 10, кратные 3, или 5, то
    получим 3, 5, 6 и 9. Сумма этих чисел будет равна 23. Напишите
    программу, которая выводит на экран сумму всех чисел меньше 1000,
    кратных 3, или 5. 
*/

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int number = 1000, fMod = 5, sMod = 3, sum = 0;

            for (int i = 0; i < number; i++)
            {
                if (i % fMod == 0 || i % sMod == 0)
                    sum += i;
            }

            Console.WriteLine($"Сумма всех чисел меньше 1000, кратных 3, или 5, равна: {sum}");
            Console.ReadKey();
        }
    }
}
