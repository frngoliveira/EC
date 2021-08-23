using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class
    {

        public readonly DbContextOptions<Context> Db;
        public RepositoryBase()
        {
            Db = new DbContextOptions<Context>();
        }

        public async Task Add(TEntity obj)
        {
            using (var data = new Context(Db))
            {
                await data.Set<TEntity>().AddAsync(obj);
                await data.SaveChangesAsync();
            }            
        }

        public async Task<List<TEntity>> GetAll()
        {
            using (var data = new Context(Db))
            {
                return await data.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<List<TEntity>> GetLastList()
        {
            using (var data = new Context(Db))
            {
                return await data.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            using (var data = new Context(Db))
            {
                return await data.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task Remove(TEntity obj)
        {
            using (var data = new Context(Db))
            {
                data.Set<TEntity>().Remove(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task Update(TEntity obj)
        {
            using (var data = new Context(Db))
            {
                data.Set<TEntity>().Update(obj);
                await data.SaveChangesAsync();
            }
        }


        // implementação dispose
        bool disposed = false;

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }
    }
}