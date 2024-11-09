using Items.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.Infraestructure.Config
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {      
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            DateTime today = DateTime.Now;
            builder.Property(p => p.DateCreate).HasDefaultValue(today);
        }
    }
}
