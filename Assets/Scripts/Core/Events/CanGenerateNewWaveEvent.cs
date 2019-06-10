using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Events
{
    public class CanGenerateNewWaveEvent : IEvent
    {
        private event Action _cangeneratenewWave;

        public void OnEvent()
        {
            _cangeneratenewWave?.Invoke();
        }

        public void Subscribe(Action handler)
        {
            _cangeneratenewWave += handler;
        }

        public void Unsubscribe(Action handler)
        {
            _cangeneratenewWave += handler;
        }
    }
}