using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO { Id = 1, Name = "Pull View", Occupancy = 5, Sqft = 100 },
            new VillaDTO { Id = 2, Name = "Beach View", Occupancy = 3, Sqft = 75 },
            new VillaDTO { Id = 3, Name = "Ocean Villa", Occupancy = 4, Sqft = 80 }
        };
    }
}
