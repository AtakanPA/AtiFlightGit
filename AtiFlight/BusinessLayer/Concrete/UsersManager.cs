using AtiFlight.Abstract;
using AtiFlight.Models;
using AtiFlight.BusinessLayer.Abstract;

namespace AtiFlight.BusinessLayer.Concrete
{
    public class UsersManager : IUserService
    {
        IUserDal _userDal;

  
        public UsersManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

     

        public List<User> GetAll()
        {
          return _userDal.GetAll();
        }

        public User GetById(int id)
        {
           return _userDal.GetById(id);
        }

        public void TAdd(User t)
        {
            _userDal.Insert(t);
        }

        public void TDelete(User t)
        {
            _userDal.Delete(t);
        }

        public void TUpdate(User t)
        {
            _userDal.Update(t);
        }

    
    }
}
