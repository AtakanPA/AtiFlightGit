using AtiFlight.Abstract;
using AtiFlight.Models;
using AtiFlight.Repository;

namespace AtiFlight.EntityFramework
{
    public class EfIllerRepository:GenericRepository<Iller>,IIllerDal
    {
    }
}
