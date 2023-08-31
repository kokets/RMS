using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using HSRC_RMS.Models;

namespace HSRC_RMS.Helpers
{
    //Dcontext for connecting to the RMS Database
    public class RmsDbConnect : DbContext
    {
        //constructor that takes in dbcontextOption as input
        public RmsDbConnect(DbContextOptions<RmsDbConnect> options) : base(options) { }

        //db properties for different tables
        public DbSet<GiftRegister> Gift { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<GiftComment> GiftComments { get; set; }
        public DbSet<LicenseSupplies> LicenseSupply { get; set; }
        public DbSet<LicenseType> LicenseType { get; set; }
        public DbSet<LicenseCapture> LicenseCapture   { get; set; }
        public DbSet<LicenseActivation> LicenseActivation { get; set; }
        public DbSet<LicenseRemainder> LicenseRemainder { get; set; }
        //mou 
        public DbSet<MouCreate> MouCreate { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiftRegister>()
                .Property(g => g.Value)
                .HasColumnType("decimal(18, 2)"); // Specify the appropriate precision and scale

            base.OnModelCreating(modelBuilder);
        }

    }

}