using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string Id { get { return _id; } }

        public U GetUser { get { return _user; } }

        public List<C> Cars { get { return _cars; } set { _cars = value; } }

        public DateTime DateStart { get { return _dateStart; } }

        public DateTime DateTimeEnd { get { return _dateEnd; } set { _dateEnd = value; } }
    }
}
