using UnityEngine;

namespace DefaultNamespace
{
    public class ProduceUnitCommand: IProduceUnitCommand
    {
        [InjectAsset("Ellen")]private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }
}