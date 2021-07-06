using UnityEngine;

namespace DefaultNamespace
{ 
    [CreateAssetMenu(fileName = "Strategy/Models/"+nameof(HoldPositionModel))] 
    public class HoldPositionModel: ScriptableObjectContainerBase<bool> 
    { }
    
}