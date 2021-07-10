using System;
using Model;
using UniRx;
using UnityEngine;
using View;

namespace Presenter
{
    public class SelectedItemPresenter: MonoBehaviour
    {
        

        [SerializeField] private SelectedItemModel _selectedItemModel;
        [SerializeField] private SelectedItemView _selectedItemView;
        private IDisposable _healthUpdater;
        public void Start()
        {
            _selectedItemModel.OnUpdated += UpdateView;
            UpdateView();
        }

        public void OnDestroy()
        {
            _selectedItemModel.OnUpdated -= UpdateView;
            
        }

        private void UpdateView()
        {
            if (_healthUpdater != null)
            {
                _healthUpdater.Dispose();
                _healthUpdater = null;
            }
            if (_selectedItemModel.Value == null)
            {
                _selectedItemView.gameObject.SetActive(false);
                return;
            }
            _selectedItemView.gameObject.SetActive(true);
            _selectedItemView.Icon = _selectedItemModel.Value.Icon;
            _selectedItemView.Health = $"Health: {_selectedItemModel.Value.Health} / {_selectedItemModel.Value.MaxHealth}";
            _selectedItemView.Name = _selectedItemModel.Value.Name;
            _healthUpdater = _selectedItemModel.Value.Health.Subscribe(currentHealth =>
            {
                _selectedItemView.HeathBar = currentHealth / _selectedItemModel.Value.MaxHealth;
                _selectedItemView.Health = $"Health: {currentHealth} / {_selectedItemModel.Value.MaxHealth}";
            });
        }
        
    }
}