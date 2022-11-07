using DAL.Models;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private WarehouseContext _context;
        private GenericRepository<Category> _categoryRepository;
        private GenericRepository<Good> _goodRepository;
        private GenericRepository<Vendor> _vendorRepository;

        public UnitOfWork()
        {
            var contextOptions = new DbContextOptionsBuilder<WarehouseContext>()
                .UseSqlServer(@"Server=DESKTOP-7SP73R7;Database=HiMarsWarehouse_db;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            _context = new WarehouseContext(contextOptions);
        }
        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new GenericRepository<Category>(_context);
                }
                return _categoryRepository;
            }
        }

        public GenericRepository<Good> GoodRepository
        {
            get
            {
                if (this._goodRepository == null)
                {
                    this._goodRepository = new GenericRepository<Good>(_context);
                }
                return _goodRepository;
            }
        }

        public GenericRepository<Vendor> VendorRepository
        {
            get
            {

                if (this._vendorRepository == null)
                {
                    this._vendorRepository = new GenericRepository<Vendor>(_context);
                }
                return _vendorRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
