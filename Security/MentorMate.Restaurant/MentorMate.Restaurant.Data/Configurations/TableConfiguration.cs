using MentorMate.Restaurant.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentorMate.Restaurant.Data.Configurations
{
    internal class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.ToTable("Tables");

            // one-to-many relationship
            builder.HasOne(t => t.Waiter)
                .WithMany(w => w.Tables)
                .HasForeignKey(x => x.WaiterId);

            builder.HasMany(t => t.Orders)
                .WithOne(t => t.Table)
                .HasForeignKey(x => x.TableId);
        }
    }
}
