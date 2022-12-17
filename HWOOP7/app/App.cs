using HWOOP7.data;
using HWOOP7.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWOOP7.app
{
    internal class App
    {
        static List<string> mes = new List<string>() { "1 : Найти контракт", "2 : Добавить автомобиль", "3 : Машина прибыла", "4 : Машина уехала", "5 : Новый договор", "6 : Показать инфо" };
        
        public static void Run()
        {
            Controller controller = new Controller();
            Console.WriteLine("Приложение запущено!");
            Contract<User,Car>? CurrentContract;
            Car? CurrentCar; 

            while (true)
            {
                mes.ForEach(Console.WriteLine);
                string input;
                switch (Convert.ToUInt32(input = Console.ReadLine()))
                {
                    case 1:
                        controller.showContract();
                        break;
                    case 2:
                        controller.AddCarToContract();
                        break;
                    case 3:
                        controller.CheckIn();
                        break;
                    case 4:
                        controller.CheckOut();
                        break;
                    case 5:
                        controller.CreateContract();
                        break;
                    case 6:
                        controller.ShowAll();
                        break;
                    default:
                        return;
                }
            }
        }

    }
}
