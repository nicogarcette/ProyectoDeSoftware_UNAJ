const inputPelicula = document.getElementById("inputPelicula");
const inputDate = document.getElementById("inputDate");
const intputGenero = document.getElementById("intputGenero");
const formFilter = document.getElementById("formFilter");
const allcards = document.getElementById("allcards");


const metodoGet = async (apiUrl) =>{

    try {
        const response = await fetch(apiUrl,{ method:"GET" });

        if (response.ok) {
            const data = await response.json(); 
            return data;
        } else {
            const errorData = await response.json(); 
            Swal.fire({
                    icon: 'error',
                    position: 'top-end',
                    title: 'Error',
                    text: errorData.message,
                    showConfirmButton: false,
                    timer: 1500
            })
        }
    } catch (error) {

        Swal.fire({
            icon: 'error',
            position: 'top-end',
            title: 'Error',
            showConfirmButton: false,
            timer: 1500
            
        })
    }
}

const cargarGeneros = async ()=>{

    const generos = await metodoGet("./generos.json");

    intputGenero.innerHTML += '<option value="" disabled selected>Selecciona un género</option>'

    generos.forEach(function (genero) {
        let option = document.createElement("option");
        option.value = genero.id;
        option.text = genero.nombre;
        intputGenero.appendChild(option);
    });

    formFilter.addEventListener("submit", function (event) {

        event.preventDefault();
        buscarFunciones();
    });
}

const createCardMovie = (movies) => {

    movies.forEach((element)=>{
        allcards.innerHTML +=   `<div class="card col-lg-4 col-12">
                                    <h2>${element.title}</h2>         
                                    <img class="card-img" src="${element.poster}" alt="movie">
                                    <button id="btn-movie${element.idMovie}" class="btn">Ver mas</button>
                                </div>`;
    })

    movies.forEach((element)=>{
        document.getElementById(`btn-movie${element.idMovie}`)?.addEventListener("click",()=>{

            let movieId = element.idMovie;
            window.location.href = `movie.html?movie=${movieId}`;
        })
    }) 
};

const buscarFunciones = () =>{

    let nombrePelicula = inputPelicula.value;
    let fechaFuncion = inputDate.value;
    let genero = intputGenero.value;

    console.log(`${nombrePelicula}  ${fechaFuncion} ${genero}`);

    getPelicularFiltro(nombrePelicula,genero,fechaFuncion);
};

const cargarPeliculas = async () => {

    const data = await metodoGet("https://localhost:7076/api/v1/Peliculas");
    createCardMovie(data);
};

const getPelicularFiltro = async (pelicula, genero, fecha) => {

    let url = "https://localhost:7076/api/v1/Funcion?"

    if (pelicula != "") {
        url+= `&Movie=${pelicula}`
    }

    if (genero != "") {
        url+= `&IdGenre=${genero}`
    }

    if (fecha != "") {
        url+= `&Date=${fecha}`
    }

    const data = await metodoGet(url);
  
    let array = [];

    for (var item of data) {
        array.push(item.movie);   
    }

    let movies = eliminarPeliculasDuplicadas(array);

    allcards.innerHTML = ""

    createCardMovie(movies);
      
};

const eliminarPeliculasDuplicadas = (array) =>{

    const uniqueMoviesSet = new Set(array.map(JSON.stringify));
    const uniqueMoviesArray = Array.from(uniqueMoviesSet, JSON.parse);

    return uniqueMoviesArray;
};

cargarPeliculas();
cargarGeneros();