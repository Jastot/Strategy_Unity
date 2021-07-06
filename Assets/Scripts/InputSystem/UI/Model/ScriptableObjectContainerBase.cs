using System;
using UnityEngine;

namespace DefaultNamespace
{
     public abstract class ScriptableObjectContainerBase<T> : ScriptableObject, IAwaitable<T>
    {
        private T _value;
        public T Value => _value;
        
        public event Action OnUpdated;

        public void SetValue(T value)
        {
            _value = value;
            OnUpdated?.Invoke();
        }
        
        public IAwaiter<T> GetAwaiter() => new ValueChangedNotifier(this);
        private class ValueChangedNotifier : IAwaiter<T>
        {
            private readonly ScriptableObjectContainerBase<T> _valueContainer;
            private Action _continuation;
            private T _result;
            private bool _isCompleted;

            public ValueChangedNotifier(ScriptableObjectContainerBase<T> valueContainer)
            {
                _valueContainer = valueContainer;
                valueContainer.OnUpdated += HandleValueChanged;
            }
            
            public void OnCompleted(Action continuation)
            {
                _continuation = continuation;
                if (IsCompleted)
                {
                    _continuation?.Invoke();
                }
            }

            private void HandleValueChanged()
            {
                _valueContainer.OnUpdated -= HandleValueChanged;
                _isCompleted = true;
                _result = _valueContainer.Value;
                _continuation?.Invoke();
            }

            public bool IsCompleted => _isCompleted;
            public T GetResult() => _result;
        }
    }
}