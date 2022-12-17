using HWOOP7.data;
using HWOOP7.service;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWOOP7.service
{
    internal class VisitService
    {
        private CarService carService = new CarService();
        private static List<Visit> _visits = new List<Visit>();
        public Visit Create(Car car)
        {
           return Visit.Create(car);
        }

        public Visit Load(string id, string carId, DateTime checkIn, DateTime checkOut) 
        { 
            return Visit.Load(id, carId, checkIn, checkOut);    
        }

        public Visit closeVisit(Visit visit) 
        {
            if (visit != null)
            {
                visit.closeVisit();
            }
            return visit;
        }

        public void AddVisit(string carId)
        {
            foreach (var contract in ContractService.GetContracts())
            {
                foreach (var car in contract.Cars)
                {
                    if (carService.GetIdCar(car) == carId)
                    {
                        _visits.Add(Visit.Create(car));
                        Console.WriteLine("Check in");
                        return;
                    }
                }
            }
            Console.WriteLine("Данного автомобиля нет в системе!");
        }

        public void EndVisit(string carId)
        {
            foreach (var visit in _visits)
            {
                if (visit.CarId == carId && visit.CheckOut == new DateTime())
                {
                    visit.closeVisit();
                    Console.WriteLine("check out");
                    return;
                }
            }
            Console.WriteLine("Ошибка, нет отметки о прибытие!");
        }

        public void LoadVisits(List<Visit> visits)
        {
            _visits = visits;
        }

        internal string GetAllVisits()
        {
            string result;

            return String.Join("\n", _visits);
        }
    }
}
