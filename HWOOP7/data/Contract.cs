using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HWOOP7.data
{
    internal class Contract<U, C> 
        where U : User 
        where C : Car
    {
        
        private string _id;
        private U _user;
        private List<C> _cars;
        private DateTime _dateStart;
        private DateTime _dateEnd;

        private Contract(string id, U user, List<C> cars, DateTime dateStart, DateTime dateEnd)
        {
            _id = id;
            _user = user;
            _cars = cars;
            _dateStart = dateStart;
            _dateEnd = dateEnd;
        }

        private Contract(U user, DateTime dateEnd)
        {
            _id = Guid.NewGuid().ToString("N");
            _user = user;
            _cars = new List<C>();
            _dateStart = DateTime.Now;
            _dateEnd = dateEnd;
        }

        public static Contract<U,C> Create(U user, DateTime dateEnd)
        {
            return new Contract<U,C>(user, dateEnd);
        }

        public static Contract<U,C> Load(string id, U user, List<C> cars, DateTime dateStart, DateTime dateEnd)
        {
            return new Contract<U, C>(id, user, cars, dateStart,dateEnd);
        }

        [JsonPropertyName("Contract ID")]
        public string Id { get { return _id; } }

       // [JsonPropertyName($"{_user.GetType()}")]
        public U GetUser { get { return _user; } }

        public List<C> Cars { get { return _cars; } set { _cars = value; } }

        public void AddCar(Car car) { _cars.Add((C)car); }

        public DateTime DateStart { get { return _dateStart; } }

        public DateTime DateEnd { get { return _dateEnd; } set { _dateEnd = value; } }

        public override string? ToString()
        {
            string _class = _user.GetType().Name;
            return $"\nidContaract:{Id}\n {_class}:\n{GetUser}\n Cars:{string.Join(",",Cars)} \nDateStart:{DateStart} \nDataEnd:{DateEnd}\n----------------------------------------------------";
        }
    }
}
