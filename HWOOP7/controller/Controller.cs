using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HWOOP7.data;
using HWOOP7.service;

namespace HWOOP7.controller
{
    internal class Controller
    {
        private ContractService contractService = new ContractService();
        private VisitService visitService = new VisitService();
        private Contract<User, Car> contract;

        public void showContract() 
        {
            Console.WriteLine("Введите id контракта");
            string contractId = Console.ReadLine();
            contract = contractService.GetContract(contractId);
            if (contract != null) { Console.WriteLine(contract); }
        }

        public void AddCarToContract() 
        {
            string[] args = { "id контракта", "модель", "цвет", "номер" };
            for(int i = 0; i < args.Length; i++) 
            { 
                Console.WriteLine($"Введите {args[i]}"); 
                args[i] = Console.ReadLine(); 
            }
            contractService.AddCar(args[0], args[1], args[2], args[3]);
        }

        public void CheckIn() 
        {
            Console.WriteLine("Введите id машины");
            string carId = Console.ReadLine();
            visitService.AddVisit(carId);
        }
        public void CheckOut()
        {
            Console.WriteLine("Введите id машины");
            string carId = Console.ReadLine();
            visitService.EndVisit(carId);
        }

        internal void CreateContract()
        {
            Dictionary<string, string> args = GetDictArgs();

            Console.WriteLine("Введите дату окончания договора в формате: dd.mm.yy ");
            DateTime dateTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("юр.лицо введите: 1\nфиз.лицо введите: 2");
            string input = Console.ReadLine();
            User user;
            
            if (int.TryParse(input, out _)) 
                {
                Console.WriteLine("Name :");
                args["name"] = Console.ReadLine();
                Console.WriteLine("Address :");
                args["address"] = Console.ReadLine();
                switch (int.Parse(input))
                    {
                    case 1:
                        Console.WriteLine("INN :");
                        args["inn"] = Console.ReadLine();
                        user = Company.Create(args["inn"], args["name"], args["address"]);
                        contractService.CreateContract(user, dateTime);
                        break;
                    case 2:
                        Console.WriteLine("Last Name :");
                        args["lastName"] = Console.ReadLine();
                        Console.WriteLine("Passport Number :");
                        args["passportNumber"] = Console.ReadLine();
                        user = Person.Create(args["lastName"], args["passportNumber"], args["name"], args["address"]);
                        contractService.CreateContract(user, dateTime);
                        break;
                   default:
                        Console.WriteLine("Ошибка ввода!");
                        return;
                    }
                }
            
        }

        private Dictionary<string,string> GetDictArgs()
        {
            Dictionary<string, string> args = new Dictionary<string, string>()
            {
                {"lastName",""},
                {"inn",""},
                {"id",""},
                {"name",""},
                {"address",""},
                {"passportNumber",""}
            };
            return args;
        }

        internal void ShowAll()
        {
            Console.WriteLine(contractService.GetAllContracts());
            Console.WriteLine(visitService.GetAllVisits());
        }
    }
}
