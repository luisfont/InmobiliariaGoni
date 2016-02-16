using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaGoni.Models
{
    public class RealEstateContextSeedData
    {
        private RealEstateContext _context;
        private UserManager<RealEstateUser> _userManager;

        public RealEstateContextSeedData(RealEstateContext context, UserManager<RealEstateUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
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
            if (await _userManager.FindByEmailAsync("fontluis@gmail.com") == null)
            {
                var newUser = new RealEstateUser()
                {
                    UserName = "admin",
                    Email = "fontluis@gmail.com"
                };

                await _userManager.CreateAsync(newUser, "S1t3P@ssw0rd");
            }
        }
    }
}