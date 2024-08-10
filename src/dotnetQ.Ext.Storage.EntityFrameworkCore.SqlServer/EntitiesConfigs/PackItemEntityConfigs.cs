using dotnetQ.Abstractions.Entities.QPacks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.EntitiesConfigs;

internal class PackItemEntityConfigs : IEntityTypeConfiguration<PackItem>
{
    public void Configure(EntityTypeBuilder<PackItem> builder)
    {
    }
}