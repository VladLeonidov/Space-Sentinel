using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Events
{
    public class FormationDieEvent : IEvent
    {
        private event Action _formationDie;

        public void OnEvent()
        {
            _formationDie?.Invoke();
        }

        public void Subscribe(Action handler)
        {
            _formationDie += handler;
        }

        public void Unsubscribe(Action handler)
        {
            _formationDie -= handler;
        }
    }
}