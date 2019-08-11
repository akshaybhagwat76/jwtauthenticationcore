using ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Entities;
using Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using Repository.Paging;

namespace Repository.Implementation
{
    public class CenterRepository : Repository<Center>, ICenterRepository
    {
        public DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }

        public CenterRepository(DbContext db)
        {
            this.db = db;
        }
        public PagedResult<Center> GetPaged(int pageIndex, int pageSize, string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                return context.Centers.Where(o => o.CenterName.Contains(search) || o.Location.LocationName.Contains(search)).
                    GetPaged(pageIndex, pageSize);
            }
            else
            {
                return GetPaged(pageIndex, pageSize);
            }

        }
    }
}
