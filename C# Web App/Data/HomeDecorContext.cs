using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeDecor.Models;

namespace HomeDecor.Models
{
    public class HomeDecorContext : DbContext
    {
        public HomeDecorContext (DbContextOptions<HomeDecorContext> options)
            : base(options)
        {
        }
        // Inventory Table in Database with fields Furniture_code, Furniture_name, Furniture_type, Date_of_purchase, Unit
        public DbSet<HomeDecor.Models.DecorModel> Resource { get; set; }
        // Facility table in the database with fields
        public DbSet<HomeDecor.Models.FacilityModel> Facility { get; set; }
        // User table in Database with fields UserID, UserName, UserPassword, AccessRights
        public DbSet<HomeDecor.Models.UserAccount> Users { get; set; }
        // User Login in Database with UserName and UserPassword
        public DbSet<HomeDecor.Models.UserLogin> UserLogin { get; set; }
        

       
    }
}
