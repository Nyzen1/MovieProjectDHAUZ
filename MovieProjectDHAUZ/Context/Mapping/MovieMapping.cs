using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieProjectDHAUZ.DataModel;
using Microsoft.EntityFrameworkCore;

namespace MovieProjectDHAUZ.Context.Mapping
{
    public class MovieMapping : EntityTypeConfiguration<MovieDataModel>
    {
        public override void Map(EntityTypeBuilder<MovieDataModel> builder)
        {
            builder.Property(a => a.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(a => a.IdImdb)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(a => a.ReleaseDate)
                .HasColumnType("datetime");

            builder.Property(a => a.Genre)
               .IsRequired()
               .HasMaxLength(500);

            builder.Property(a => a.Watched)
                .IsRequired();

            builder.Property(a => a.UserScore)
                .IsRequired();
        }
    }
}
