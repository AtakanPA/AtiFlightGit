using AtiFlight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(User user); 
        void UpdateUser(User user);
        List<User> GetAllUsers();
        User GetById(int id);         





    }
}
