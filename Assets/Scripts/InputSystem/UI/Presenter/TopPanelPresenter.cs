using System;
using Abstractions;
using UniRx;
using UnityEngine;
using View;
using Zenject;

namespace Presenter
{
    public class TopPanelPresenter: MonoBehaviour
    {
        [SerializeField] private TopPanelView _view;
        [SerializeField] private GameObject _menu;
        [Inject] private ITimeModel _timeModel;
        
        protected void Awake()
        {
            _view.MenuButtonClick.Subscribe(unit => HandleMenuButtonClick());
            _timeModel.GameTime.Subscribe(time => _view.TimeFormatted = TimeSpan.FromSeconds(time).ToString());
        }

        private void HandleMenuButtonClick()
        {
            _menu.gameObject.SetActive(true);
            
            Debug.Log("ShowMenu");
            _timeModel.Pause();
        }
    }
}