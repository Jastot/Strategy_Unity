using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = nameof(AttackableTargetModel), menuName = "Strategy/" + nameof(AttackableTargetModel))]
    public class AttackableTargetModel: ScriptableObjectContainerBase<GameObject>
    {
    }
}