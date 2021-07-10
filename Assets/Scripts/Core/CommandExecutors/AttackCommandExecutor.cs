using Abstractions;
using UnityEngine;

namespace Core.CommandExecutors
{
    public class AttackCommandExecutor: CommandExecutorBase<IAttackCommand>
    {
        protected override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log("Attack");
        }
    }
}