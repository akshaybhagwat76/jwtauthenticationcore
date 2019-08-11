using ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Entities;
using Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using Repository.Implementation;
using Repository.Paging;

namespace Repository.Implementation
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        private DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }

        public ClassRepository(DbContext db)
        {
            this.db = db;
        }

        public PagedResult<Class> GetPaged(int pageIndex, int pageSize, string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                return context.Classes.Where(o => o.ClassName.Contains(search)).
                    GetPaged(pageIndex, pageSize);
            }
            else
            {
                return GetPaged(pageIndex, pageSize);
            }

        }
    }
}
