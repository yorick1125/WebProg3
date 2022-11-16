using DutchTreat.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreats.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly ILogger<DutchRepository> _logger;

        public DutchRepository(ApplicationDbContext ctx, ILogger<DutchRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called...");

                return _ctx.Products.OrderBy(p => p.Artist).ToList();

            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get all products: {e}");
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products.Where(p => p.Category == category).ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

    }
}
