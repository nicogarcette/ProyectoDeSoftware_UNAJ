using NgCinema.Application.DTOs;
using NgCinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCinema.Application.Interfaces.Services
{
    public interface IMovieService
    {
        List<GetMovie> GetAllMovies();
    }
}
