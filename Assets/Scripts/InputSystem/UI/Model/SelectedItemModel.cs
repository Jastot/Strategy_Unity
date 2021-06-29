﻿using System;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Strategy/Models/"+nameof(SelectedItemModel))]
    public class SelectedItemModel : ScriptableObject
    {
        private ISelectableItem _value;
        public ISelectableItem Value => _value;

        public void SetValue(ISelectableItem value)
        {
            _value = value;
            OnUpdated?.Invoke();
        }
        
        public event Action OnUpdated;
    }
}