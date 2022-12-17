using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWOOP7.data;

namespace HWOOP7.service
{
    internal interface IUserService<U> where U : User
    {
        public U Create(Dictionary<string, string> data);

        public U Load(Dictionary<string, string> data);
    }
}
