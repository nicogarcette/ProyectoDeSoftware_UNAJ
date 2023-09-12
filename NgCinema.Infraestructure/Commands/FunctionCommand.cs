using NgCinema.Application.Interfaces.Command;
using NgCinema.Domain.Entities;
using NgCinema.Infraestructure.Persistence;

namespace NgCinema.Infraestructure.Commands
{
    public class FunctionCommand : IFunctionCommand
    {
        private readonly ApplicationDbContext _context;

        public FunctionCommand(ApplicationDbContext context)
        {
            _context = context;
        }

        public int InsertFunction(Function function)
        {
            _context.Functions.Add(function);
           
            return _context.SaveChanges();
        }
    }
}
