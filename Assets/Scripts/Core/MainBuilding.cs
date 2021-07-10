using System;
using Abstractions;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Core
{
    public class MainBuilding: MonoBehaviour, ISelectableItem
    {
        [SerializeField] private GameObject mainObject;
        [SerializeField] private string _name;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;
        [SerializeField] private Sprite _icon;
        
        public string Name => _name;
        public IObservable<float> Health => _reactiveHealth;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        public GameObject Object => mainObject;
        public Vector3 CurrentPosition => transform.position;
        
        private ReactiveProperty<float> _reactiveHealth;

        private void Awake()
        {
            _reactiveHealth = new ReactiveProperty<float>(_health);
        }

        private void Update()
        {
            //_reactiveHealth.Value -= 0.01f;
        }
    }
}