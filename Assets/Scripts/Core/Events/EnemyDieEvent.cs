using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Events
{
    public class EnemyDieEvent : IEvent<GameObject>
    {
        private event Action<GameObject> _enemyDieEvent;

        public void OnEvent(GameObject enemyShip)
        {
            _enemyDieEvent?.Invoke(enemyShip);
        }

        public void Subscribe(Action<GameObject> handler)
        {
            _enemyDieEvent += handler;
        }

        public void Unsubscribe(Action<GameObject> handler)
        {
            _enemyDieEvent -= handler;
        }
    }
}