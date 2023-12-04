using AtiFlight.Abstract;
using AtiFlight.BusinessLayer.Abstract;
using AtiFlight.Models;

namespace AtiFlight.BusinessLayer.Concrete
{
    public class IllerManager:IIllerService
    {
        IIllerDal _IllerDal;

        public IllerManager(IIllerDal illerDal)
        {
            _IllerDal = illerDal;
        }

        public List<Iller> GetAll()
        {
            return _IllerDal.GetAll();
        }

        public Iller GetById(int id)
        {
           return _IllerDal.GetById(id);
        }

        public void TAdd(Iller t)
        {
          _IllerDal.Insert(t);
        }

        public void TDelete(Iller t)
        {
          _IllerDal.Delete(t);
        }

        public void TUpdate(Iller t)
        {
            _IllerDal.Update(t);
        }
    }
}
