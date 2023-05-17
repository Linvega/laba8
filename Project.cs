using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    abstract class Project_osn   //создание базового абстрактного класса
    {
        public double element(double x_e, int num_e)  //инициализация метода для вычисления значения заданного элемента
        {
            double elem = Math.Pow(-1,num_e) * Math.Pow(x_e,2*num_e+1) / (2*num_e+1); //формула для расчёта 1 элемента
            return elem;  //возвращение значения элемента
        }
    }

    class  Project : Project_osn     //создание дочернего класса
    {
        private double znach, x_trabl;   //инициализация переменных
        private double[] mass_znach;     //инициализация массива
        private int a = 0;
        public Project(double x_c, int num_c)     //создание конструктора 
        {
            x_trabl = x_c;    //считываем значение Х
            a = num_c;        //считываем кол-во элементов для массива
            mass_znach = new double[a];  //указываем кол-во элементов массива
            for (int i = 0; i < a ; i++)   //заполняем массив значения и ищем общее значение
            {
                mass_znach[i] = element(x_c, i);
                znach += element(x_c,i);
            }
        }
        public Project(double t, double x_toch)    //создание перегруженного конструктора
        {
            x_trabl = x_toch;    //считываем Х
            while (Math.Abs(element(x_toch,a)) > t) //ищем необходимое кол-во элементов удовлетворяющее точности
            {
                a++;
            }
            mass_znach = new double[a]; //задаём размер массива
            for (int i = 0; i < a; i++) //заполняем массив и ищем общее значение функции
            {
                mass_znach[i] = element(x_toch,i);
                znach += element(x_toch, i);
            }
        }

        public string mass()    //метод для вывода массива значений
        {
            string ret = ""; //создание строковой переменной
            for (int i = 0; i < a; i++)  //цикл для заполнения переменной значениями массива
            {
                int need = 25;               //сдесь начинается сложная и корявая система отступов
                if (element(x_trabl, 0) > 0) //проверяем минусовой первый элемент или нет
                {
                    if ((i + 1) % 2 != 0) { need++; }    //сдесь
                }                                        //настраивается
                else                                     //выравнивание
                {                                        //в зависимости
                    if ((i + 1) % 2 == 0) { need++; }    //от знака
                }                                        //и размера
                if ((i + 1) / 10 < 1) { need++; }        //числа  
                if ((i + 1) / 100 < 1) { need++; }       //работает до 3-х значных чисел включительно
                ret += (i + 1) + (new String(' ', need)) + mass_znach[i] + "\n"; //постепенно заполняем переменную значениями
            }
            return ret; //возвращаем гиганскую строку данных
        }

        public double result()  //метод для вывода результата расчётов функции
        {
            return znach;
        }
    }
}
