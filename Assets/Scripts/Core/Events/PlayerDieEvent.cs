using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Core.Events
{
    public class PlayerDieEvent : IEvent
    {
        private event Action _plyerDie;

        public void OnEvent()
        {
            _plyerDie?.Invoke();
        }

        public void Subscribe(Action handler)
        {
            _plyerDie += handler;
        }

        public void Unsubscribe(Action handler)
        {
            _plyerDie -= handler;
        }
    }
}