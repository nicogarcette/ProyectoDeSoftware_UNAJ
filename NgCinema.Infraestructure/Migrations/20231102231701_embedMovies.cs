using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NgCinema.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class embedMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 1,
                column: "Trailer",
                value: "https://www.youtube.com/embed/mP0VHJYFOAU?si=imrCOhzSq6FXIrbE");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 2,
                column: "Trailer",
                value: "https://www.youtube.com/embed/NaM7nKvX4Es?si=KN3jAaCp6PdrcVym");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 3,
                column: "Trailer",
                value: "https://www.youtube.com/embed/SbXIj2T-_uk?si=drW8F83ZNA5lpdT9");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 4,
                column: "Trailer",
                value: "https://www.youtube.com/embed/zAtnLcXEZ_E?si=h6DcmjzinoLxHnDI");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 5,
                column: "Trailer",
                value: "https://www.youtube.com/embed/JcpWXaA2qeg?si=YcKveDUBspjGC3RC");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 6,
                column: "Trailer",
                value: "https://www.youtube.com/embed/MVvGSBKV504?si=xt5lkbXOPSghcBId");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 7,
                column: "Trailer",
                value: "https://www.youtube.com/embed/zSWdZVtXT7E?si=JMfl3eI6WzHqA_yP");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 8,
                column: "Trailer",
                value: "https://www.youtube.com/embed/xKJmEC5ieOk?si=AahLXxFukovDtRqP");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 9,
                column: "Trailer",
                value: "https://www.youtube.com/embed/t06RUxPbp_c?si=BnRRli696SjcMDb-");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 10,
                column: "Trailer",
                value: "https://www.youtube.com/embed/K1JWiaIY-Xg?si=znaogfxhoA1VFK1m");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 11,
                column: "Trailer",
                value: "https://www.youtube.com/embed/iNMj0dc1og4?si=9VHWonBeLTKXDneX");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 12,
                column: "Trailer",
                value: "https://www.youtube.com/embed/emYLYfuZAbU?si=7elUO5gSFTAtrQf5");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 13,
                column: "Trailer",
                value: "https://www.youtube.com/embed/95z6iWCjEgc?si=LAVZh9zn318SG4ZB");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 14,
                column: "Trailer",
                value: "https://www.youtube.com/embed/GqdLlefQ8gU?si=0Z75nBd-S3CFCa7J");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 15,
                column: "Trailer",
                value: "https://www.youtube.com/embed/TAyhMtyup3o?si=WptCbCm0hV_umNJg");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 16,
                column: "Trailer",
                value: "https://www.youtube.com/embed/xBxVgh-kgAI?si=93UpIP39zT4DQqwj");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 17,
                column: "Trailer",
                value: "https://www.youtube.com/embed/beAH5vea99k?si=MdjwvMnynMzBmuHa");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 18,
                column: "Trailer",
                value: "https://www.youtube.com/embed/Cyh1LpxnaxI?si=gfDoCGoOYfI3XbZg");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 19,
                column: "Trailer",
                value: "https://www.youtube.com/embed/PaAvUOXUohk?si=v5-XCm9S-is-aMVZ");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 20,
                column: "Trailer",
                value: "https://www.youtube.com/embed/YD5BeUWgsSM?si=bbOLMgL9PbEe0MMv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 1,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=mP0VHJYFOAU");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 2,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=NaM7nKvX4Es");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 3,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=SbXIj2T-_uk");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 4,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=zAtnLcXEZ_E");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 5,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=JcpWXaA2qeg");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 6,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=MVvGSBKV504");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 7,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=zSWdZVtXT7E");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 8,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=xKJmEC5ieOk");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 9,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=t06RUxPbp_c");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 10,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=K1JWiaIY-Xg");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 11,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=iNMj0dc1og4");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 12,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=emYLYfuZAbU");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 13,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=95z6iWCjEgc");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 14,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=GqdLlefQ8gU");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 15,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=TAyhMtyup3o");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 16,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=xBxVgh-kgAI");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 17,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=beAH5vea99k");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 18,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=Cyh1LpxnaxI");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 19,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=PaAvUOXUohk");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "IdMovie",
                keyValue: 20,
                column: "Trailer",
                value: "https://www.youtube.com/watch?v=YD5BeUWgsSM");
        }
    }
}
