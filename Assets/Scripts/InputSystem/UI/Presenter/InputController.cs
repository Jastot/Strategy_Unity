using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class InputController: MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        [SerializeField] private SelectedItemModel _selectedItemModel;
        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var infoHit))
                {
                    var building = infoHit.collider.gameObject.GetComponent<ISelectableItem>();
                    if (building != null)
                    {
                        _selectedItemModel.Value = building;
                    }
                }
            }
        }
    }
}