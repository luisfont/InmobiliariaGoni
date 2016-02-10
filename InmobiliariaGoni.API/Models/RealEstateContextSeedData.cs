using System.Linq;

namespace InmobiliariaGoni.Models
{
    public class RealEstateContextSeedData
    {
        private RealEstateContext _context;

        public RealEstateContextSeedData(RealEstateContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            //TODO: Add Seeded data with the commented template
            //if (!_context.Houses.Any())
            //{
            //    _context.Houses.Add(new House()
            //    {
            //        Id = 1,
            //        HouseTitle = "Casa en Venta"
            //    });
            //    _context.SaveChanges();
            //}
        }
    }
}