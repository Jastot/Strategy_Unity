using UnityEngine;

namespace Model
{ 
    [CreateAssetMenu(fileName = "Strategy/Models/"+nameof(HoldPositionModel))] 
    public class HoldPositionModel: ScriptableObjectContainerBase<bool> 
    { }
    
}