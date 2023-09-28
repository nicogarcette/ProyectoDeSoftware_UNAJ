using NgCinema.Domain.Entities;

namespace NgCinema.Application.Interfaces.Command
{
    public interface IFunctionCommand
    {
        Task<int> InsertFunction(Function function);
        Task<int> DeleteFunction(Function function);
    }
}
