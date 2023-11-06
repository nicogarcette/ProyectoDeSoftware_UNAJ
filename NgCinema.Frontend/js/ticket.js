document.addEventListener("DOMContentLoaded", function() {

    const jsonResponse = localStorage.getItem("ticket");
    if (jsonResponse !== null) {
        const data = JSON.parse(jsonResponse);
        GenerarTickets(data);
    }
});

const tickets = document.getElementById("tickets");

const GenerarTickets = (data) =>{

    tickets.innerHTML += `

                    <div class="room-info">
                        <p>Pelicula: <span class="room-name">${data.movie}</span></p>
                        <p>Room: <span class="room-name">${data.room}</span></p>
                        <p>Date: <span class="date">${data.date}</span></p>
                        <p>Time: <span class="time">${data.time}</span></p>
                        <p>User: <span class="user">${data.user}</span></p>
                    </div>
                    <div id="id-ticket">
                        <h4 class="title-cod">Codigos</h4>
                    </div>
                    
    `
    let idTicket = document.getElementById("id-ticket");
    data.tickets.forEach(element => {
        idTicket.innerHTML +=  `<p><i class="fa-solid fa-ticket fa-2xl p-3"></i>${element.idTicket}</p>`
    });
}
