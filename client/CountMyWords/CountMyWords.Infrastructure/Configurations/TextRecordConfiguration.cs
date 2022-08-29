using CountMyWords.Infrastructure.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountMyWords.Infrastructure.Configurations
{
    public class TextRecordConfiguration : IEntityTypeConfiguration<TextRecord>
    {
        public void Configure(EntityTypeBuilder<TextRecord> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .IsRequired();
        }
    }
}
