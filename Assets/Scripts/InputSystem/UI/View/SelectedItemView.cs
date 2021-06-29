using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SelectedItemView: MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _name;
        [SerializeField] private Text _health;
        [SerializeField] private Slider _heathBar;

        public Sprite Icon
        {
            set => _image.sprite = value;
        }
        
        public string Name
        {
            set => _name.text = value;
        }
        
        public string Health
        {
            set => _health.text = value;
        }
        
        public float HeathBar
        {
            set => _heathBar.value = value;
        }
        
    }
}