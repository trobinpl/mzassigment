using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Model
{
    public interface IUserRepository
    {
        Task<User> GetUser(string username);

        Task<List<Repository>> GetRepositoriesBelongingTo(User user);
    }
}
