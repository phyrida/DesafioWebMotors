using DesafioWebMotors.Data.Context;
using DesafioWebMotors.Domain.Entities;
using DesafioWebMotors.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioWebMotors.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DesafioWebmotorsContext _context;
        private DbSet<T> _dataSet;

        public BaseRepository(DesafioWebmotorsContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var result = await SelectAsync(id);
            if (result == null)
                return false;

            _dataSet.Remove(result);
            _context.SaveChanges();

            return true;
        }

        public async Task<T> InsertAsync(T item)
        {
            await _dataSet.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<T>> SelectActivesAsync(int page, int count)
        {
            if (page == 1) page = 0;

            return await _dataSet
                .Skip(page * 10)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> SelectAsync(long id)
        {
            return await _dataSet
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.ID.Equals(id));
        }

        public async Task<IEnumerable<T>> SelectAsync(int page, int count)
        {
            if (page == 1) page = 0;

            return await _dataSet
                .Skip(page * 10)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> SelectListAsync(Expression<Func<T, bool>> expression)
        {
            return await _dataSet
              .Where(expression)
              .AsNoTracking()
              .ToListAsync();
        }

        public async Task<T> SelectOneAsync(Expression<Func<T, bool>> expression)
        {
            return await _dataSet
              .Where(expression)
              .AsNoTracking()
              .FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            var resultCurrent = await _dataSet.SingleOrDefaultAsync(x => x.ID.Equals(item.ID));
            if (resultCurrent == null)
                return null;

            _context.Entry(resultCurrent).CurrentValues.SetValues(item);

            await _context.SaveChangesAsync();

            return item;
        }
    }
}
