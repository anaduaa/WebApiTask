using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Iservice
{
    public interface IUserService
    {
        public bool ValidateCredentials(string username, string password);
    }
        
}
