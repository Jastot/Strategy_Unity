using UnityEngine;
using UniRx;
using System;

namespace Abstractions
{
    public interface ISelectableItem
    {
        GameObject Object { get; }
        string Name { get; }
        IObservable<float> Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; } 
        Vector3 CurrentPosition { get; }
    }

}