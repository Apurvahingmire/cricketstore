using CricketStore.DAL.dbcontext;
using CricketStore.DAL.entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.ConstrainedExecution;

namespace CricketStore.DAL.repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(int id, T entity);

        Task<bool> DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync(params string[] navsToInclude);

        Task<T?> GetById(int id);

        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition);
    }

    public abstract class RepositoryBase<T> : IBaseRepository<T> where T : class
    {
        private readonly CricketStoreDBContext dbContext;

        private readonly DbSet<T> dbSet;

        public RepositoryBase(CricketStoreDBContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();   
        }

        public async Task<T> CreateAsync(T entity)
        {
            var result = await this.dbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {

            var result = this.dbSet.Remove(entity);

            return await Task.FromResult(result.Entity is not null);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] navsToInclude)
        {
            IQueryable<T> query = this.dbSet;
            if (navsToInclude.Length > 0)
            {
                foreach (var item in navsToInclude)
                {
                    query = query.Include(item);
                }
            }
            var result = query.AsEnumerable();
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition)
        {
            var result = this.dbSet.Where(condition);
            return await Task.FromResult(result.AsEnumerable());
        }

        public async Task<T?> GetById(int id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            var result = this.dbSet.Update(entity);
            return await Task.FromResult(result.Entity);
        }
    }

    public interface ICartDetailRepository : IBaseRepository<CartDetail> { }

    public class CartDetailRepository : RepositoryBase<CartDetail>, ICartDetailRepository
    {
        public CartDetailRepository(CricketStoreDBContext dbContext) : base(dbContext)
        {

        }
    }

    public interface IBrandRepository : IBaseRepository<Brand> { }

    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(CricketStoreDBContext dbContext) : base(dbContext)
        {

        }
    }

    public interface ICartRepository : IBaseRepository<Cart> 
    { 

    }

    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(CricketStoreDBContext dbContext) : base(dbContext)
        {

        }

    }
    public interface ILogInRepository : IBaseRepository<User>
    {
        Task<User?> ValidateUser(string email, string password);
    }

    public class LogInRepository : RepositoryBase<User>, ILogInRepository
    {
        private readonly CricketStoreDBContext dbContext;

        public LogInRepository(CricketStoreDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User?> ValidateUser(string email, string password)
        {
            var user = await dbContext.Users
            //.Include(x => x.IsAdmin)
            .FirstOrDefaultAsync(x => x.Email == email && x.PasswordHash == password);
            if (user is not null) return user;
            return null;

        }
    }

    public interface IUserRepository : IBaseRepository<User> { }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CricketStoreDBContext dbContext) : base(dbContext)
        {

        }
    }

    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByBrandId(int brandId);
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        private readonly CricketStoreDBContext dbContext;
        public ProductRepository(CricketStoreDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandId(int brandID)
        {
            var result = await dbContext.Products.Where(model => model.BrandId == brandID).ToListAsync();
            return result;
        }
    }

    public interface IOrderRepository : IBaseRepository<Order> { }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(CricketStoreDBContext dbContext) : base(dbContext)
        {

        }
    }

    public interface IRoleRepository : IBaseRepository<Role> { }

    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(CricketStoreDBContext dbContext) : base(dbContext)
        {

        }
    }

    public interface IOderDetailRepository : IBaseRepository<OderDetail> { }

    public class OderDetailRepository : RepositoryBase<OderDetail>, IOderDetailRepository
    {
        public OderDetailRepository(CricketStoreDBContext dbContext) : base(dbContext)
        {

        }
    }

    public interface IRepositoryWrapper
    {

        public ICartDetailRepository CartDetailRepository { get; set; }

        public ICartRepository CartRepository { get; set; }

        public IUserRepository UserRepository { get; set; }

        public IProductRepository ProductRepository { get; set; }


        public IOrderRepository OrderRepository { get; set; }

        public IOderDetailRepository OderDetailRepository { get; set; }

        public IBrandRepository BrandRepository { get; set; }

        public IRoleRepository RoleRepository { get; set; }
        public ILogInRepository LogInRepository { get; set; }

        Task<int> SaveAsync();

    }

    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly CricketStoreDBContext dbContext;
        public ICartDetailRepository CartDetailRepository { get; set; }
        public ICartRepository CartRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IOderDetailRepository OderDetailRepository { get; set; }

        public IBrandRepository BrandRepository { get; set; }

        public IRoleRepository RoleRepository { get; set; }
        public ILogInRepository LogInRepository { get; set; }

        public RepositoryWrapper(CricketStoreDBContext dbContext)
        {
            this.dbContext = dbContext;

            CartDetailRepository = new CartDetailRepository(dbContext);
            CartRepository = new CartRepository(dbContext);
            UserRepository = new UserRepository(dbContext);
            ProductRepository = new ProductRepository(dbContext);
            OrderRepository = new OrderRepository(dbContext);
            OderDetailRepository = new OderDetailRepository(dbContext);
            BrandRepository = new BrandRepository(dbContext);
            RoleRepository = new RoleRepository(dbContext);
            LogInRepository = new LogInRepository(dbContext);
        }

        public async Task<int> SaveAsync()
        {
            return await this.dbContext.SaveChangesAsync();
        }
    }
}