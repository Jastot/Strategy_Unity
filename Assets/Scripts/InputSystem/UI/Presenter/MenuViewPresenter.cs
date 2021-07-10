using Abstractions;
using UnityEngine;
using UniRx;
using View;
using Zenject;

namespace Presenter
{
    public class MenuViewPresenter: MonoBehaviour
    {
        [SerializeField] private MenuView _view;
        [Inject] private ITimeModel _timeModel;
        
        protected void Awake()
        {
            _view.ContinueButtonClick.Subscribe(unit => HandleContinueButton());
        }

        private void HandleContinueButton()
        {
            gameObject.SetActive(false);
            _timeModel.UnPause();
        }
    }
}