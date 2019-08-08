using ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Abstraction;
using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Implementation;

namespace Repository.Implementation
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }

        public StudentRepository(DbContext db)
        {
            this.db = db;
        }
    }
}
