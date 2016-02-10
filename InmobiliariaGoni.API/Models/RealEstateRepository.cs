using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaGoni.Models
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private RealEstateContext _context;
        private ILogger<RealEstateRepository> _logger;

        public RealEstateRepository(RealEstateContext context, ILogger<RealEstateRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<House> GetAllHouses()
        {
            try
            {
                return _context.Houses
                .OrderBy(h => h.HouseTitle)
                .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get Houses from the database", ex);
                return null;
            }
            
        }

        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                return _context.Categories.OrderBy(c => c.Description).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get Categories from the database", ex);
                return null;
            }
        }

        public IEnumerable<Tag> GetAllTags()
        {
            try
            {
                return _context.Tags.OrderBy(t => t.Description).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get Tags from the database", ex);
                return null;
            }
        }

    }
}
