using System;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class SelectedItemPresenter: MonoBehaviour
    {
        

        [SerializeField] private SelectedItemModel _selectedItemModel;
        [SerializeField] private SelectedItemView _selectedItemView;

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
            if (_selectedItemModel.Value == null)
            {
                _selectedItemView.gameObject.SetActive(false);
                return;
            }
            _selectedItemView.gameObject.SetActive(true);
            _selectedItemView.Icon = _selectedItemModel.Value.Icon;
            _selectedItemView.Health = $"Health: {_selectedItemModel.Value.Health} / {_selectedItemModel.Value.MaxHealth}";
            _selectedItemView.Name = _selectedItemModel.Value.Name;
            _selectedItemView.HeathBar = _selectedItemModel.Value.Health / _selectedItemModel.Value.MaxHealth;
        }
        
    }
}