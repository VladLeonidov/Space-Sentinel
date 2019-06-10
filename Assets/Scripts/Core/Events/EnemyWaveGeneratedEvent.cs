using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.AI.EnemyWaves;

namespace Core.Events
{
    public class EnemyWaveGeneratedEvent : IEvent<EnemyWave>
    {
        private event Action<EnemyWave> _enemyWaveGenerated;

        public void OnEvent(EnemyWave type)
        {
            _enemyWaveGenerated?.Invoke(type);
        }

        public void Subscribe(Action<EnemyWave> handler)
        {
            _enemyWaveGenerated += handler;
        }

        public void Unsubscribe(Action<EnemyWave> handler)
        {
            _enemyWaveGenerated -= handler;
        }
    }
}