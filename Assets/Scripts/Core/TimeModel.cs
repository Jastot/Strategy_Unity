using System;
using Abstractions;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core
{
    public class TimeModel: ITimeModel, ITickable
    {
        public IObservable<int> GameTime => _gameTime.Select(value => (int)value);
        private ReactiveProperty<float> _gameTime = new ReactiveProperty<float>();
        private bool _inPause;
        
        public void Pause()
        {
            _inPause = true;
            Time.timeScale = 0;
        }

        public void UnPause()
        {
            _inPause = false;
            Time.timeScale = 1;
        }

        public void Tick()
        {
            if (!_inPause)
            {
                _gameTime.Value += Time.deltaTime;
            }
        }
    }
}