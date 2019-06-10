using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.AI.EnemyWaves;
using Core.AI.EnemyWaves.Squads;

namespace Core.AI
{
    public abstract class BaseMoveEnemyWaveStrategy
    {
        protected List<Rigidbody2D> EnemyShips { get; }

        protected float EnemySpeed { get; }

        public BaseMoveEnemyWaveStrategy(EnemyWave enemyWave, float enemySpeed)
        {
            EnemyShips = new List<Rigidbody2D>();

            foreach (BaseSquad squad in enemyWave.Formation.Squads)
            {
                foreach (GameObject enemyShip in squad.EnemyShips)
                {
                    EnemyShips.Add(enemyShip.GetComponent<Rigidbody2D>());
                }
            }

            EnemySpeed = enemySpeed;
        }

        public abstract void Move();
    }
}