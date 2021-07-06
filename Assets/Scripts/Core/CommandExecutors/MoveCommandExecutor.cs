using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.CommandExecutors
{
    public class MoveCommandExecutor: CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private NavMeshAgent _agent;
        
        protected override void ExecuteSpecificCommand(IMoveCommand command)
        {
            _agent.SetDestination(command.To);
        }
    }
}