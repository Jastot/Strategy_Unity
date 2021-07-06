using UnityEngine;

namespace DefaultNamespace
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
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Vector3 CurrentPosition => transform.position;
    }
}