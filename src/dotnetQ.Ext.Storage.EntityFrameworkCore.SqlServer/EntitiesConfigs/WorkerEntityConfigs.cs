using dotnetQ.Abstractions.Entities.QWorkers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.EntitiesConfigs;

internal class WorkerEntityConfigs : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).UseIdentityColumn();
    }
}