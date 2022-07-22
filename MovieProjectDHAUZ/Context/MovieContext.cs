using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieProjectDHAUZ.Context.Mapping;
using MovieProjectDHAUZ.DataModel;
using MovieProjectDHAUZ.DTOs.Configuration;

namespace Microsoft.EntityFrameworkCore
{
    public abstract class EntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }

    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration)
            where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
    }
}

namespace MovieProjectDHAUZ.Context
{
    public class MovieContext : DbContext
    {
        private readonly ConfigurationDto _config;
        public MovieContext(ConfigurationDto config)
        {
            _config = config;
        }

        public MovieContext(DbContextOptions<MovieContext> dbContext) : base(dbContext)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.ConnectionStrings.MoviesDb);

        }

        public virtual DbSet<MovieDataModel> MovieDataModel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new MovieMapping());
        }
    }
}

