using HWOOP7.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWOOP7.app
{
    internal class App
    {
        static List<string> mes = new List<string>() { "1 : Получить договор", "2 : Добавить автомобиль", "3 : Машина прибыла", "4 : Машина уехала", "5 : Новый договор" };
        
        public static void Run()
        {
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
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:

                        break;
                    default:
                        return;
                }
            }
        }

    }
}
