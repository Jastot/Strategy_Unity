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
        [Inject] private HoldPositionModel _holdPositionModel;
        private void Start()
        {
            _model.OnUpdated += SetButtons;
            _view.OnClick += OnClick;
            SetButtons();
        }

        private void OnClick(ICommandExecutor executor,Button button)
        {
            if (button != null)
            {
                _holdPositionModel.SetValue(!_holdPositionModel.Value);
            }
            _controlButtonPanel.HandleClick(executor,_holdPositionModel);
        }

        private void SetButtons()
        {
            _view.ClearButtons();
            _view.gameObject.SetActive(false);
            if (_model.Value == null)
            {
                return;
            }
            _view.gameObject.SetActive(true);
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