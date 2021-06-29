using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class SelectedItemPresenter: MonoBehaviour
    {
        

        [SerializeField] private SelectedItemModel _selectedItemModel;
        [SerializeField] private SelectedItemView _selectedItemView;

        private void UpdateView()
        {
            _selectedItemModel.Value
        }
        
    }
}