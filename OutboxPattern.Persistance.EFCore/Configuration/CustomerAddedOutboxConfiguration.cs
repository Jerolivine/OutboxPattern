using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutboxPattern.Domain.Core.Concrete;
using OutboxPattern.Domain.Customer;
using OutboxPattern.Persistance.EFCore.Configuration.Abstract;

namespace OutboxPattern.Persistance.EFCore.Configuration
{
    public class CustomerAddedOutboxConfiguration : BaseOutboxTableConfiguration<CustomerAddedOutbox>
    {
        public void Configure(EntityTypeBuilder<CustomerAddedOutbox> builder)
        {
            builder.ToTable("CUSTOMER_ADDED_OUTBOX");

            base.Configure(builder);
        }
    }

  
}
