using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.AI.EnemyWaves.Squads;

namespace Core.AI.EnemyWaves.Formations
{
    public class ShieldFormation : BaseFormation
    {
        public ShieldFormation
            (
                Vector2 startPosition, float shipOffset, float squadOffest,
                int countShipsInSquad, int countSquads, GameObject[] enemyShipPrefabs
            ) : base
            (
                startPosition, shipOffset, squadOffest,
                countShipsInSquad, countSquads, enemyShipPrefabs
            )
        {
        }

        protected override BaseSquad[] CreateSquads()
        {
            BaseSquad[] result = new BaseSquad[base.countSquads];

            int midIndex = base.countSquads / 2;

            for (int i = 0; i < base.countSquads; i++)
            {
                int rand = Random.Range(0, base.enemyShipPrefabs.Length);
                if (i < midIndex)
                {
                    result[i] = new SquadLine
                        (
                            base.enemyShipPrefabs[rand], base.startPosition, 
                            base.shipOffset, base.countShipsInSquad
                        );
                }
                else
                {
                    result[i] = new SquadWedge
                        (
                            base.enemyShipPrefabs[rand],
                            new Vector2(base.startPosition.x, base.startPosition.y),
                            base.shipOffset, base.countShipsInSquad
                        );
                }
                
                base.startPosition.y -= base.shipOffset;
            }

            return result;
        }
    }
}