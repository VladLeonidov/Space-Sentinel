using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.AI.EnemyWaves.Squads;

namespace Core.Events
{
    public class SquadDieEvent : IEvent<BaseSquad>
    {
        private event Action<BaseSquad> _squdronDie;

        public void OnEvent(BaseSquad type)
        {
            _squdronDie?.Invoke(type);
        }

        public void Subscribe(Action<BaseSquad> handler)
        {
            _squdronDie += handler;
        }

        public void Unsubscribe(Action<BaseSquad> handler)
        {
            _squdronDie -= handler;
        }
    }
}