using UnityEngine;

namespace DefaultNamespace.CommandExecutors
{
    public class MoveCommandExecutor: CommandExecutorBase<IMoveCommand>
    {
        protected override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log("Go to");
        }
    }
}