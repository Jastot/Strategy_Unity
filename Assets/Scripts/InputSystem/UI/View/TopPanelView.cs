using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class TopPanelView: MonoBehaviour
    {
        [SerializeField] private Text _timeText;
        [SerializeField] private Button _menuButton;

        public string TimeFormatted
        {
            set => _timeText.text = value;
        }

        public IObservable<Unit> MenuButtonClick => _menuButton.OnClickAsObservable();
    }
}