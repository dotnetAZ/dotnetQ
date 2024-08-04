using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.EntitiesConfigs;

internal class ItemTypeEntityConfigs : IEntityTypeConfiguration<ItemType>
{
    public void Configure(EntityTypeBuilder<ItemType> builder)
    {
    }
}