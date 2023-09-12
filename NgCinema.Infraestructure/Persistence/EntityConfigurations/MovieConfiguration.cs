using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCinema.Domain.Entities;
using NgCinema.Domain.Enums;

namespace NgCinema.Infraestructure.Persistence.EntityConfigurations
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
                    synopsis = "El joven Farrokh, Freddie, se ofrece como cantante de la banda al enterarse de que se han quedado sin vocalista. Ninguno de ellos se imaginaba por aquel entonces que se convertirían en los mismísimos Queen.",
                    Poster = "https://m.media-amazon.com/images/M/MV5BMTA2NDc3Njg5NDVeQTJeQWpwZ15BbWU4MDc1NDcxNTUz._V1_.jpg",
                    Trailer = "https://www.youtube.com/watch?v=mP0VHJYFOAU",
                    IdGenre = (int)Enums.Genre.Musical
                },
                 new Movie
                 {
                     IdMovie = 2,
                     Title = "Harry Potter y El misterio del príncipe",
                     synopsis = "Sexta entrega de la saga del joven mago, en la que Harry descubre un poderoso libro y, mientras trata de descubrir sus orígenes, colabora con Dumbledore en la búsqueda de una serie de objetos mágicos que ayudarán en la destrucción de Lord Voldemort.",
                     Poster = "https://es.web.img3.acsta.net/medias/nmedia/18/67/05/06/19138964.jpg",
                     Trailer = "https://www.youtube.com/watch?v=NaM7nKvX4Es",
                     IdGenre = (int)Enums.Genre.Accion
                 },
                 new Movie
                 {
                     IdMovie = 3,
                     Title = "Cars",
                     synopsis = "El aspirante a campeón de carreras Rayo McQueen parece que está a punto de conseguir el éxito. Su actitud arrogante se desvanece cuando llega a una pequeña comunidad olvidada que le enseña las cosas importantes de la vida que había olvidado.",
                     Poster = "https://image.tmdb.org/t/p/original/lgBe9KD6DoLyQP28JZ6fSUGK8j0.jpg",
                     Trailer = "https://www.youtube.com/watch?v=SbXIj2T-_uk",
                     IdGenre = (int)Enums.Genre.Fantasia
                 },
                 new Movie
                 {
                     IdMovie = 4,
                     Title = "Rocky 2",
                     synopsis = "Rocky ha colgado los guantes de boxeo. Sin embargo, acepta la oferta de revancha de Apollo para una segunda pelea. Reticente, acepta cuando éste le llama cobarde, se teme que la pelea pueda acabar con el ya retirado Rocky.",
                     Poster = "https://i.pinimg.com/originals/1f/00/55/1f0055758a155eb4054353a76a262e8b.jpg",
                     Trailer = "https://www.youtube.com/watch?v=zAtnLcXEZ_E",
                     IdGenre = (int)Enums.Genre.Accion
                 },
                 new Movie
                 {
                     IdMovie = 5,
                     Title = "Toy Story 3",
                     synopsis = "Cuando su dueño Andy comienza la universidad Woody, Buzz y el resto de sus amigos juguetes comienzan a preocuparse por su incierto futuro. Todos acaban en una guardería donde comenzarán una serie de trepidantes y divertidas aventuras.",
                     Poster = "https://lumiere-a.akamaihd.net/v1/images/p_toystory3_19639_3c584e1f.jpeg",
                     Trailer = "https://www.youtube.com/watch?v=JcpWXaA2qeg",
                     IdGenre = (int)Enums.Genre.Fantasia
                 },
                 new Movie
                 {
                     IdMovie = 6,
                     Title = "Oppenheimer",       
                     synopsis = "El físico J Robert Oppenheimer trabaja con un equipo de científicos durante el Proyecto Manhattan, que condujo al desarrollo de la bomba atómica.",
                     Poster = "https://cloudfront-us-east-1.images.arcpublishing.com/copesa/S4367N7H5VAYTB225C4GCG2ZHI.jpeg",
                     Trailer = "https://www.youtube.com/watch?v=MVvGSBKV504",
                     IdGenre = (int)Enums.Genre.Documental
                 },
                 new Movie
                 {
                     IdMovie = 7,
                     Title = "Interstellar",
                     synopsis = "Un grupo de científicos y exploradores, encabezados por Cooper, realizan un viaje espacial para encontrar un lugar con las condiciones necesarias para reemplazar a la Tierra.Este grupo necesita encontrar un planeta más que garantice el futuro humano",
                     Poster = "https://i.ebayimg.com/images/g/B44AAOSwanViGSRR/s-l1200.webp",
                     Trailer = "https://www.youtube.com/watch?v=zSWdZVtXT7E",
                     IdGenre = (int)Enums.Genre.CienciaFiccion
                 },
                 new Movie
                 {
                     IdMovie = 8,
                     Title = "IT",
                     synopsis = "Varios niños de una pequeña ciudad del estado de Maine se alían para combatir a una entidad diabólica que adopta la forma de un payaso y desde hace mucho tiempo emerge cada 27 años para saciarse de sangre infantil.",
                     Poster = "https://i.ebayimg.com/images/g/sz8AAOSwcgNZHz-O/s-l1200.webp",
                     Trailer = "https://www.youtube.com/watch?v=xKJmEC5ieOk",
                     IdGenre = (int)Enums.Genre.Terror
                 },
                 new Movie
                 {
                     IdMovie = 9,
                     Title = "Spiderman 1",
                     synopsis = "Al sufrir la picadura de una araña genéticamente modificada, un estudiante de secundaria tímido y torpe adquiere increíbles capacidades como arácnido. Pronto comprenderá que su misión es utilizarlas para luchar contra el mal y defender a sus vecinos.",
                     Poster = "https://image.tmdb.org/t/p/original/vSsOo0GwXP2zDZP4EyXmHejJ3H8.jpg",
                     Trailer = "https://www.youtube.com/watch?v=t06RUxPbp_c",
                     IdGenre = (int)Enums.Genre.Accion
                 },
                 new Movie
                 {
                     IdMovie = 10,
                     Title = "Red social",
                     synopsis = "La historia de los jóvenes fundadores de la popular red social Facebook, especialmente de su creador más conocido, Mark Zuckerberg. Su leyenda reza: 'No se hacen 500 millones de amigos sin hacer unos cuantos enemigos'.",
                     Poster = "https://www.cubahora.cu/uploads/resources/images/2019/11/26/the-social-network.jpg",
                     Trailer = "https://www.youtube.com/watch?v=K1JWiaIY-Xg",
                     IdGenre = (int)Enums.Genre.Drama
                 },
                 new Movie
                 {
                     IdMovie = 11,
                     Title = "Buenos Vecinos",
                     synopsis = "Mac y Kelly acaban de tener una niña adorable y se han comprado una preciosa casa en las afueras. Pero estos exjuerguistas descubren de pronto que sus nuevos vecinos son los miembros de la fraternidad Delta Psi Beta, con el presidente Teddy Sanders.",
                     Poster = "https://pics.filmaffinity.com/Malditos_vecinos-933128749-large.jpg",
                     Trailer = "https://www.youtube.com/watch?v=iNMj0dc1og4",
                     IdGenre = (int)Enums.Genre.Comedia
                 },
                 new Movie
                 {
                     IdMovie = 12,
                     Title = "Batman: el caballero de la noche",
                     synopsis = "Con la ayuda del teniente Jim Gordon y del Fiscal del Distrito Harvey Dent, Batman mantiene a raya el crimen organizado en Gotham. Todo cambia cuando aparece el Joker, un nuevo criminal que desencadena el caos y tiene aterrados a los ciudadanos.",
                     Poster = "https://i.ibb.co/d0D2tQm/batman.png",
                     Trailer = "https://www.youtube.com/watch?v=emYLYfuZAbU",
                     IdGenre = (int)Enums.Genre.Accion
                 },
                 new Movie
                 {
                     IdMovie = 13,
                     Title = "La Isla Siniestra",         
                     synopsis = "Los agentes son enviados a una isla del puerto de Boston para investigar la desaparición de una asesina en el hospital psiquiátrico, un centro penitenciario para criminales. El centro guarda secretos y la isla esconde algo más peligroso que los pacientes.",
                     Poster = "https://musicart.xboxlive.com/7/7e811100-0000-0000-0000-000000000002/504/image.jpg?w=1920&h=1080",
                     Trailer = "https://www.youtube.com/watch?v=95z6iWCjEgc",
                     IdGenre = (int)Enums.Genre.Suspenso
                 },
                 new Movie
                 {
                     IdMovie = 14,
                     Title = "El secreto de sus ojos",
                     synopsis = "Benjamín Espósito es un oficial de un Juzgado de Instrucción jubilado. Su sueño es escribir una novela. intentará dar solución a un caso viejo, del cual fue testigo y protagonista. ",
                     Poster = "https://pics.filmaffinity.com/El_secreto_de_sus_ojos-483213496-large.jpg",
                     Trailer = "https://www.youtube.com/watch?v=GqdLlefQ8gU",
                     IdGenre = (int)Enums.Genre.Drama
                 },
                 new Movie
                 {
                     IdMovie = 15,
                     Title = "Rescatando al soldado Ryan",
                     synopsis = "Después de desembarcar en Normandía, en plena Segunda Guerra Mundial, unos soldados norteamericanos deben arriesgar sus vidas para salvar al soldado James Ryan, cuyos tres hermanos han muerto en la guerra.",
                     Poster = "https://es.web.img3.acsta.net/pictures/14/03/05/09/42/163621.jpg",
                     Trailer = "https://www.youtube.com/watch?v=TAyhMtyup3o",
                     IdGenre = (int)Enums.Genre.Documental
                 },
                 new Movie
                 {
                     IdMovie = 16,
                     Title = "Sherk 2",
                     synopsis = "Shrek, nuestro ogro favorito, debe enfrentarse al mayor de los problemas que se podía imaginar: conocer a sus suegros.",
                     Poster = "https://elfinalde.s3-accelerate.amazonaws.com/2017/11/rD8SvOTCCJ2VIpIV7GUwUKD1Kzc.jpg",
                     Trailer = "https://www.youtube.com/watch?v=xBxVgh-kgAI",
                     IdGenre = (int)Enums.Genre.Fantasia
                 },
                 new Movie
                 {
                     IdMovie = 17,
                     Title = "Star Wars: Episodio IV",
                     synopsis = "Princesa Leia es capturada por el temible DarthVader. Leia consigue introducir un mensaje en su robot. Tras aterrizar son capturados y vendidos al joven Luke Skywalker, quien descubrirá el mensaje oculto que va destinado a Obi Wan Kenobi, maestro Jedi.",
                     Poster = "https://i.ibb.co/dMfq8Xr/start.png",
                     Trailer = "https://www.youtube.com/watch?v=beAH5vea99k",
                     IdGenre = (int)Enums.Genre.CienciaFiccion
                 },
                 new Movie
                 {
                     IdMovie = 18,
                     Title = "Forrest Gump",
                     synopsis = "Forrest Gump espera al autobús. Mientras éste tarda en llegar, el joven cuenta su vida . Aunque sufre un pequeño retraso mental, esto no le impide hacer cosas maravillosas. el toma partido en los eventos más importantes de la historia de los EEUU.",
                     Poster = "https://m.media-amazon.com/im",
                     Trailer = "https://www.youtube.com/watch?v=Cyh1LpxnaxI",
                     IdGenre = (int)Enums.Genre.Aventuras
                 },
                 new Movie
                 {
                     IdMovie = 19,
                     Title = "El Lobo de Wall Street",
                     synopsis = "La historia del corredor de bolsa neoyorquino Jordan Belfort, quien, con poco más de veinte años, fue apodado 'el lobo de Wall Street' por su enorme éxito y fortuna como fundador de la agencia bursátil Stratton Oakmont.",
                     Poster = "https://es.web.img3.acsta.net/pictures/210/615/21061596_20131129121836144.jpg",
                     Trailer = "https://www.youtube.com/watch?v=PaAvUOXUohk",
                     IdGenre = (int)Enums.Genre.Documental
                 },
                 new Movie
                 {
                     IdMovie = 20,
                     Title = "El club de la pelea",
                     synopsis = "Un empleado de oficina insomne, harto de su vida, se cruza con un vendedor peculiar. Ambos crean un club de lucha clandestino como forma de terapia y, poco a poco, la organización crece y sus objetivos toman otro rumbo.",
                     Poster = "https://es.web.img2.acsta.net/r_1280_720/img/23/b7/23b757ce995171ae05ba7449c67a47dc.jpg",
                     Trailer = "https://www.youtube.com/watch?v=YD5BeUWgsSM",
                     IdGenre = (int)Enums.Genre.Accion
                 }
                );
        }
    }
}
