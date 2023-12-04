using AtiFlight.Models;

namespace AtiFlight.BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {


        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> GetAll();
        T GetById(int id);




    }
}
