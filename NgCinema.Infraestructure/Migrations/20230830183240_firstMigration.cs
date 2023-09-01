using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NgCinema.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenre = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenre);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    IdRoom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.IdRoom);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    IdMovie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    synopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdGenre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.IdMovie);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "Generos",
                        principalColumn: "IdGenre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    IdFuntion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMovie = table.Column<int>(type: "int", nullable: false),
                    IdRoom = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.IdFuntion);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Peliculas",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Salas",
                        principalColumn: "IdRoom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    IdTicket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFunction = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_IdFunction",
                        column: x => x.IdFunction,
                        principalTable: "Funciones",
                        principalColumn: "IdFuntion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "IdGenre", "Name" },
                values: new object[,]
                {
                    { 1, "Acción" },
                    { 2, "Aventuras" },
                    { 3, "Ciencia Ficción" },
                    { 4, "Comedia" },
                    { 5, "Documental" },
                    { 6, "Drama" },
                    { 7, "Fantasía" },
                    { 8, "Musical" },
                    { 9, "Suspenso" },
                    { 10, "Terror" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "IdRoom", "Capacity", "Name" },
                values: new object[,]
                {
                    { 1, 5, "Sala 1" },
                    { 2, 15, "Sala 2" },
                    { 3, 35, "Sala 3" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "IdMovie", "IdGenre", "Poster", "Title", "Trailer", "synopsis" },
                values: new object[,]
                {
                    { 1, 8, "BohemianRhapsody.png", "Bohemian Rhapsody", "BohemianRhapsody.mp4", "El joven Farrokh, Freddie, se ofrece como cantante de la banda al enterarse de que se han quedado sin vocalista. Ninguno de ellos se imaginaba por aquel entonces que se convertirían en los mismísimos Queen." },
                    { 2, 1, "HarryPotter.png", "Harry Potter y El misterio del príncipe", "TrailerHarryPotter.mp4", "Sexta entrega de la saga del joven mago, en la que Harry descubre un poderoso libro y, mientras trata de descubrir sus orígenes, colabora con Dumbledore en la búsqueda de una serie de objetos mágicos que ayudarán en la destrucción de Lord Voldemort." },
                    { 3, 7, "Cars.png", "Cars", "Cars.mp4", "El aspirante a campeón de carreras Rayo McQueen parece que está a punto de conseguir el éxito. Su actitud arrogante se desvanece cuando llega a una pequeña comunidad olvidada que le enseña las cosas importantes de la vida que había olvidado." },
                    { 4, 1, "Rocky2.png", "Rocky 2", "Rocky.mp4", "Rocky ha colgado los guantes de boxeo. Sin embargo, acepta la oferta de revancha de Apollo para una segunda pelea. Reticente, acepta cuando éste le llama cobarde, se teme que la pelea pueda acabar con el ya retirado Rocky." },
                    { 5, 7, "ToyStory3.png", "Toy Story 3", "ToyStory3.mp4", "Cuando su dueño Andy comienza la universidad Woody, Buzz y el resto de sus amigos juguetes comienzan a preocuparse por su incierto futuro. Todos acaban en una guardería donde comenzarán una serie de trepidantes y divertidas aventuras." },
                    { 6, 5, "Oppenheimer.png", "Oppenheimer", "Oppenheimer.mp4", "El físico J Robert Oppenheimer trabaja con un equipo de científicos durante el Proyecto Manhattan, que condujo al desarrollo de la bomba atómica." },
                    { 7, 3, "Interstellar.png", "Interstellar", "Interstellar.mp4", "Un grupo de científicos y exploradores, encabezados por Cooper, realizan un viaje espacial para encontrar un lugar con las condiciones necesarias para reemplazar a la Tierra.Este grupo necesita encontrar un planeta más que garantice el futuro humano" },
                    { 8, 10, "IT.png", "IT", "IT.mp4", "Varios niños de una pequeña ciudad del estado de Maine se alían para combatir a una entidad diabólica que adopta la forma de un payaso y desde hace mucho tiempo emerge cada 27 años para saciarse de sangre infantil." },
                    { 9, 1, "spiderman.png", "Spiderman 1", "spiderman.mp4", "Al sufrir la picadura de una araña genéticamente modificada, un estudiante de secundaria tímido y torpe adquiere increíbles capacidades como arácnido. Pronto comprenderá que su misión es utilizarlas para luchar contra el mal y defender a sus vecinos." },
                    { 10, 6, "RedSocial.png", "Red social", "RedSocial.mp4", "La historia de los jóvenes fundadores de la popular red social Facebook, especialmente de su creador más conocido, Mark Zuckerberg. Su leyenda reza: 'No se hacen 500 millones de amigos sin hacer unos cuantos enemigos'." },
                    { 11, 4, "BuenosVecinos.png", "Buenos Vecinos", "BuenosVecinos.mp4", "Mac y Kelly acaban de tener una niña adorable y se han comprado una preciosa casa en las afueras. Pero estos exjuerguistas descubren de pronto que sus nuevos vecinos son los miembros de la fraternidad Delta Psi Beta, con el presidente Teddy Sanders." },
                    { 12, 1, "Batman.png", "Batman: el caballero de la noche", "Batman.mp4", "Con la ayuda del teniente Jim Gordon y del Fiscal del Distrito Harvey Dent, Batman mantiene a raya el crimen organizado en Gotham. Todo cambia cuando aparece el Joker, un nuevo criminal que desencadena el caos y tiene aterrados a los ciudadanos." },
                    { 13, 9, "IslaSiniestra.png", "La isla siniestra", "IslaSiniestra.mp4", "Los agentes son enviados a una isla del puerto de Boston para investigar la desaparición de una asesina en el hospital psiquiátrico, un centro penitenciario para criminales. El centro guarda secretos y la isla esconde algo más peligroso que los pacientes." },
                    { 14, 6, "SecretoDeSusOjos.png", "El secreto de sus ojos", "SecretoDeSusOjos.mp4", "Benjamín Espósito es un oficial de un Juzgado de Instrucción jubilado. Su sueño es escribir una novela. intentará dar solución a un caso viejo, del cual fue testigo y protagonista. " },
                    { 15, 5, "soldadoRyan.png", "Rescatando al soldado Ryan", "soldadoRyan.mp4", "Después de desembarcar en Normandía, en plena Segunda Guerra Mundial, unos soldados norteamericanos deben arriesgar sus vidas para salvar al soldado James Ryan, cuyos tres hermanos han muerto en la guerra." },
                    { 16, 7, "sherk.png", "Sherk 2", "sherk.mp4", "Shrek, nuestro ogro favorito, debe enfrentarse al mayor de los problemas que se podía imaginar: conocer a sus suegros." },
                    { 17, 3, " StarWars.png", "Star Wars: Episodio IV", " StarWars.mp4", "Princesa Leia es capturada por el temible DarthVader. Leia consigue introducir un mensaje en su robot. Tras aterrizar son capturados y vendidos al joven Luke Skywalker, quien descubrirá el mensaje oculto que va destinado a Obi Wan Kenobi, maestro Jedi." },
                    { 18, 2, "ForrestGump.png", "Forrest Gump", "ForrestGump.mp4", "Forrest Gump espera al autobús. Mientras éste tarda en llegar, el joven cuenta su vida . Aunque sufre un pequeño retraso mental, esto no le impide hacer cosas maravillosas. el toma partido en los eventos más importantes de la historia de los EEUU." },
                    { 19, 5, "ElLoboWallStreet.png", "El lobo de Wall Street", "WallStreet.mp4", "La historia del corredor de bolsa neoyorquino Jordan Belfort, quien, con poco más de veinte años, fue apodado 'el lobo de Wall Street' por su enorme éxito y fortuna como fundador de la agencia bursátil Stratton Oakmont." },
                    { 20, 1, "ElClubDeLaPelea.png", "El club de la pelea", "ElClubDeLaPelea.mp4", "Un empleado de oficina insomne, harto de su vida, se cruza con un vendedor peculiar. Ambos crean un club de lucha clandestino como forma de terapia y, poco a poco, la organización crece y sus objetivos toman otro rumbo." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_IdMovie",
                table: "Funciones",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_IdRoom",
                table: "Funciones",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_IdGenre",
                table: "Peliculas",
                column: "IdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdFunction",
                table: "Tickets",
                column: "IdFunction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
