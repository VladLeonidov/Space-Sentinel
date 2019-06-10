﻿using System.Collections;
using System.Collections.Generic;
using Core.AI.EnemyWaves.Squads;
using UnityEngine;

namespace Core.AI.EnemyWaves.Formations
{
    public class FalangeFormation : BaseFormation
    {
        public FalangeFormation
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
                result[i] = new SquadLine
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