using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Работа №8 Вариант 9 ФКТ 2 курс группа 219 Каргапольцев Кирилл";

            double x, toch;          //инициализация очень нужных переменных
            int num, a_prov = 0;
            do   //цикл с постусловием для проверки введённого числа Х
            {
                Console.Clear();
                Console.WriteLine("Объект 1 \nВычислние ряда с заданной точностью\narctg x = x - x^3/3 + x^5/5 - x^7/7 + ... \nЭлемент ряда = (-1)^n * x^(2*n+1) / (2*n + 1)"); //вступление
                Console.WriteLine("----------------------------------------------------");
                if (a_prov == 1)//проверка на наличие ошибок(чтобы сообщение не показывалось при первом проходе)
                {
                    Console.WriteLine("Ошибка диапазона числа х!");   //сообщение начнёт выводиться только 
                }                                                     //после второго прогона этого цикла
                Console.Write("Введите значение (|x| < 1) x: "); 
                x = Convert.ToDouble(Console.ReadLine()); //ввод числа Х
                a_prov++; //переменная для проверки ошибки введённых данных
            }while (Math.Abs(x) > 1);  //проверяем выход за диапазон
            Console.Write("Введите кол-во элементов ряда: ");
            num = Convert.ToInt32(Console.ReadLine());       //ввод кол-ва элементов ряда
            Console.WriteLine("Значение элементов ряда");
            Console.WriteLine("----------------------------------------------------");
            Project obj_1 = new Project(x,num); //создание объекта 1 с первым конструктором
            Console.Write(obj_1.mass());  //вывод все элементов
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("MyAtan("+x+") :"+obj_1.result()); //вывод значения моей функции
            Console.WriteLine("Mach.Atan("+x+") :"+ Math.Atan(x)); //вывод значения мат. функции
            Console.WriteLine("Погрешность: "+(Math.Atan(x) - obj_1.result())); //вычисление погрешности
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Объект 2");
            Console.Write("Введите точность: ");
            toch = Convert.ToDouble(Console.ReadLine());  //ввод погрешности для второй части вычислений
            Console.WriteLine("----------------------------------------------------");
            Project obj_2 = new Project(toch,x); //создание объекта 2 с перегруженным конструктором
            Console.Write(obj_2.mass());  //вывод массива необходимого кол-ва элементов
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("MyAtan(" + x + ") :" + obj_2.result()); //вывод значения моей функции с учётом заданной точности
            Console.WriteLine("Mach.Atan(" + x + ") :" + Math.Atan(x)); //вывод значения мат. функции
            Console.WriteLine("Погрешность2: " + (Math.Atan(x) - obj_2.result()));  //вычисление погрешности

            Console.WriteLine("\nНажмите любую клавишу чтобы выйти..."); //завершение программы
            Console.ReadKey();
        }
    }
}
