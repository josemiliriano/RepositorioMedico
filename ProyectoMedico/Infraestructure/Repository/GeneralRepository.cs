using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infraestructure.Repository
{
    public class GeneralRepository<T> where T : class
    {
        private readonly MyDataContext _context;
        public GeneralRepository(MyDataContext context)
        {
            _context = context;
        }
        public async Task<T>AddSync(T entity)
        {
            _context.AddAsync(entity);
            _context.SaveChangesAsync();
            return entity;
        }

        public Task<List<T>> GetAll()
        {
           return _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(int id)        {
            
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T>Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<T> SoftDelete(T entity)
        {
            _context.Update(entity);
            _context.SaveChangesAsync();
            return entity;
        }
        public async Task<List<T>> GetAllByCondition(Expression<Func<T, bool>> IsDelete)
        {
            return await _context.Set<T>().Where(IsDelete).ToListAsync();
        }
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> condition)
        {
            return await _context.Set<T>().AnyAsync(condition);
        }
    }
}
