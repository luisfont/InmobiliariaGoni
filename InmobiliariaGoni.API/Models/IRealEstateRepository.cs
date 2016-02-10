using System.Collections.Generic;

namespace InmobiliariaGoni.Models
{
    public interface IRealEstateRepository
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<House> GetAllHouses();
        IEnumerable<Tag> GetAllTags();
    }
}