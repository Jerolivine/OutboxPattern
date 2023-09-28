using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OutboxPattern.Domain.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutboxPattern.Persistance.EFCore.Configuration.Abstract
{
    //public class BaseOutboxTableConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : OutboxTable
    //{
    //    public void Configure(EntityTypeBuilder<TEntity> builder)
    //    {
    //        builder.HasKey(t => t.EventId);
    //        builder.Property(t => t.EventId).HasColumnName("EVENT_ID").IsRequired();

    //        builder.Property(t => t.EventType).HasColumnName("EVENT_TYPE").IsRequired();
    //        builder.Property(t => t.TimeStamp).HasColumnName("TIMESTAMP").IsRequired();
    //        builder.Property(t => t.EventStatus).HasColumnName("EVENT_STATUS").IsRequired();
    //        builder.Property(t => t.ExchangeName).HasColumnName("EXCHANGE_NAME").IsRequired();

    //    }
    //}
}
