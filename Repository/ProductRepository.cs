using BadgeTask.Data;
using BadgeTask.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace BadgeTask.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;
        public async Task<IEnumerable<Product>> GetAllAsync()
            =>await _context.Products.FromSqlRaw("EXEC GetAllProducts").ToListAsync();
        public async Task<Product> GetByIdAsync(int id)
        {
            var param = new SqlParameter("@Id", id);
            var result = await _context.Products
                .FromSqlRaw("EXEC GetPrById @Id", param)
                .ToListAsync();

            return result.FirstOrDefault(); 
        }
        public async Task AddAsync(Product product)
        {
            var parameters = new[]
            {
            new SqlParameter("@PName", product.PName),
          
            new SqlParameter("@Price", product.Price)
        };
            await _context.Database.ExecuteSqlRawAsync("EXEC InsertProducts @PName, @Price", parameters);
        }
        public async Task UpdateAsync(Product product)
        {
            var parameters = new[]
            {
            new SqlParameter("@Id", product.Id),
            new SqlParameter("@PName", product.PName),
            
            new SqlParameter("@Price", product.Price)
        };
            await _context.Database.ExecuteSqlRawAsync("EXEC UPDATEProduct @Id, @PName, @Price", parameters);
        }
        public async Task DeleteAsync(int id)
        {
            var param = new SqlParameter("@Id", id);
            await _context.Database.ExecuteSqlRawAsync("EXEC DeleteProduct @Id", param);
        }
    }
}
