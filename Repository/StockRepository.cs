using APIPractice.Data;
using APIPractice.Models.DTO;
using APIPractice.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace APIPractice.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext db;

        public StockRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<SellingPrice>> CostPrice(Guid id)
        {
            var stock = db.StockUpdateHistories.Include("Product").AsQueryable();
            var costPrice = await stock
                                .Where(s => s.ProductId == id)
                                .Where(s => s.UpdatedAt >= DateTime.Now.AddMonths(-12)) // Filter first
                                .GroupBy(s => new
                                {
                                    s.Price,
                                    Year = s.UpdatedAt.Year,
                                    Month = s.UpdatedAt.Month
                                })
                                .OrderBy(g => g.Key.Year)
                                .ThenBy(g => g.Key.Month)
                                .Select(g => new SellingPrice
                                {
                                    Quantity = g.Sum(x => x.QuantityRemaining),
                                    Price = g.Key.Price,
                                    Month = new DateTime(g.Key.Year, g.Key.Month, 1)
                                })
                                .ToListAsync();
            return costPrice;
        }
    }
}
