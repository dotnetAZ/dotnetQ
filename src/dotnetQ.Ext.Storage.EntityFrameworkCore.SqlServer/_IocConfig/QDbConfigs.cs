namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer._IocConfig;

public class QDbConfigs
{
    public string DefaultSchema { get; set; }
    public string PrimaryDbConnection { get; set; }
    public string? ReadonlyDbConnection { get; set; }
}