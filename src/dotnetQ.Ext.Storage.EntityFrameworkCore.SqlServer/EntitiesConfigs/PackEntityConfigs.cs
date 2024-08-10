using dotnetQ.Abstractions.Entities.QPacks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.EntitiesConfigs;

internal class PackEntityConfigs : IEntityTypeConfiguration<Pack>
{
    public void Configure(EntityTypeBuilder<Pack> builder)
    {
    }
}