using AtiFlight.Abstract;
using AtiFlight.BusinessLayer.Abstract;
using AtiFlight.Models;

namespace AtiFlight.BusinessLayer.Concrete
{
    public class FlyRouteManager:IFlyRouteService
    {
        IFlyRouteDal _flyRoute;
        public FlyRouteManager(IFlyRouteDal flyRouteDal)
        {
            _flyRoute = flyRouteDal;    
        }

        public List<FlyRoute> GetAll()
        {
           return _flyRoute.GetAll();
        }

        public FlyRoute GetById(int id)
        {
            return _flyRoute.GetById(id);
        }

        public void TAdd(FlyRoute t)
        {
            _flyRoute.Insert(t);
        }

        public void TDelete(FlyRoute t)
        {
           _flyRoute.Delete(t);
        }

        public void TUpdate(FlyRoute t)
        {
           _flyRoute.Update(t);
        }
    }
}
