using System;
using Abstractions;
using Model;
using UnityEngine;

namespace Presenter
{
    public class OutlineItemController: MonoBehaviour
    {
        [SerializeField] private SelectedItemModel _model;
        [SerializeField] private Material _outline;
        private ISelectableItem _lastItem = null;
        
        private void Start()
        {
            _model.OnUpdated += SetOutLine;
        }

        private void SetOutLine()
        {
            if (_lastItem != null)
            {
                foreach (var meshRenderer in _lastItem.Object.GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material = null;
                } 
            }
            if (_model.Value == null)
            {
                return;
            }
            
            foreach (var meshRenderer in _model.Value.Object.GetComponentsInChildren<MeshRenderer>())
            {
                meshRenderer.material = _outline;
            }

            _lastItem = _model.Value;
        }

        private void OnDestroy()
        {
            _model.OnUpdated -= SetOutLine;
        }
    }
}