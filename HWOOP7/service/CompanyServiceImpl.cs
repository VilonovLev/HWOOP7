using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWOOP7.data;

namespace HWOOP7.service
{
    internal class CompanyServiceImpl
    {
        public Company Create(Dictionary<string, string> data)
        {
            return Company.Create(data["inn"], data["name"], data["address"]);
        }
        public Company Load(Dictionary<string, string> data)
        {
            return Company.Load(data["inn"], data["id"], data["name"], data["address"]);
        }
    }
}
