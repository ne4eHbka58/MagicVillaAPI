using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(

                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "Some text about this Royal beautiful Villa",
                    ImageUrl = "",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Pool Villa",
                    Details = "Some details about this Pool Villa",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 150,
                    Sqft = 450,
                    Amenity = "Pool",
                    CreatedDate = DateTime.Now,
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Ocean Villa",
                    Details = "Villa with access to the ocean",
                    ImageUrl = "",
                    Occupancy = 2,
                    Rate = 100,
                    Sqft = 250,
                    Amenity = "Access to the ocean",
                    CreatedDate = DateTime.Now,
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Beach Villa",
                    Details = "Villa near the beach",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 180,
                    Sqft = 500,
                    Amenity = "Near the beach",
                    CreatedDate = DateTime.Now,
                },
                new Villa()
                {
                    Id = 5,
                    Name = "Royal Pool Villa",
                    Details = "Royal Villa with a big pool",
                    ImageUrl = "",
                    Occupancy = 7,
                    Rate = 260,
                    Sqft = 750,
                    Amenity = "Royal pool",
                    CreatedDate = DateTime.Now,
                }
                );
        }
    }
}
