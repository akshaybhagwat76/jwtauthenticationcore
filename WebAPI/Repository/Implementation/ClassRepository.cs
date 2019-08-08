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

      
    }
}
