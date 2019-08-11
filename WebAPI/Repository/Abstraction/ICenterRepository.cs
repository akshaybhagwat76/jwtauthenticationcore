using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Entities;
using Repository.Paging;

namespace Repository.Abstraction
{
    public interface ICenterRepository : IRepository<Center>
    {
        PagedResult<Center> GetPaged(int pageIndex, int pageSize, string search);
    }
}
