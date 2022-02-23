using MentorMate.Restaurant.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentorMate.Restaurant.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            // unique values
            builder.HasIndex(u => u.Name)
                .IsUnique();

            // many-to-one relationship
            builder.HasMany(u => u.Tables)
                .WithOne(t => t.Waiter);
        }
    }
}
