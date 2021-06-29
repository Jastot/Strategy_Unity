using System;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Strategy/Models/"+nameof(SelectedItemModel))]
    public class SelectedItemModel : ScriptableObject
    {
        public ISelectableItem Value { get; set; }
        
        // public ISelectableItem CurrentValue { get; private set; }
        // public Action<ISelectableItem> OnSelected;
        //
        // public void SetValue(ISelectableItem value)
        // {
        //     CurrentValue = value;
        //     OnSelected?.Invoke(value);
        // }

    }
}