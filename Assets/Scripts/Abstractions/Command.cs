using UnityEngine;

namespace DefaultNamespace
{
    public class ProduceUnitCommand: IProduceUnitCommand
    {
        [InjectAsset("Ellen")]private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }

    public class AttackUnitCommand : IAttackCommand
    {
        public GameObject Target { get; }

        public AttackUnitCommand(GameObject target)
        {
            Target = target;
        }
    }

    public class MoveUnitCommand : IMoveCommand
    {
        public Vector3 To { get; }
        
        public MoveUnitCommand(Vector3 to)
        {
            To = to;
        }
    }

    public class StopUnitCommand : IStopCommand
    {
        public Vector3 PositionOfUnit { get; }
        public StopUnitCommand(Vector3 positionOfUnit)
        {
            PositionOfUnit = positionOfUnit;
        }
    }

    public class HoldPositionUnitCommand : IHoldPosition
    {
        public bool Holding { get; }

        public HoldPositionUnitCommand(bool isActive)
        {
            Holding = isActive;
        }
    }
    
    public class PatrolUnitCommand: IPatrolCommand
    {
        public Vector3 From { get; }
        public Vector3 To { get; }
        
        public PatrolUnitCommand(Vector3 @from, Vector3 to)
        {
            From = from;
            To = to;
        }
    }
}