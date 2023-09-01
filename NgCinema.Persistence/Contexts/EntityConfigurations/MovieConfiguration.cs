using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCinema.Domain.Entities;
using NgCinema.Domain.Enums;

namespace NgCinema.Persistence.Contexts.EntityConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Peliculas");

            builder.HasKey(m => m.IdMovie);
            builder.Property(m => m.IdMovie).ValueGeneratedOnAdd();
            builder.Property(m => m.Title).HasMaxLength(50).IsRequired();
            builder.Property(m => m.Trailer).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Poster).HasMaxLength(100).IsRequired();
            builder.Property(m => m.synopsis).HasMaxLength(255).IsRequired();

            builder.HasOne<Genre>(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(m => m.IdGenre);

            builder.HasData(
                new Movie
                {
                    IdMovie = 1,
                    Title = "Bohemian Rhapsody",
                    synopsis = "Londres, 1970. El joven Farrokh, Freddie para los amigos, trabaja en el aeropuerto, estudia diseño gráfico y escribe canciones. Un día, tras escuchar al grupo Smile en un bar, se ofrece como cantante de la banda al enterarse de que se han quedado sin vocalista. Ninguno de ellos se imaginaba por aquel entonces que se convertirían en los mismísimos Queen.",
                    Poster = "BohemianRhapsody.png",
                    Trailer = "BohemianRhapsody.mp4",
                    IdGenre = (int)Enums.Genre.Musical
                },
                 new Movie
                 {
                     IdMovie = 2,
                     Title = "Harry Potter y El misterio del príncipe",
                     synopsis = "Sexta entrega de la saga del joven mago, en la que Harry descubre un poderoso libro y, mientras trata de descubrir sus orígenes, colabora con Dumbledore en la búsqueda de una serie de objetos mágicos que ayudarán en la destrucción de Lord Voldemort.",
                     Poster = "HarryPotter.png",
                     Trailer = "TrailerHarryPotter.mp4",
                     IdGenre = (int)Enums.Genre.Accion
                 },
                 new Movie
                 {
                     IdMovie = 3,
                     Title = "Cars",
                     synopsis = "El aspirante a campeón de carreras Rayo McQueen parece que está a punto de conseguir el éxito. Su actitud arrogante se desvanece cuando llega a una pequeña comunidad olvidada que le enseña las cosas importantes de la vida que había olvidado.",
                     Poster = "Cars.png",
                     Trailer = "Cars.mp4",
                     IdGenre = (int)Enums.Genre.Fantasia
                 },
                 new Movie
                 {
                     IdMovie = 4,
                     Title = "Rocky 2",
                     synopsis = "Tras la dura pelea contra Apollo Creed y el embarazo de Adrien, Rocky ha colgado los guantes de boxeo. Sin embargo, su ingenuidad a la hora de llevar las finanzas le deja a él y a su familia en una situación difícil, por lo que considera aceptar la oferta de revancha de Apollo para una segunda pelea. Reticente, acepta cuando éste le llama cobarde, a pesar de las negativas de Adrien, quien teme que la pelea pueda acabar con el ya retirado Rocky.",
                     Poster = "Rocky2.png",
                     Trailer = "Rocky.mp4",
                     IdGenre = (int)Enums.Genre.Accion
                 },
                 new Movie
                 {
                     IdMovie = 5,
                     Title = "Toy Story 3",
                     synopsis = "Cuando su dueño Andy se prepara para ir a la universidad, el vaquero Woody, el astronauta Buzz y el resto de sus amigos juguetes comienzan a preocuparse por su incierto futuro. Todos acaban en una guardería donde comenzarán una serie de trepidantes y divertidas aventuras.",
                     Poster = "ToyStory3.png",
                     Trailer = "ToyStory3.mp4",
                     IdGenre = (int)Enums.Genre.Fantasia
                 },
                 new Movie
                 {
                     IdMovie = 6,
                     Title = "Oppenheimer",
                     synopsis = "El físico J Robert Oppenheimer trabaja con un equipo de científicos durante el Proyecto Manhattan, que condujo al desarrollo de la bomba atómica.",
                     Poster = "Oppenheimer.png",
                     Trailer = "Oppenheimer.mp4",
                     IdGenre = (int)Enums.Genre.Documental
                 },
                 new Movie
                 {
                     IdMovie = 7,
                     Title = "Interstellar",
                     synopsis = "Un grupo de científicos y exploradores, encabezados por Cooper, se embarcan en un viaje espacial para encontrar un lugar con las condiciones necesarias para reemplazar a la Tierra y comenzar una nueva vida allí. La Tierra está llegando a su fin y este grupo necesita encontrar un planeta más allá de nuestra galaxia que garantice el futuro de la raza humana.",
                     Poster = "Interstellar.png",
                     Trailer = "Interstellar.mp4",
                     IdGenre = (int)Enums.Genre.CienciaFiccion
                 },
                 new Movie
                 {
                     IdMovie = 8,
                     Title = "IT",
                     synopsis = "Varios niños de una pequeña ciudad del estado de Maine se alían para combatir a una entidad diabólica que adopta la forma de un payaso y desde hace mucho tiempo emerge cada 27 años para saciarse de sangre infantil.",
                     Poster = "IT.png",
                     Trailer = "IT.mp4",
                     IdGenre = (int)Enums.Genre.Terror
                 },
                 new Movie
                 {
                     IdMovie = 9,
                     Title = "Spiderman 1",
                     synopsis = "Luego de sufrir la picadura de una araña genéticamente modificada, un estudiante de secundaria tímido y torpe adquiere increíbles capacidades como arácnido. Pronto comprenderá que su misión es utilizarlas para luchar contra el mal y defender a sus vecinos.",
                     Poster = "spiderman.png",
                     Trailer = "spiderman.mp4",
                     IdGenre = (int)Enums.Genre.Accion
                 },
                 new Movie
                 {
                     IdMovie = 10,
                     Title = "Red social",
                     synopsis = "La historia de los jóvenes fundadores de la popular red social Facebook, especialmente de su creador más conocido, Mark Zuckerberg. Su leyenda reza: 'No se hacen 500 millones de amigos sin hacer unos cuantos enemigos'.",
                     Poster = "RedSocial.png",
                     Trailer = "RedSocial.mp4",
                     IdGenre = (int)Enums.Genre.Drama
                 },
                 new Movie
                 {
                     IdMovie = 11,
                     Title = "Buenos Vecinos",
                     synopsis = "Mac y Kelly acaban de tener una niña adorable y se han comprado una preciosa casa en las afueras. Pero estos exjuerguistas descubren de pronto que sus nuevos vecinos son los miembros de la fraternidad Delta Psi Beta, con el presidente Teddy Sanders.",
                     Poster = "BuenosVecinos.png",
                     Trailer = "BuenosVecinos.mp4",
                     IdGenre = (int)Enums.Genre.Comedia
                 },
                 new Movie
                 {
                     IdMovie = 12,
                     Title = "Batman: el caballero de la noche",
                     synopsis = "Con la ayuda del teniente Jim Gordon y del Fiscal del Distrito Harvey Dent, Batman mantiene a raya el crimen organizado en Gotham. Todo cambia cuando aparece el Joker, un nuevo criminal que desencadena el caos y tiene aterrados a los ciudadanos.",
                     Poster = "Batman.png",
                     Trailer = "Batman.mp4",
                     IdGenre = (int)Enums.Genre.Accion
                 },
                 new Movie
                 {
                     IdMovie = 13,
                     Title = "La isla siniestra",
                     synopsis = "Verano de 1954. Los agentes judiciales Teddy Daniels y Chuck Aule son enviados a una remota isla del puerto de Boston para investigar la desaparición de una peligrosa asesina recluida en el hospital psiquiátrico Ashecliffe, un centro penitenciario para criminales perturbados dirigido por el siniestro doctor John Cawley. Pronto descubrirán que el centro guarda muchos secretos y que la isla esconde algo más peligroso que los pacientes.",
                     Poster = "IslaSiniestra.png",
                     Trailer = "IslaSiniestra.mp4",
                     IdGenre = (int)Enums.Genre.Suspenso
                 },
                 new Movie
                 {
                     IdMovie = 14,
                     Title = "El secreto de sus ojos",
                     synopsis = "Benjamín Espósito es un oficial de un Juzgado de Instrucción de Buenos Aires que acaba de jubilarse. Su sueño es escribir una novela y, para ello, intentará dar solución a un caso abierto desde hace varias décadas, del cual fue testigo y protagonista. Reviviendo el caso, vuelve también a su memoria el recuerdo de una mujer, a quien ha amado en silencio durante todos esos años.",
                     Poster = "SecretoDeSusOjos.png",
                     Trailer = "SecretoDeSusOjos.mp4",
                     IdGenre = (int)Enums.Genre.Drama
                 },
                 new Movie
                 {
                     IdMovie = 15,
                     Title = "Rescatando al soldado Ryan",
                     synopsis = "Después de desembarcar en Normandía, en plena Segunda Guerra Mundial, unos soldados norteamericanos deben arriesgar sus vidas para salvar al soldado James Ryan, cuyos tres hermanos han muerto en la guerra.",
                     Poster = "soldadoRyan.png",
                     Trailer = "soldadoRyan.mp4",
                     IdGenre = (int)Enums.Genre.Documental
                 },
                 new Movie
                 {
                     IdMovie = 16,
                     Title = "Sherk 2",
                     synopsis = "Shrek, nuestro ogro favorito, debe enfrentarse al mayor de los problemas que se podía imaginar: conocer a sus suegros.",
                     Poster = "sherk.png",
                     Trailer = "sherk.mp4",
                     IdGenre = (int)Enums.Genre.Fantasia
                 },
                 new Movie
                 {
                     IdMovie = 17,
                     Title = "Star Wars: Episodio IV",
                     synopsis = "La nave en la que viaja la princesa Leia es capturada por las tropas imperiales al mando del temible Darth Vader. Antes de ser atrapada, Leia consigue introducir un mensaje en su robot R2-D2, quien acompañado de su inseparable C-3PO logran escapar. Tras aterrizar en el planeta Tattooine son capturados y vendidos al joven Luke Skywalker, quien descubrirá el mensaje oculto que va destinado a Obi Wan Kenobi, maestro Jedi a quien Luke debe encontrar para salvar a la princesa",
                     Poster = " StarWars.png",
                     Trailer = " StarWars.mp4",
                     IdGenre = (int)Enums.Genre.CienciaFiccion
                 },
                 new Movie
                 {
                     IdMovie = 18,
                     Title = "Forrest Gump",
                     synopsis = "Sentado en un banco en Savannah, Georgia, Forrest Gump espera al autobús. Mientras éste tarda en llegar, el joven cuenta su vida a las personas que se sientan a esperar con él. Aunque sufre un pequeño retraso mental, esto no le impide hacer cosas maravillosas. Sin entender del todo lo que sucede a su alrededor, Forrest toma partido en los eventos más importantes de la historia de los Estados Unidos.",
                     Poster = "ForrestGump.png",
                     Trailer = "ForrestGump.mp4",
                     IdGenre = (int)Enums.Genre.Aventuras
                 },
                 new Movie
                 {
                     IdMovie = 19,
                     Title = "El lobo de Wall Street",
                     synopsis = "La historia del corredor de bolsa neoyorquino Jordan Belfort, quien, con poco más de veinte años, fue apodado 'el lobo de Wall Street' por su enorme éxito y fortuna como fundador de la agencia bursátil Stratton Oakmont.",
                     Poster = "ElLoboWallStreet.png",
                     Trailer = "WallStreet.mp4",
                     IdGenre = (int)Enums.Genre.Documental
                 },
                 new Movie
                 {
                     IdMovie = 20,
                     Title = "El club de la pelea",
                     synopsis = "Un empleado de oficina insomne, harto de su vida, se cruza con un vendedor peculiar. Ambos crean un club de lucha clandestino como forma de terapia y, poco a poco, la organización crece y sus objetivos toman otro rumbo.",
                     Poster = "ElClubDeLaPelea.png",
                     Trailer = "ElClubDeLaPelea.mp4",
                     IdGenre = (int)Enums.Genre.Accion
                 }
                );
        }
    }
}
