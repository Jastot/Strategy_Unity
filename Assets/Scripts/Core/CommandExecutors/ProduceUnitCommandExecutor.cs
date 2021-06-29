using UnityEngine;

namespace DefaultNamespace.CommandExecutors
{
    public class ProduceUnitCommandExecutor: CommandExecutorBase<IProduceUnitCommand>
    {
        protected override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Debug.Log("produce unit");
        }
    }
}