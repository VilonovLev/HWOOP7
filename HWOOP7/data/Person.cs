using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWOOP7.data
{
    internal class Person : User
    {
        private string _lastName;

        private string _passportNumber;

        private Person(string lastName, string passportNumber, string id, string name, string address) 
            : base(id,name, address) 
        {
            _lastName = lastName;
            _passportNumber = passportNumber;
        }

        private Person(string lastName, string passportNumber, string name, string addres)
            : base(name,addres)
        {
            _lastName = lastName;
            _passportNumber = passportNumber;
        }

        public static Person Create(string lastName, string passportNumber, string name, string address)
        {
            return new Person(lastName, passportNumber, name, address);
        }

        public static Person Load(string lastName, string passportNumber, string id, string name, string address)
        {
            return new Person(lastName, passportNumber, id, name, address);
        }

        public string LastName { get { return _lastName; } set { this._lastName = value; } }

        public string PassportNamber { get { return _passportNumber; } set { this._passportNumber = value; } }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            Person person = obj as Person;
            return base.Equals(obj) && this._lastName.Equals(person.LastName) 
                && this._passportNumber.Equals(person.PassportNamber);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return $"{base.ToString()}, last name:{this.LastName}, passport number:{this.PassportNamber}";
        }
    }
}
