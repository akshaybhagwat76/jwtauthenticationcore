using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork
    {
        IAuthenticateRepository AuthenticateRepo { get; }
        ICenterRepository CenterRepo { get; }
        IClassRepository ClassRepo { get; }
        IStudentRepository StudentRepo { get; }

        int SaveChanges();
    }
}
