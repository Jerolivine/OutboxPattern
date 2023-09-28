using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutboxPattern.Domain.Core.Concrete;
using OutboxPattern.Domain.Customer;
using OutboxPattern.Persistance.EFCore.Configuration.Abstract;

namespace OutboxPattern.Persistance.EFCore.Configuration
{
    public class CustomerAddedOutboxConfiguration : IEntityTypeConfiguration<CustomerAddedOutbox>
    {
        public void Configure(EntityTypeBuilder<CustomerAddedOutbox> builder)
        {
            builder.ToTable("CUSTOMER_ADDED_OUTBOX");

            builder.HasKey(t => t.EventId);
            builder.Property(t => t.EventId).HasColumnName("EVENT_ID").IsRequired();

            builder.Property(t => t.EventType).HasColumnName("EVENT_TYPE").IsRequired();
            builder.Property(t => t.TimeStamp).HasColumnName("TIMESTAMP").IsRequired();
            builder.Property(t => t.EventStatus).HasColumnName("EVENT_STATUS").IsRequired();
            builder.Property(t => t.ExchangeName).HasColumnName("EXCHANGE_NAME").IsRequired();
            builder.Property(t => t.Payload).HasColumnName("PAYLOAD").IsRequired();
        }
    }
}
