using POS.Infraestructura.Commons.Bases.Request;
using POS.Infraestructura.Helpers;
using POS.Infraestructura.Persistemces.Interface;
using System.Linq.Dynamic.Core;

namespace POS.Infraestructura.Persistemces.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected IQueryable<TDTO> Ordering<TDTO>(BasePaginationsRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            IQueryable<TDTO> queryDto = request.Order == "desc" ? queryable.OrderBy($"{request.sort} descending") : queryable.OrderBy($"{request.sort} ascending");
            if (pagination) queryDto = queryDto.Paginate(request);
            return queryDto;
        }
    }
}
