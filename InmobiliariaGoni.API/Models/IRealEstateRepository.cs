using System.Collections.Generic;

namespace InmobiliariaGoni.Models
{
    public interface IRealEstateRepository
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<House> GetAllHouses();
        House GetHouseById(int id);
        IEnumerable<Tag> GetAllTags();
        void AddHouse(House newHouse);
        bool SaveAll();
        House GetHouseByCode(string houseCode);
    }
}