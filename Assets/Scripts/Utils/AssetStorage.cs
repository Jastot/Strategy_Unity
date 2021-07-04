using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Strategy/Storages/"+nameof(AssetStorage))]
    public class AssetStorage : ScriptableObject
    {
        [SerializeField] private List<GameObject> _assets;

        private GameObject GetAsset(string name)
        {
           return _assets.FirstOrDefault(assets => assets.name == name);
        }

        public T Inject<T>(T target) where T :class
        {
            var targetType = target.GetType();
            var fields = targetType.GetFields(BindingFlags.Public | BindingFlags.NonPublic |BindingFlags.Instance|BindingFlags.DeclaredOnly);
            foreach (var field in fields)
            {
                var injectAssetAttribute =
                    field.GetCustomAttribute(typeof(InjectAssetAttribute)) as InjectAssetAttribute;
                if (injectAssetAttribute != null)
                {
                    var asset = GetAsset(injectAssetAttribute.AssetName);
                    field.SetValue(target,asset);
                }
            }

            return target;
        }
    }
}