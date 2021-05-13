using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesInTheaters.Data.Migrations
{
    public partial class MovieDurationTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "duration",
                table: "movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "duration_type",
                table: "movie",
                type: "VARCHAR(32)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "movie_duration_type",
                columns: table => new
                {
                    v = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie_duration_type", x => x.v);
                });

            migrationBuilder.InsertData(
                table: "movie_duration_type",
                column: "v",
                value: "HOUR");

            migrationBuilder.InsertData(
                table: "movie_duration_type",
                column: "v",
                value: "MINUTE");

            migrationBuilder.InsertData(
                table: "movie_duration_type",
                column: "v",
                value: "SECOND");

            migrationBuilder.CreateIndex(
                name: "IX_movie_duration",
                table: "movie",
                column: "duration");

            migrationBuilder.CreateIndex(
                name: "IX_movie_duration_type",
                table: "movie",
                column: "duration_type");

            migrationBuilder.AddForeignKey(
                name: "FK_movie_movie_duration_type_duration_type",
                table: "movie",
                column: "duration_type",
                principalTable: "movie_duration_type",
                principalColumn: "v",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movie_movie_duration_type_duration_type",
                table: "movie");

            migrationBuilder.DropTable(
                name: "movie_duration_type");

            migrationBuilder.DropIndex(
                name: "IX_movie_duration",
                table: "movie");

            migrationBuilder.DropIndex(
                name: "IX_movie_duration_type",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "duration",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "duration_type",
                table: "movie");
        }
    }
}
