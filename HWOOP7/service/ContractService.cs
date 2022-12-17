using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HWOOP7.data;

namespace HWOOP7.service
{
    internal class ContractService
    {
        private static List<Contract<User, Car>> _contracts = new List<Contract<User, Car>>();
        
        public void CreateContract(User user,DateTime dateTime)
        {
            _contracts.Add(Contract<User, Car>.Create(user, dateTime));
        }
        public static List<Contract<User, Car>> GetContracts() { return _contracts; }
        public Contract<User, Car> GetContract(string contractId)
        {
                for (int i = 0; i < _contracts.Count; i++)
                {
                    if (_contracts[i].Id == contractId) { return _contracts[i]; } 
                }
            return null;
        }


        public void AddCar(string contractId, string model, string color, string number)
        {
            Contract<User, Car> contract = GetContract(contractId);
            if(contract!= null) 
            { 
                contract.AddCar(Car.Create(model,color,number));
                Console.WriteLine("Автомобиль добавлен");
                return;
            }
            Console.WriteLine("Договор не найден!");
        }

        public List<Contract<User, Car>> Contracts { get { return _contracts; } set{ _contracts = value; } }

        internal string GetAllContracts()
        {
            string result = string.Empty;
            foreach(var contract in _contracts) 
            {
                result += contract.ToString();
            }

            return result; 
        }
    }
}
