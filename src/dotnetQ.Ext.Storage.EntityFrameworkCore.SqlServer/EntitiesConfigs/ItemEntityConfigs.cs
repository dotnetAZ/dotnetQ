using dotnetQ.Abstractions.Entities.QItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.EntitiesConfigs;

internal class ItemEntityConfigs : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
    }
}