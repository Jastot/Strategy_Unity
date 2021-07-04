using System;
using Zenject;

namespace DefaultNamespace
{
    public abstract class CommandCreator<T> where T: ICommand
    {
        public void CreateCommand(ICommandExecutor executor,Action<T> onCreate)
        {
            if (executor as CommandExecutorBase<T>)
            {
                CreateSpecificCommand(onCreate);
            }
        }

        protected abstract void CreateSpecificCommand(Action<T> onCreate);
    }

    public class ProduceUnitCommandCreator : CommandCreator<IProduceUnitCommand>
    {
        [Inject] private AssetStorage _assets;
        protected override void CreateSpecificCommand(Action<IProduceUnitCommand> onCreate)
        {
            onCreate?.Invoke(_assets.Inject(new ProduceUnitCommand()));
        }
    }
    
    public class AttackCommandCreator : CommandCreator<IAttackCommand>
    {
        protected override void CreateSpecificCommand(Action<IAttackCommand> onCreate)
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class MoveCommandCreator : CommandCreator<IMoveCommand>
    {
        private Action<IMoveCommand> _onCreate;
        private void HandleGroundClick;
        
        protected override void CreateSpecificCommand(Action<IMoveCommand> onCreate)
        {
            throw new System.NotImplementedException();
        }
    }
   
    public class StopCommandCreator : CommandCreator<IStopCommand>
    {
        protected override void CreateSpecificCommand(Action<IStopCommand> onCreate)
        {
            throw new System.NotImplementedException();
        }
    }
}