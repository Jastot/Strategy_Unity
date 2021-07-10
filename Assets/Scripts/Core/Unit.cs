using System;
using Abstractions;
using UnityEngine;
using UniRx;

namespace Core
{
    public class Unit: MonoBehaviour, ISelectableItem
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _health;
        [SerializeField] private GameObject mainObject;
        
        
        public Sprite Icon => _icon;
        public GameObject Object => mainObject;
        public string Name => _name;
        public IObservable<float> Health => _reactiveHealth;
        public float MaxHealth => _maxHealth;
        public Vector3 CurrentPosition => transform.position;
        
        private ReactiveProperty<float> _reactiveHealth;

        private void Awake()
        {
            _reactiveHealth = new ReactiveProperty<float>(_health);
        }

        private void Update()
        {
            _reactiveHealth.Value -= 0.01f;
        }
    }
}