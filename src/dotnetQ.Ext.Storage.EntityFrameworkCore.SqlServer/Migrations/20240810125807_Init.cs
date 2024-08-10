using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "QQ");

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "QQ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    ActionData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionDataHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDomainDataHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CanPackAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPacked = table.Column<bool>(type: "bit", nullable: false),
                    RequeueRefItemId = table.Column<int>(type: "int", nullable: true),
                    RequeueCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                schema: "QQ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsProcessable = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    PackSize = table.Column<int>(type: "int", nullable: false),
                    IsRetriable = table.Column<bool>(type: "bit", nullable: false),
                    MaxRetries = table.Column<byte>(type: "tinyint", nullable: false),
                    CanProccessAfterMin = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackItems",
                schema: "QQ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    IsReleased = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HasException = table.Column<bool>(type: "bit", nullable: false),
                    IsRequeued = table.Column<bool>(type: "bit", nullable: false),
                    ExceptionTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packs",
                schema: "QQ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    IsPicked = table.Column<bool>(type: "bit", nullable: false),
                    PickedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkerId = table.Column<int>(type: "int", nullable: true),
                    IsReleased = table.Column<bool>(type: "bit", nullable: false),
                    ReleasedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                schema: "QQ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    IsProduction = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastHeartbeatAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsTerminated = table.Column<bool>(type: "bit", nullable: false),
                    TerminatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items",
                schema: "QQ");

            migrationBuilder.DropTable(
                name: "ItemTypes",
                schema: "QQ");

            migrationBuilder.DropTable(
                name: "PackItems",
                schema: "QQ");

            migrationBuilder.DropTable(
                name: "Packs",
                schema: "QQ");

            migrationBuilder.DropTable(
                name: "Workers",
                schema: "QQ");
        }
    }
}
