using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services.Interfaces
{
    public interface IAuthoriseService
    {
        User? TryAuthorizeUser(string login, string password);
        Task<User> RegistrateUser(User user);

    }
}
