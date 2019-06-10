using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.AI.EnemyWaves.Squads;

namespace Core.AI.EnemyWaves.Formations
{
    public class WedgeFormation : BaseFormation
    {
        public WedgeFormation
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

            for (int i = 0; i < base.countSquads; i++)
            {
                int rand = Random.Range(0, base.enemyShipPrefabs.Length);
                result[i] = new SquadWedge
                    (
                        base.enemyShipPrefabs[rand],
                        new Vector2(base.startPosition.x, base.startPosition.y),
                        base.shipOffset, base.countShipsInSquad
                    );
                base.startPosition.y -= base.squadOffset;
            }

            return result;
        }
    }
}