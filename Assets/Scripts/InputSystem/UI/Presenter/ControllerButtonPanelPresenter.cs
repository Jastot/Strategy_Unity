using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace
{
    public class ControllerButtonPanelPresenter: MonoBehaviour
    {

        [SerializeField] private SelectedItemModel _model;
        [SerializeField] private ControllerButtonPanelView _view;

        [Inject] private ControlButtonPanel _controlButtonPanel;

        private void Start()
        {
            _model.OnUpdated += SetButtons;
            _view.OnClick += OnClick;
            SetButtons();
        }

        private void OnClick(ICommandExecutor executor)
        {
           // executor.Execute(new ProduceUnitCommand(null));
           _controlButtonPanel.HandleClick(executor);
        }

        private void SetButtons()
        {
            _view.ClearButtons();
            if (_model.Value == null)
            {
                return;
            }
            var executors = 
                (_model.Value as Component)?.GetComponents<ICommandExecutor>().ToList();
            _view.SetButtons(executors);
        }

        private void OnDestroy()
        {
            _model.OnUpdated -= SetButtons;
            _view.OnClick -= OnClick;
        }
        
    }
}