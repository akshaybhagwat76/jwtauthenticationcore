using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using ApplicationCore;
using Repository.Implementation;
using Microsoft.AspNetCore.Identity;
using DomainModels.Entities;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext db;
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        public UnitOfWork(DatabaseContext _db, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            db = _db;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        private IAuthenticateRepository _AuthenticateRepo;
        public IAuthenticateRepository AuthenticateRepo
        {
            get
            {
                if (_AuthenticateRepo == null)
                    _AuthenticateRepo = new AuthenticateRepository(db, userManager, signInManager);

                return _AuthenticateRepo;
            }
        }

        private ICenterRepository _CenterRepo;
        public ICenterRepository CenterRepo
        {
            get
            {
                if (_CenterRepo == null)
                    _CenterRepo = new CenterRepository(db);

                return _CenterRepo;
            }
        }
        private IStudentRepository _StudentRepo;
        public IStudentRepository StudentRepo
        {
            get
            {
                if (_StudentRepo == null)
                    _StudentRepo = new StudentRepository(db);

                return _StudentRepo;
            }
        }
        private IClassRepository _ClassRepo;
        public IClassRepository ClassRepo
        {
            get
            {
                if (_ClassRepo == null)
                    _ClassRepo = new ClassRepository(db);

                return _ClassRepo;
            }
        }
        private ILocationRepository _LocationRepo;
        public ILocationRepository LocationRepo
        {
            get
            {
                if (_LocationRepo == null)
                    _LocationRepo = new LocationRepository(db);

                return _LocationRepo;
            }
        }
        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
