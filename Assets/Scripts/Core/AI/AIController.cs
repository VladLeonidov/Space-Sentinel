using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.AI.EnemyWaves;
using Core.Managers;

namespace Core.AI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]
        private float enemySpeed;
        [SerializeField]
        private Border2D enemyBorder;

        private BaseMoveEnemyWaveStrategy _moveEnemyWaveStrategy;

        private void Awake()
        {
            ManagerProvider.EventManager.EnemyWaveGeneratedEvent.Subscribe(OnEnemyWaweGenerated);
        }

        private void FixedUpdate()
        {
            if (_moveEnemyWaveStrategy != null)
            {
                _moveEnemyWaveStrategy.Move();
            }
        }

        private void OnDestroy()
        {
            ManagerProvider.EventManager.EnemyWaveGeneratedEvent.Unsubscribe(OnEnemyWaweGenerated);
        }

        private void OnEnemyWaweGenerated(EnemyWave enemyWave)
        {
            _moveEnemyWaveStrategy = CreateRandomMoveEnemyStrategy(enemyWave);
        }

        private BaseMoveEnemyWaveStrategy CreateRandomMoveEnemyStrategy(EnemyWave enemyWave)
        {
            BaseMoveEnemyWaveStrategy strategy = null;
            int rand = Random.Range(0, 0);

            switch (rand)
            {
                case 0:
                    strategy = new HorizontalMoveEnemyWaveStrategy(enemyWave, this.enemySpeed, this.enemyBorder);
                    break;
                default:
                    goto case 0;
            }

            return strategy;
        }
    }
}