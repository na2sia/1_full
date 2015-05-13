using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CheckPoint1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file_candy = File.ReadAllLines("Candy.txt");
            string[] file_biscuit = File.ReadAllLines("Biscuit.txt");
            string[] file_chocolate = File.ReadAllLines("Chocolate.txt");

            GiftSweets MyGift = new GiftSweets(); 
            //Добавляем в коллекцию объекты (поля заполняем данными из соответствующего файла)
            foreach (string item in file_candy)
            {
                string[] str = item.Split(';'); 
                MyGift.Add(new Candy(str[0], double.Parse(str[1]), double.Parse(str[2]), double.Parse(str[3]), (Stuffing)Enum.Parse(typeof(Stuffing),str[4]))); 
            }
            foreach (string item in file_biscuit)
            {
                string[] str = item.Split(';');
                MyGift.Add(new Biscuit(str[0], double.Parse(str[1]), double.Parse(str[2]), double.Parse(str[3]),(TypeBiscuit)Enum.Parse(typeof(TypeBiscuit),str[4])));
            }
            foreach (string item in file_chocolate)
            {
                string[] str = item.Split(';');
                MyGift.Add(new Chocolate(str[0], double.Parse(str[1]), double.Parse(str[2]), double.Parse(str[3]),double.Parse(str[4])));
            }
            //Вызываем метод выборки данных (содержание сахара)
            double starts = 5;
            double ends = 20;
            Console.WriteLine("Сладости с содержанием сахара  от {0} до {1} грамм", starts,ends);
            //Выводим результат выборки в консоль
            foreach (var i in MyGift.GetSweets(starts, ends))
            {
                if (i is Candy)
                {
                   Console.WriteLine("Конфета {0}, содержит {1} грамм сахара", i.Name, i.Sugar);
                }
                if (i is Biscuit)
                {
                    Console.WriteLine("Печенье {0}, содержит {1} грамм сахара", i.Name, i.Sugar);
                }
                if (i is Chocolate)
                {
                    Console.WriteLine("Шоколад {0}, содержит {1} грамм сахара", i.Name, i.Sugar);
                }
            }
            //Вызываем метод для сортировки по цене
            Console.WriteLine();
            Console.WriteLine("Сортируем по цене:");
            MyGift.SortByPrice();
            //Выводим результат сортировки в консоль
            foreach (var i in MyGift)
            {
                Console.WriteLine("{0}, {1}", i.Name, i.Price);
            }
            //Вызываем метод вычисления общей массы подарка и выводим результат в консоль
            Console.WriteLine();
            Console.WriteLine("Общий вес подарка {0} грамм", MyGift.TotalWeight());
            Console.ReadKey();
        }
    }
}
