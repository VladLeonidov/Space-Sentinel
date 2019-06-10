using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Events
{
    public class GameStartedEvent : IEvent
    {
        private event Action _gameStarted;

        public void OnEvent()
        {
            _gameStarted?.Invoke();
        }

        public void Subscribe(Action handler)
        {
            _gameStarted += handler;
        }

        public void Unsubscribe(Action handler)
        {
            _gameStarted -= handler;
        }
    }
}