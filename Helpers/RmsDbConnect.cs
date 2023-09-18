using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSRC_RMS.Models;

namespace HSRC_RMS.Helpers
{
    //Dcontext for connecting to the RMS Database
    public class RmsDbConnect : DbContext
    {
        //constructor that takes in dbcontextOption as input
        public RmsDbConnect(DbContextOptions<RmsDbConnect> options) : base(options) { }

        public DbSet<GiftRegister> GiftRegister { get; set; }

        public DbSet<OpportunitiesRegister> opportunities { get; set; }

        public DbSet<ProposalsRegister> proposals { get; set; }


        //db properties for different tables

        /**Users Tables Start**/
        public DbSet<Users> Users { get; set; }
        /**Users Tables End**/

        public DbSet<Files> Files { get; set; }

        /**Gift Register Tables Start**/

        public DbSet<GiftRegister> Gift { get; set; }
        public DbSet<GiftComment> GiftComment { get; set; }

        /**Gift Register Tables End**/


        /**Collaborations Tables Start**/

        public DbSet<JointAcademicRegister> JointAcademic { get; set; }
        public DbSet<JointActivitiesRegister> JointActivities { get; set; }
        public DbSet<JointProjectsRegister> JointProjects { get; set; }
        public DbSet<JointPublicationsRegister> JointPublications { get; set; }
        public DbSet<JointSupervisionsRegister> JointSupevisions { get; set; }

        /**Collaborations Tables End**/


        /**License Tables start**/

        public DbSet<LicenseSupplies> LicenseSupply { get; set; }
        public DbSet<LicenseType> LicenseType { get; set; }
        public DbSet<LicenseCapture> LicenseCapture   { get; set; }
        public DbSet<LicenseActivation> LicenseActivation { get; set; }
        public DbSet<LicenseRemainder> LicenseRemainder { get; set; }

        /**License Tables End**/




        /**Memorundum of understanding Tables Start**/

        public DbSet<MouCreate> MouCreate { get; set; }

        /**Memorundum of understanding Tables End**/



        /**Event Registration Tables Start**/

        public DbSet<Event> Event { get; set; }
        public DbSet<EventFiles> EventFiles { get; set; }

        /**Event Registration Tables End**/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiftRegister>()
                .Property(g => g.Value)
                .HasColumnType("decimal(18, 2)"); // Specify the appropriate precision and scale


          

            base.OnModelCreating(modelBuilder);

           
        }

    }

}