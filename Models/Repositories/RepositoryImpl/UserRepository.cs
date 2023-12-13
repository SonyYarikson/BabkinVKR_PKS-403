using Microsoft.EntityFrameworkCore;
using Models.DataContext;
using Models.Repositories.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Models.Repositories.RepositoryImpl
{
    public class UserRepository : IUserRepository
    {
        private DashBoardDataContext _dashBoardDataContext;

        public UserRepository(DashBoardDataContext dataContext)
        {
            _dashBoardDataContext = dataContext;
        }

        public async Task AddItem(User item)
        {
            await _dashBoardDataContext.Users.AddAsync(item);
            await _dashBoardDataContext.SaveChangesAsync();
        }

        public async Task AddItem(IEnumerable<User> items)
        {
            await _dashBoardDataContext.Users.AddRangeAsync(items);
            await _dashBoardDataContext.SaveChangesAsync();
        }

        public async Task DeleteItem(User item)
        {
            _dashBoardDataContext.Users.Remove(item);
            await _dashBoardDataContext.SaveChangesAsync();
        }

        public async Task DeleteItem(IEnumerable<User> items)
        {
            _dashBoardDataContext.Users.RemoveRange(items);
            await _dashBoardDataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetListOfItem()
        {
            return await _dashBoardDataContext.Users.ToListAsync();
        }

        public User? GetUserByLoginAndPassword(string login, string password)
        {
            
                var result = _dashBoardDataContext.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

                return result;
            

        }

        public async Task<IEnumerable<User>> GetUsersByRole(Guid roleId)
        {
            var result = await _dashBoardDataContext.Users.Where(u => u.RoleID == roleId).ToListAsync();

            if (result == null) throw new Exception();
            return result;
        }

        public async Task UpdateItem(User item)
        {
            _dashBoardDataContext.Update(item);
            await _dashBoardDataContext.SaveChangesAsync();
        }
    }
}
