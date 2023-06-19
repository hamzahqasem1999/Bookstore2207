using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore2207.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "auther",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(nullable: false),
                    lastname = table.Column<string>(nullable: false),
                    Nationality = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auther", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<int>(nullable: false),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookStore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    booktitle = table.Column<string>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    prise = table.Column<int>(nullable: false),
                    catgoryId = table.Column<int>(nullable: true),
                    category_Id = table.Column<int>(nullable: false),
                    autherId = table.Column<int>(nullable: true),
                    auther_Id = table.Column<int>(nullable: false),
                    path = table.Column<string>(nullable: true),
                    stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookStore_auther_autherId",
                        column: x => x.autherId,
                        principalTable: "auther",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookStore_Category_catgoryId",
                        column: x => x.catgoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookStore_autherId",
                table: "BookStore",
                column: "autherId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStore_catgoryId",
                table: "BookStore",
                column: "catgoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookStore");

            migrationBuilder.DropTable(
                name: "auther");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
