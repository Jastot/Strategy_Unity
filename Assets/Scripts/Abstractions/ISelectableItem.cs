using UnityEngine;

namespace DefaultNamespace
{
    public interface ISelectableItem
    {
        GameObject Object { get; }
        string Name { get; }
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; } 
        Vector3 CurrentPosition { get; }
    }

}