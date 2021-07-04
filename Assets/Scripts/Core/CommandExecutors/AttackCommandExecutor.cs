using UnityEngine;

namespace DefaultNamespace.CommandExecutors
{
    public class AttackCommandExecutor: CommandExecutorBase<IAttackCommand>
    {
        protected override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log("Attack");
        }
    }
}