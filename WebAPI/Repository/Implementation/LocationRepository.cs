using ApplicationCore;
using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Abstraction;
using Repository.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Implementation
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        private DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }

        public LocationRepository(DbContext db)
        {
            this.db = db;
        }

        public PagedResult<Location> GetPaged(int pageIndex, int pageSize, string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                return context.Locations.Where(o => o.LocationName.Contains(search)).GetPaged(pageIndex, pageSize);
            }
            else
            {
                return GetPaged(pageIndex, pageSize);
            }

        }
    }
}
