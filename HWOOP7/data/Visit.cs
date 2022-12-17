using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWOOP7.data
{
    internal class Visit
    {
        private string _id;
        private string _carId;
        private DateTime _checkIn;
        private DateTime _checkOut;

        private Visit(string id, string carId, DateTime checkIn, DateTime checkOut)
        {
            _id = id;
            _carId = carId;
            _checkIn = checkIn;
            _checkOut = checkOut;
        }

        private Visit(string carId)
        {
            _id = Guid.NewGuid().ToString("N");
            _carId = carId;
            _checkIn = DateTime.Now;
            _checkOut = new DateTime();
        }

        public static Visit Create(Car car) { return new Visit(car.Id); }

        public static Visit Load(string id, string carId, DateTime checkIn, DateTime checkOut)
        {
            return new Visit(id,carId,checkIn,checkOut);
        }

        public void closeVisit()
        {
            _checkOut = DateTime.Now;
        }

        public string Id { get { return _id; } }

        public string CarId { get { return _carId; } }

        public DateTime CheckIn { get { return _checkIn; } }

        public DateTime CheckOut { get { return _checkOut; } }

        public override string ToString()
        {
            return $"IdVisit:{Id} CarId:{CarId} CheckIn:{CheckIn} CheckOut:{CheckOut}";
        }
    }


}
