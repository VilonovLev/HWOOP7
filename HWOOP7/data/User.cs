using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace HWOOP7.data
{
    internal abstract class User
    {
        private string _id;
        private string _name;
        private string _address;

        protected User(string id, string name, string address)
        {
            _id = id;
            _name = name;
            _address = address;
        }

        protected User(string name, string address)
        {
            _id = Guid.NewGuid().ToString("N");
            _name = name;
            _address = address;
        }

        public string Id { get { return _id; } }

        public string Name { get { return _name; } set { _name = value; } }

        public string Address { get { return _address; } set { _address = value; } }

        public override bool Equals(object? obj)
        {
             if (obj == null) return false;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return $" id:{Id}, name:{Name}, address:{Address}";
        }

    }
}
