using System.Collections;
using System.Collections.Generic;
using Core.AI.EnemyWaves;
using UnityEngine;

namespace Core.AI
{
    public class HorizontalMoveEnemyWaveStrategy : BaseMoveEnemyWaveStrategy
    {
        private float _minDis = 1f;
        private float _currBorder;
        private Border2D _border;
        private Vector2 _direction;

        public HorizontalMoveEnemyWaveStrategy(EnemyWave enemyWave, float speed, Border2D border)
            : base(enemyWave, speed)
        {
            _border = border;
            _direction = new Vector2(-1, 0);
            _currBorder = _border.MinX;
        }

        public override void Move()
        {
            for (int i = 0; i < EnemyShips.Count; i++)
            {
                if (EnemyShips[i] == null)
                {
                    continue;
                }

                Vector2 enemyPos = EnemyShips[i].position;

                EnemyShips[i].velocity = _direction * EnemySpeed;

                Vector2 distance = new Vector2
                        (_currBorder, enemyPos.y) - new Vector2(enemyPos.x, enemyPos.y);

                if (CheckDistanceToBorer(distance, _minDis))
                {
                    _currBorder = -_currBorder;
                    _direction = -_direction;
                }

                enemyPos.x = Mathf.Clamp
                    (
                        enemyPos.x,
                        _border.MinX,
                        _border.MaxX
                    );
                EnemyShips[i].position = enemyPos;
            }
        }

        private bool CheckDistanceToBorer(Vector2 distance, float minDis)
        {
            if (distance.magnitude < minDis * minDis)
            {
                return true;
            }

            return false;
        }
    }
}