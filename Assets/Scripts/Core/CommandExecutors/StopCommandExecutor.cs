using Abstractions;

namespace Core.CommandExecutors
{
    public class StopCommandExecutor: CommandExecutorBase<IStopCommand>
    {
        protected override void ExecuteSpecificCommand(IStopCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}