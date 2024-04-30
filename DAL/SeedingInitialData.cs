using CricketStore.DAL.entities;

namespace CricketStore.DAL
{
    public class SeedingInitialData
    {
        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Customer"
                },
                new Role
                {
                    Id = 2,
                    Name = "Admin"
                },
            };                  
        }
        public static List<Brand> GetBrands()
        {
            return new List<Brand>
            {
                new Brand
                {
                    Id = 1,
                    Name = "SS"
                },
                new Brand
                {
                    Id = 2,
                    Name = "SG"
                },
            };
        }
    }
}
