using System;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Strategy/Models/"+nameof(GroundClickModel))]
    public class GroundClickModel: ScriptableObject
    {
        private Vector3 _value;
        public Vector3 Value => _value;

        public void SetValue(Vector3 value)
        {
            _value = value;
            OnUpdated?.Invoke();
        }
        
        public event Action OnUpdated;
    }
}