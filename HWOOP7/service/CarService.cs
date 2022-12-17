using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWOOP7.data;

namespace HWOOP7.service
{
    internal class CarService
    {
        public Car Create(string model,string color, string namber)
        {
            return Car.Create(model,color,namber);
        }
        public Car Load(string id, string model, string color, string namber)
        {   
            return Car.Load(id, model, color, namber);
        }

        internal string GetIdCar(Car car)
        {
            return car.Id;
        }
    }
}
