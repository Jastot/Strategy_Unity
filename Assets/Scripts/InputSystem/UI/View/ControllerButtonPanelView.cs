using System;
using System.Collections.Generic;
using System.Linq;
using Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ControllerButtonPanelView: MonoBehaviour
    {
        [SerializeField] private Button _produceUnitButton;
        [SerializeField] private Button _moveButton;
        [SerializeField] private Button _attackButton;
        [SerializeField] private Button _patrolButton;
        [SerializeField] private Button _holdPosition;
        [SerializeField] private Button _stopButton;

        private Color Normal = Color.white;
        private Color Pressed = Color.green;
        
        private Dictionary<Type, Button> _executorsToButtonsDictionary;

        public event Action<ICommandExecutor,Button> OnClick;
        private void Awake()
        {
            _executorsToButtonsDictionary = new Dictionary<Type, Button>()
            {
                {typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton},
                {typeof(CommandExecutorBase<IMoveCommand>), _moveButton},
                {typeof(CommandExecutorBase<IAttackCommand>), _attackButton},
                {typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton},
                {typeof(CommandExecutorBase<IHoldPosition>),_holdPosition},
                {typeof(CommandExecutorBase<IStopCommand>), _stopButton},
            };
        }

        public void ClearButtons()
        {
            foreach (var button in _executorsToButtonsDictionary.Values)
            {
               button.gameObject.SetActive(false);
               button.onClick.RemoveAllListeners();
            }
        }

        public void SetButtons(List<ICommandExecutor> commandExecutors)
        {
            foreach (var commandExecutor in commandExecutors)
            {
                var button = _executorsToButtonsDictionary
                    .FirstOrDefault(kpv => kpv.Key.IsInstanceOfType(commandExecutor)).Value;
                if (button == null)
                {
                    Debug.LogError("Not supported Executor");
                    continue;
                }
                button.gameObject.SetActive(true);
                button.onClick.AddListener(() =>
                {
                    Button buffButton = null;
                    if (button.gameObject.GetComponent<HoldingButtonView>())
                    {
                        MakeButtonIsPressed(button);
                        buffButton = button;
                    }
                    OnClick?.Invoke(commandExecutor,buffButton);
                });
            }
        }

        public void MakeButtonIsPressed(Button button)
        {
            var buttonColors = button.colors;
            if (buttonColors.normalColor == Normal)
            {
                buttonColors.normalColor = Pressed;
                buttonColors.selectedColor = Pressed;
            }
            else
            {
                buttonColors.normalColor = Normal;
                buttonColors.selectedColor = Normal;
            }
            button.colors = buttonColors;
        }
    }
}