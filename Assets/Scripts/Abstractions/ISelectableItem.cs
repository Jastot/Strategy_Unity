using UnityEngine;

namespace DefaultNamespace
{
    public interface ISelectableItem
    {
        string Name { get; }
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; } 
    }

}