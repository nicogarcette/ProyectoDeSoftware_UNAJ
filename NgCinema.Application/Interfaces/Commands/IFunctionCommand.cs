using NgCinema.Domain.Entities;

namespace NgCinema.Application.Interfaces.Command
{
    public interface IFunctionCommand
    {
        int InsertFunction(Function function);
    }
}
