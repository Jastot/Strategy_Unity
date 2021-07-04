using Zenject;

namespace DefaultNamespace
{
    public class ControlButtonPanel
    {
        [Inject]private CommandCreator<IProduceUnitCommand> _produceUnitCommand; 
        [Inject]private CommandCreator<IAttackCommand> _AttackCommand; 
        [Inject]private CommandCreator<IMoveCommand> _MoveCommand; 
        [Inject]private CommandCreator<IStopCommand> _StopCommand; 

        public void HandleClick(ICommandExecutor executor)
        {
            _produceUnitCommand.CreateCommand(executor, (command)=> executor.Execute(command));
            _AttackCommand.CreateCommand(executor, (command) => executor.Execute(command));
            _MoveCommand.CreateCommand(executor, (command) => executor.Execute(command));
            _StopCommand.CreateCommand(executor, (command) => executor.Execute(command));
        }
    }
}