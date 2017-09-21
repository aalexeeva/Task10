using System;
using static System.Console;

namespace Task10
{
    class Program
    {
        public static int Input(bool status) // ввод числа N
        {
            var number = 0; // переменная для числа
            bool ok; // показатель корректности ввода
            do
            {
                try
                {
                    number = Convert.ToInt32(ReadLine());
                    if (status) // проверка значения количества элементов
                    {
                        if (number < 1)
                        {
                            WriteLine("Количество элементов в дереве должно быть больше 1, повторите ввод");
                            ok = false;
                        }
                        else if (number > 100)
                        {
                            WriteLine("Введено слишком большое число, повторите ввод");
                            ok = false;
                        }
                        else ok = true;
                    }
                    else ok = true;
                }
                catch (FormatException)
                {
                    WriteLine("Ошибка при вводе числа");
                    ok = false;
                }
                catch (OverflowException)
                {
                    WriteLine("Ошибка при вводе числа");
                    ok = false;
                }
            } while (!ok);
            return number;
        }

        static void Main(string[] args)
        {
            WriteLine("Введите количество всех элементов в дереве: ");
            int size = Input(true);
            int[] arr = new int[size];
            WriteLine("Выберите способ ввода элементов: \n1.Сгенерировать рандомно\n2.Ввести с клавиатуры");
            var userAnswer = Input(false);
            switch (userAnswer)
            {
                case 1:
                    Random rnd = new Random();
                    for (var i = 0; i < size; i++)
                        arr[i] = rnd.Next(-100, 100);
                    break;
                case 2:
                    for (var i = 0; i < size; i++)
                    {
                        WriteLine("Введите значение {0} элемента", i + 1);
                        arr[i] = Input(false);
                    }
                    break;
            }
            
            Tree t = new Tree();
            Tree.Create(arr, t);
            Tree.ShowTree(t.Root, size);
            WriteLine("Количество ярусов в дереве: " + t.Length);
            int[] k = t.NodesOnLevel();
            for (var i = 0; i < t.Length; i++)
                WriteLine("Количество вершин на {0} ярусе: {1}", i + 1, k[i]);
            ReadKey(true);
        }
    }
}
