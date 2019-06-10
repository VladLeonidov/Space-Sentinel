using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

namespace Core.AI.EnemyWaves.Squads
{
    public class SquadWedge : BaseSquad
    {
        public SquadWedge
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
            int midIndex = countShips / 2;

            for (int i = 0; i < base.countShips; i++)
            {
                GameObject enemyShipInstance = LeanPool.Spawn
                    (
                        base.enemyShipPrefab, base.startPosition,
                        base.enemyShipPrefab.transform.rotation
                    );
                base.enemyShips.Add(enemyShipInstance);

                base.startPosition.x += base.shipOffset;

                ChangeDirectionSquadronGenertion
                    (ref startPosition, countShips, midIndex, base.shipOffset, i);
            }
        }

        private void ChangeDirectionSquadronGenertion
            (ref Vector2 shipPosition, int countShips, int midIndex, float offset, int index)
        {
            if ((countShips % 2) == 0)
            {
                if (index < (midIndex - 1))
                {
                    shipPosition.y -= (offset / 2);
                }
                else if (index == midIndex)
                {
                    shipPosition.y += (offset / 2);
                }
                else if (index > midIndex)
                {
                    shipPosition.y += (offset / 2);
                }
            }
            else
            {
                if (index < midIndex)
                {
                    shipPosition.y -= (offset / 2);
                }
                else
                {
                    shipPosition.y += (offset / 2);
                }
            }
        }
    }
}