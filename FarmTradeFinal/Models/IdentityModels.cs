using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FarmTradeFinal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Quality> Qualities { get; set; }
        public DbSet<FinalProduct> FinalProducts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<MarketEntry> MarketEntries { get; set; }
        public DbSet<EntryType> EntryTypes { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<TradeMatch> TradeMatches { get; set; }
        //public DbSet<TradeSummary> TradeSummaries { get; set; }







        public ApplicationDbContext()
            : base("TradeFarmDBContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<MarketEntry>()
                .HasRequired(f => f.FinalProduct)
                .WithMany()
                .WillCascadeOnDelete(false);






            //modelBuilder.Entity<Storage>()
            //   .HasRequired(s => s.Location)
            //   .WithMany(s => s.Storages).HasForeignKey(s => s.LocationId);

            modelBuilder.Entity<TradeMatch>()
                .HasRequired(f => f.SellerEntry)
                .WithMany()
                .HasForeignKey(f => f.SellerEntryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TradeMatch>()
                .HasRequired(f => f.BuyerEntry)
                .WithMany()
                .HasForeignKey(f => f.BuyerEntryID)
                .WillCascadeOnDelete(false);

            //    // Configuring relationship between TradeMatch - TradeSummary
            //    modelBuilder.Entity<TradeSummary>()
            //        .HasKey(t => t.TradeMatchID);

            //    modelBuilder.Entity<TradeMatch>()
            //        .HasRequired(o => o.TradeSummary)
            //        .WithRequiredPrincipal(t => t.TradeMatch);


            base.OnModelCreating(modelBuilder);

        }





    }
}