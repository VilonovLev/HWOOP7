using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWOOP7.data
{
    internal class Company : User
    {
        private string _inn;

        private Company(string inn, string id, string name, string address) : base(id, name, address) => _inn = inn;
        private Company(string inn, string name, string address) : base(name, address) => _inn = inn;

        public static Company Create(string inn, string name, string address)
        {
            return new Company(inn, name, address);
        }

        public static Company Load(string inn, string id,  string name, string address)
        {
            return new Company(id, inn, name, address);
        }

        public string Inn { get { return _inn; } set { _inn = value; } }    

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            Company company = obj as Company;
            return base.Equals(obj) && this._inn.Equals(company.Inn);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return $"{base.ToString()}, INN:{this.Inn}";
        }
    }
}
