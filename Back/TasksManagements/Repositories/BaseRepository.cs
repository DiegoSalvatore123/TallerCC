//using Microsoft.EntityFrameworkCore;
//using TasksManagements.Interfaces;
//using TasksManagements.Repositories.DbContext;

//namespace TasksManagements.Repository
//{
//    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
//    {
//        private readonly DbContextInMemory _context;

//        private bool isDisposed;

//        public BaseRepository(DbContextInMemory context)
//        {
//            this._context = context;
//        }

//        public async Task<TEntity> GetById(int id)
//        {
//            return await _context.Set<TEntity>().FindAsync(id);
//        }

//        public async Task<List<TEntity>> GetAll()
//        {
//            return await _context.Set<TEntity>().ToListAsync();
//        }

//        public async Task<int> GetEntityID(TEntity obj)
//        {
//            var maxId = _context.Set<TEntity>()
//                             .Select(e => EF.Property<int?>(e, "Id"))
//                             .Max();
//           return maxId ?? 0;
//        }

//        public async Task InsertEntity(TEntity obj)
//        {
//            _context.Set<TEntity>().Add(obj);
//            await _context.SaveChangesAsync();
//        }

//        public async Task<bool> DeleteById(int id)
//        {
//            var item = await GetById(id);

//            if (item != null)
//            {
//                _context.Set<TEntity>().Remove(item);
//                await _context.SaveChangesAsync();
//                return true;
//            }

//            return false;
//        }
//        public async Task<bool> Update(int id, TEntity obj)
//        {
//            var item = await GetById(id);

//            if (item != null)
//            {
//                _context.Set<TEntity>().Update(obj);
//                await _context.SaveChangesAsync();
//                return true;
//            }

//            return false;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            if (isDisposed) return;

//            if (disposing)
//            {
//                _context.Dispose();
//            }

//            isDisposed = true;
//        }
//    }
//}
