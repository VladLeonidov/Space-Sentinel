using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Events
{
    public class DifficultUpEvent : IEvent
    {
        private Action _difficultUp;

        public void OnEvent()
        {
            _difficultUp?.Invoke();
        }

        public void Subscribe(Action handler)
        {
            _difficultUp += handler;
        }

        public void Unsubscribe(Action handler)
        {
            _difficultUp -= handler;
        }
    }
}