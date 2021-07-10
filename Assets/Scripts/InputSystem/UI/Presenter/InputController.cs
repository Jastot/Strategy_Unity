using System;
using Abstractions;
using Model;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Presenter
{
    public class InputController: MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private SelectedItemModel _selectedItemModel;
        [SerializeField] private GroundClickModel _currentGroundClick;
        [SerializeField] private HoldPositionModel _holdPositionModel;

        private void Start()
        {
            var clickStream = Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(0));

            // var ignoringUI = Observable.EveryUpdate()
            //     .Where(_ =>
            //     {
            //         if (_eventSystem.IsPointerOverGameObject())
            //         {
            //             return null;
            //         }
            //
            //         return false;
            //     });
            clickStream
                .Subscribe(xs => Click());
            clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
                .Where(xs => xs.Count >= 2)
                .Subscribe(xs =>
                {
                    Debug.Log("DoubleClick Detected! Count:" + xs.Count);
                    Click();
                    //у можно будет потом еще делать поиск всех объектов данного типа,если дойдут руки...
                });
        }

        private void Click()
        {
            if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var infoHit))
            {
                if (_eventSystem.IsPointerOverGameObject())
                {
                    return;
                }
                var building = infoHit.collider.gameObject.GetComponent<ISelectableItem>();
                if (building != null)
                {
                    _selectedItemModel.SetValue(building);
            
                    
                }
                else
                {
                    if (!_holdPositionModel)
                    {
                        _currentGroundClick.SetValue(infoHit.point);
                    }
                    _selectedItemModel.SetValue(null);
                }
            }
        }
    }
}