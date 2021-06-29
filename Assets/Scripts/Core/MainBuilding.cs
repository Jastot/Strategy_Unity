using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class MainBuilding: MonoBehaviour, IUnitProducer, ISelectableItem
    {
        public string Name => _name;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private string _name;
        [SerializeField] private float _maxHealth;
        [SerializeField] private Sprite _icon;

        private float _health;

        private void Awake()
        {
            _health = _maxHealth;
        }

        public void ProduceUnit()
        {
            Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }

    }
}