using UnityEngine;
using Zenject;

namespace DefaultNamespace.CommandExecutors
{
    public class HoldPositionExecutor: CommandExecutorBase<IHoldPosition>
    {
        protected override void ExecuteSpecificCommand(IHoldPosition command)
        {
        }
    }
}