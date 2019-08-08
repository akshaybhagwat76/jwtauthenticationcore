using ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Entities;
using Repository.Abstraction;
using Microsoft.EntityFrameworkCore;

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

    }
}
