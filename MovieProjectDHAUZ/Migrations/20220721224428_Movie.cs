using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieProjectDHAUZ.Migrations
{
    public partial class Movie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieDataModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdImdb = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Watched = table.Column<bool>(type: "bit", nullable: false),
                    UserScore = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDataModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieDataModel");
        }
    }
}
