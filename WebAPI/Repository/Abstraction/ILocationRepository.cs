using DomainModels.Entities;
using Repository.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstraction
{
    public interface ILocationRepository : IRepository<Location>
    {
        PagedResult<Location> GetPaged(int pageIndex, int pageSize, string search);
        
    }
}
