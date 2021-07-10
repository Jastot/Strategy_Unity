using Abstractions;
using UnityEngine;

namespace Core.CommandExecutors
{
    public class ProduceUnitCommandExecutor: CommandExecutorBase<IProduceUnitCommand>
    {
        protected override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, (transform.position + Vector3.forward * 2), Quaternion.identity);
        }
    }
}