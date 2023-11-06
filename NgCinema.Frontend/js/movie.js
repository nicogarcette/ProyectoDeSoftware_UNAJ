document.addEventListener('DOMContentLoaded', function() {
    const urlParams = new URLSearchParams(window.location.search);
    const movieId = urlParams.get('movie');
    
    cargarPelicula(movieId);
});

const cardMovie = document.getElementById("cardMovie");
const trailer = document.getElementById("trailer");
const funciones = document.getElementById("funciones");
const modal = document.getElementById('form-modal');
const user = document.getElementById('user');
const ticket = document.getElementById('ticket');
const comprarTicket = document.getElementById("comprarTicket");

class Ticket{
    constructor(tickets,movie,date,time,room,user) {
        this.tickets = tickets;
        this.movie = movie;
        this.date = date;
        this.time = time;
        this.user = user;
        this.room = room;
    }
}

const cargarStorage=(clave,valor)=>{
    localStorage.setItem(clave,valor);
}

const cargarPelicula = async (idPelicula) => {

    const response = await fetch(`https://localhost:7076/api/v1/Pelicula/${idPelicula}`,{method:"GET"});
    let data = await response.json();

    cardMovie.innerHTML +=   `<div class="card-pelicula col-lg-4 col-12">
                                <h2>${data.title}</h2>         
                                <img class="card-img" src="${data.poster}" alt="movie">
                                <p>Genero: <span class="genre">${data.genre.name}</span></p>
                                <p>${data.synopsis}</p>
                            </div>`;  
                            
    trailer.innerHTML += `<iframe class="trailer" src=${data.trailer} title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>
    `

    if (data.functions.length === 0) { 
        let titleFunciones =  document.getElementById('title-funciones');

        titleFunciones.innerText = "No hay funciones disponibles."
    }
    else{

        data.functions.forEach(element => {
            
            funciones.innerHTML += `<div class="funcion">
                                        <i class="fa-solid fa-film fa-2xl" style="color: #254d8d;"></i>
                                        <p>Fecha: ${element.date}</=>
                                        <p>Horario: ${element.time}</p>         
                                        <button id="btn-function${element.idFuntion}" type="button" class="btn btn-comprar" data-bs-toggle="modal" data-bs-target="#comprar">Comprar</button>
                                    </div>`; 
        });

        data.functions.forEach((element) => {

            document.getElementById(`btn-function${element.idFuntion}`).addEventListener("click",()=>{
                modal.setAttribute('id', element.idFuntion);
            })
        });
    }
}


comprarTicket.addEventListener("click",()=>{

    let Id = modal.getAttribute('id');
    let userName = user.value;
    let cantidadTicket = ticket.value;

    let apiUrl = `https://localhost:7076/api/v1/Funcion/${Id}/tickets`

    const postData =    {
                            user: userName,
                            quantity: cantidadTicket
                        }
    

    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json', 
        },
        body: JSON.stringify(postData) 
    };

    solicitud(apiUrl,requestOptions);
})

const solicitud = async (apiUrl, requestOptions) => {

    try {
        const response = await fetch(apiUrl, requestOptions);

        if (response.ok) {
            const data = await response.json(); 
            const info = new Ticket(
                data.tickets,
                data.function.movie.title,
                data.function.date,
                data.function.time,
                data.function.room.name,
                data.user
            );
            cargarStorage("ticket",JSON.stringify(info));
            botonPagar();
        } else {
            const errorData = await response.json(); 
            Swal.fire({
                    icon: 'warning',
                    position: 'top',
                    title: 'Informacion Cupo',
                    text: errorData.message
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

const botonPagar=()=>{

    const loader = document.getElementById("loader");
    loader.classList.remove("loader2");
    setTimeout(() => {
        window.location.href = "./ticket.html";
    }, 2000);
}


const obtenerStorage=()=>{

    if (localStorage.getItem("ticket") !== null) {
    
        let ticket=JSON.parse(localStorage.getItem("ticket"));
     
            tickets.innerHTML += `

                    <div class="room-info">
                        <p>Room: <span class="room-name">sala:${ticket.function.room.idRoom} ${ticket.function.room.name}</span></p>
                        <p>Date: <span class="date">${ticket.function.date}</span></p>
                        <p>Time: <span class="time">${ticket.function.time}</span></p>
                    </div>
                    <div class="user-info">
                        <p>User: <span class="user">${ticket.user}</span></p>
                    </div>
    `  
    }
 
}

