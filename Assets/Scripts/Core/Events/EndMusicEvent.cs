using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Events
{
    public class EndMusicEvent : IEvent
    {
        private event Action _endMusic;

        public void OnEvent()
        {
            _endMusic?.Invoke();
        }

        public void Subscribe(Action handler)
        {
            _endMusic += handler;
        }

        public void Unsubscribe(Action handler)
        {
            _endMusic -= handler;
        }
    }
}