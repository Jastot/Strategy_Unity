using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace DefaultNamespace
{
    public class InputController: MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private SelectedItemModel _selectedItemModel;
        [SerializeField] private GroundClickModel _currentGroundClick;
        [SerializeField] private HoldPositionModel _holdPositionModel;
        private void Update()
        {
            if (_eventSystem.IsPointerOverGameObject())
            {
                return;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var infoHit))
                {
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

            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var infoHit))
                {
                    Debug.Log("Right");
                }
            }
        }
    }
}