using ChannelAnalysis.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ChannelAnalysis.API.Data
{
    public class ChannelAnalysisDbContext : DbContext
    {
        public ChannelAnalysisDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Channel> Channel { get; set; }
        public DbSet<ChannelStatistics> ChannelStatistics { get; set; }
        public DbSet<ProrussianCoefficient> ProrussianCoefficient { get; set; }
        public DbSet<AnalysisQueue> AnalysisQueue { get; set; }
        public DbSet<FeedbackStorage> FeedbackStorage { get; set; }

        //public ChannelAnalysisDbContext()
        //{
        //    Database.EnsureCreated();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ChannelAnalysis;Username=postgres;Password=postgresql");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Channel>()
        //        .HasOne(c => c.Statistics)
        //        .WithOne(s => s.Channel)
        //        .HasForeignKey<ChannelStatistics>(c => c.ChannelId);
        //}
    }
}
