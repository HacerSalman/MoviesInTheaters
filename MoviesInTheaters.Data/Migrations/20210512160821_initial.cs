using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesInTheaters.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entity_status",
                columns: table => new
                {
                    v = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entity_status", x => x.v);
                });

            migrationBuilder.CreateTable(
                name: "movie_type",
                columns: table => new
                {
                    v = table.Column<string>(type: "VARCHAR(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie_type", x => x.v);
                });

            migrationBuilder.CreateTable(
                name: "cinema",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false),
                    create_time = table.Column<long>(nullable: false),
                    Update_time = table.Column<long>(nullable: false),
                    owner = table.Column<string>(nullable: true),
                    modifier = table.Column<string>(nullable: true),
                    address = table.Column<string>(maxLength: 1024, nullable: true),
                    name = table.Column<string>(maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cinema", x => x.id);
                    table.ForeignKey(
                        name: "FK_cinema_entity_status_status",
                        column: x => x.status,
                        principalTable: "entity_status",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false),
                    create_time = table.Column<long>(nullable: false),
                    Update_time = table.Column<long>(nullable: false),
                    owner = table.Column<string>(nullable: true),
                    modifier = table.Column<string>(nullable: true),
                    description = table.Column<string>(maxLength: 2048, nullable: true),
                    type = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    rating = table.Column<double>(nullable: false),
                    name = table.Column<string>(maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie", x => x.id);
                    table.ForeignKey(
                        name: "FK_movie_entity_status_status",
                        column: x => x.status,
                        principalTable: "entity_status",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_movie_movie_type_type",
                        column: x => x.type,
                        principalTable: "movie_type",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cinema_movie",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(type: "VARCHAR(32)", nullable: false),
                    create_time = table.Column<long>(nullable: false),
                    Update_time = table.Column<long>(nullable: false),
                    owner = table.Column<string>(nullable: true),
                    modifier = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    discount_price = table.Column<double>(nullable: false),
                    cinema_id = table.Column<long>(nullable: false),
                    movie_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cinema_movie", x => x.id);
                    table.ForeignKey(
                        name: "FK_cinema_movie_cinema_cinema_id",
                        column: x => x.cinema_id,
                        principalTable: "cinema",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cinema_movie_movie_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cinema_movie_entity_status_status",
                        column: x => x.status,
                        principalTable: "entity_status",
                        principalColumn: "v",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "entity_status",
                column: "v",
                values: new object[]
                {
                    "ACTIVE",
                    "PASSIVE",
                    "DELETED"
                });

            migrationBuilder.InsertData(
                table: "movie_type",
                column: "v",
                values: new object[]
                {
                    "ACTION",
                    "DRAMA",
                    "COMEDY",
                    "HORROR",
                    "THRILLER",
                    "SCIENCE_FICTION",
                    "ADVENTURE",
                    "FASTASTIC",
                    "DETECTIVE"
                });

            migrationBuilder.CreateIndex(
                name: "IX_cinema_create_time",
                table: "cinema",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_cinema_name",
                table: "cinema",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_cinema_status",
                table: "cinema",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_cinema_Update_time",
                table: "cinema",
                column: "Update_time");

            migrationBuilder.CreateIndex(
                name: "IX_cinema_movie_cinema_id",
                table: "cinema_movie",
                column: "cinema_id");

            migrationBuilder.CreateIndex(
                name: "IX_cinema_movie_create_time",
                table: "cinema_movie",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_cinema_movie_movie_id",
                table: "cinema_movie",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_cinema_movie_price",
                table: "cinema_movie",
                column: "price");

            migrationBuilder.CreateIndex(
                name: "IX_cinema_movie_status",
                table: "cinema_movie",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_cinema_movie_Update_time",
                table: "cinema_movie",
                column: "Update_time");

            migrationBuilder.CreateIndex(
                name: "IX_movie_create_time",
                table: "movie",
                column: "create_time");

            migrationBuilder.CreateIndex(
                name: "IX_movie_name",
                table: "movie",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_movie_rating",
                table: "movie",
                column: "rating");

            migrationBuilder.CreateIndex(
                name: "IX_movie_status",
                table: "movie",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_movie_type",
                table: "movie",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_movie_Update_time",
                table: "movie",
                column: "Update_time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cinema_movie");

            migrationBuilder.DropTable(
                name: "cinema");

            migrationBuilder.DropTable(
                name: "movie");

            migrationBuilder.DropTable(
                name: "entity_status");

            migrationBuilder.DropTable(
                name: "movie_type");
        }
    }
}
