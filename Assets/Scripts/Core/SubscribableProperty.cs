using System;

namespace Core
{
    public class SubscribableProperty<T>
    {
        protected T _value;
        protected Action<T> _onChangeValue;

        public T Value => _value;

        public virtual void SetValue(T value)
        {
            _value = value;
            _onChangeValue?.Invoke(_value);
        }

        public void SubscribeOnValue (Action<T> subscribingAction)
        {
            _onChangeValue += subscribingAction;
        }

        public void UnsubscribeFromValue (Action<T> unsubscribingAction)
        {
            _onChangeValue -= unsubscribingAction;
        }
    }
}