using Abstractions;
using UnityEngine;
using Zenject;

namespace Core.CommandExecutors
{
    public class HoldPositionExecutor: CommandExecutorBase<IHoldPosition>
    {
        protected override void ExecuteSpecificCommand(IHoldPosition command)
        {
        }
    }
}