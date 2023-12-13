using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories.RepositoryInterfaces
{
    
        public interface IUserRepository : IBaseRepository<User>
        {
            Task<IEnumerable<User>> GetUsersByRole(Guid roleId);

            User? GetUserByLoginAndPassword(string login, string password);
        }
    
}
