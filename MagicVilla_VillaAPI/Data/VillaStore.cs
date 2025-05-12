using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO { Id = 1, Name = "Pull View" },
            new VillaDTO { Id = 2, Name = "Beach View" },
            new VillaDTO { Id = 3, Name = "Ocean Villa"}
        };
    }
}
