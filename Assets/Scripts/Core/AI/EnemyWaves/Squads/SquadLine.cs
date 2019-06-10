using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using Core.Managers;

namespace Core.AI.EnemyWaves.Squads
{
    public class SquadLine : BaseSquad
    {
        public SquadLine
            (
                GameObject enemyShipPrefab, Vector2 startPosition, 
                float shipOffset, int countShips
            ) : base
            (
                enemyShipPrefab, startPosition, 
                shipOffset, countShips
            )
        {
        }

        protected override void GenerateShips()
        {
            for (int i = 0; i < base.countShips; i++)
            {
                GameObject enemyShipInstance = LeanPool.Spawn
                    (
                        base.enemyShipPrefab, base.startPosition,
                        base.enemyShipPrefab.transform.rotation
                    );
                base.enemyShips.Add(enemyShipInstance);

                base.startPosition.x += base.shipOffset;
            }
        }
    }
}