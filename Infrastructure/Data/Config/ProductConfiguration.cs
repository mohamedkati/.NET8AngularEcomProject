﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ProductBrandId).IsRequired();
            builder.Property(x => x.ProductBrandId).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ProductBrand);
            builder.HasOne(x => x.ProductType);
        }
    }
}
