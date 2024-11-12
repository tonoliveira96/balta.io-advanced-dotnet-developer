using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Handles.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
