using AtiFlight.Abstract;
using AtiFlight.Models;
using BusinessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class UsersManager : IUserService
    {
        IUserDal _userDal;

  
        public UsersManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddUser(User user)
        {
            _userDal.Insert(user);
        }

        public void DeleteUser(User user)
        {
            _userDal.Delete(user);
        }

        public List<User> GetAllUsers()
        {
          return _userDal.GetAll();
        }

        public User GetById(int id)
        {
           return _userDal.GetById(id);
        }

        public void UpdateUser(User user)
        {
            _userDal.Update(user);   
        }
    }
}
