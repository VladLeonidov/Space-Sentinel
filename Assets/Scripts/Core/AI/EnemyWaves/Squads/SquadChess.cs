using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

namespace Core.AI.EnemyWaves.Squads
{
    public class SquadChess : BaseSquad
    {
        public SquadChess
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

        //- - - -
        // - - -
        protected override void GenerateShips()
        {
            for (int i = 0; i < countShips; i++)
            {
                GameObject enemyShipInstance = LeanPool.Spawn
                    (
                        base.enemyShipPrefab, base.startPosition,
                        base.enemyShipPrefab.transform.rotation
                    );
                base.enemyShips.Add(enemyShipInstance);

                base.startPosition.x += base.shipOffset;

                if ((i % 2) == 0)
                {
                    base.startPosition.y -= (base.shipOffset / 2);
                }
                else
                {
                    base.startPosition.y += (base.shipOffset / 2);
                }
            }
        }
    }
}