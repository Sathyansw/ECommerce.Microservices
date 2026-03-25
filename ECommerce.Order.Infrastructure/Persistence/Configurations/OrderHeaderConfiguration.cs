using ECommerce.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Infrastructure.Persistence.Configurations
{
    public class OrderHeaderConfiguration
    : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TotalAmount)
                   .HasPrecision(18, 2);

            builder.HasMany(x => x.Items)
                   .WithOne(x => x.OrderHeader)
                   .HasForeignKey(x => x.OrderHeaderId);
        }
    }
}
