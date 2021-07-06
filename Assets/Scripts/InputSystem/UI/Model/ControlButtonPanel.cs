using UnityEngine;
using Zenject;
using Zenject.ReflectionBaking.Mono.Cecil.Cil;

namespace DefaultNamespace
{
    public class ControlButtonPanel
    {
        [Inject]private CommandCreator<IProduceUnitCommand> _produceUnitCommand; 
        [Inject]private CommandCreator<IAttackCommand> _AttackCommand; 
        [Inject]private CommandCreator<IMoveCommand> _MoveCommand; 
        [Inject]private CommandCreator<IStopCommand> _StopCommand;
        [Inject]private CommandCreator<IPatrolCommand> _PatolCommand;
        [Inject]private CommandCreator<IHoldPosition> _HoldPositiCommand;
        public void HandleClick(ICommandExecutor executor, HoldPositionModel _holdPositionModel)
        {
            //запретить использование команд при вызове и переключить холд
            _HoldPositiCommand.CreateCommand(executor,(command) => executor.Execute(command));
            if (!_holdPositionModel.Value)
            {
                _produceUnitCommand.CreateCommand(executor, (command) => executor.Execute(command));
                _AttackCommand.CreateCommand(executor, (command) => executor.Execute(command));
                _MoveCommand.CreateCommand(executor, (command) => executor.Execute(command));
                _StopCommand.CreateCommand(executor, (command) => executor.Execute(command));
                _PatolCommand.CreateCommand(executor, (command) => executor.Execute(command));
            }
            
        }
    }
}