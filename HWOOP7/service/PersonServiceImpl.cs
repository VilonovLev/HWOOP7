using HWOOP7.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWOOP7.service
{
    internal class UserServiceImpl
    {
        public Person Create(Dictionary<string, string> data)
        {
            return Person.Create(data["lastName"], data["passportNumber"], data["name"], data["address"]);
        }
        public Person Load(Dictionary<string, string> data)
        {
            return Person.Load(data["lastName"], data["passportNumber"], data["id"], data["name"], data["address"]);
        }
    }
}
