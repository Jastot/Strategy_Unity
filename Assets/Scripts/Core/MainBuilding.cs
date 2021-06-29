using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class MainBuilding: MonoBehaviour, ISelectableItem
    {
        [SerializeField] private GameObject mainObject;
        [SerializeField] private string _name;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;
        [SerializeField] private Sprite _icon;
        
        public string Name => _name;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        public GameObject Object => mainObject;
    }
}