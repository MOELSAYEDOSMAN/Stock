using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Stock.Service.BaseModelService
{
    public class BaseService<T> : IBaseService<T>, IPrivateService<T> where T : class
    {
        protected readonly ApplicationDataBaseContext _db;
        public BaseService(ApplicationDataBaseContext db)
        {
            _db = db;
        }
        
        public async Task<T?> GetAsync(Guid id)
        {
            var table = _db.Set<T>();
            return await table.FindAsync(id);
        }


        
        public async Task<IList<T>> GetListAsync()
        {
            var table = _db.Set<T>();
            return await table.ToListAsync();
        }


        
        public async Task<T> AddAsync(T input)
        {
            var value= await _db.Set<T>().AddAsync(input);
            await SaveChangesAsync();
            return value.Entity;
        }


        
        public async Task<T> UpdateAsync(T input)
        {
            var value = _db.Set<T>().Update(input);
            await SaveChangesAsync();
            return value.Entity;
        }


        
        public async Task<bool> DeleteAsync(T input)
        {
            try
            {
                var v = _db.Set<T>().Remove(input);
                await SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        
        public async Task<IList<T>> FindAsync(Expression<Func<T, bool>> condation, string[]? inculde = null, bool AsTraking = false,Expression<Func<T, object>>? OrderBy = null)
        {
            IQueryable<T> query = _db.Set<T>();
            if(OrderBy!=null)
                query = query.OrderBy(OrderBy);
            if (inculde != null)
                foreach (var incluse in inculde)
                    query = query.Include(incluse);
            return AsTraking? await query.AsNoTracking().Where(condation).ToListAsync() : await query.Where(condation).ToListAsync();
        }

      
        public async Task<T?> FindByAsync(Expression<Func<T, bool>> condation, string[]? inculde = null, bool AsTraking = false)
        {
            IQueryable<T> query = _db.Set<T>();
            if (inculde != null)
                foreach (var incluse in inculde)
                    query = query.Include(incluse);
            return AsTraking? await query.AsNoTracking().SingleOrDefaultAsync(condation) : await query.SingleOrDefaultAsync(condation);
        }
        
        
        
        public async Task<int> CountAsync()
        => await _db.Set<T>().CountAsync();


        public async Task SaveChangesAsync()
        {
           await _db.SaveChangesAsync();
        }
    }
}
