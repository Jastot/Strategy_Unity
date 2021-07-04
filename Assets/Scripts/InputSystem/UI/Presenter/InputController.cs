using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class InputController: MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private SelectedItemModel _selectedItemModel;
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
                        _selectedItemModel.SetValue(null);
                    }
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var infoHit))
                {
                    
                }
            }
        }
    }
}