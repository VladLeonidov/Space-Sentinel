using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Events
{
    public class HealthPickedEvent : IEvent
    {
        private event Action _healthPicked;

        public void OnEvent()
        {
            _healthPicked?.Invoke();
        }

        public void Subscribe(Action handler)
        {
            _healthPicked += handler;
        }

        public void Unsubscribe(Action handler)
        {
            _healthPicked -= handler;
        }
    }
}