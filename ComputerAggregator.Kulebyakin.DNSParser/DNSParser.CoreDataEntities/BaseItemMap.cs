using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSParser.CoreDataEntities
{
    public class BaseItemMap
    {
        public BaseItemMap(EntityTypeBuilder<BaseItem> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired();
            entityBuilder.Property(x => x.Price).IsRequired();
        }
    }
}
