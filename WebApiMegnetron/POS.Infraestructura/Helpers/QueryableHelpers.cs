using POS.Infraestructura.Commons.Bases.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructura.Helpers
{
    public static class QueryableHelpers
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, BasePaginationsRequest request)
        { 
            return queryable.Skip((request.NumPage -1) * request.Records).Take(request.Records);
        }
    }
}
