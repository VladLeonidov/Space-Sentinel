using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.AI.EnemyWaves.Squads;
using Core.Managers;

namespace Core.AI.EnemyWaves.Formations
{
    public abstract class BaseFormation
    {
        protected Vector2 startPosition;
        protected float shipOffset;
        protected float squadOffset;
        protected int countShipsInSquad;
        protected int countSquads;
        protected GameObject[] enemyShipPrefabs;
        private bool _enable;

        public List<BaseSquad> Squads { get; }

        public BaseFormation
            (
                Vector2 startPosition, float shipOffset, float squadOffest,
                int countShipsInSquad, int countSquads, GameObject[] enemyShipPrefabs
            )
        {
            Squads = new List<BaseSquad>();
            this.startPosition = startPosition;
            this.shipOffset = shipOffset;
            this.squadOffset = squadOffest;
            this.countShipsInSquad = countShipsInSquad;
            this.countSquads = countSquads;

            if (enemyShipPrefabs == null || enemyShipPrefabs.Length == 0)
            {
                Debug.LogError("Enemy ship prefabs must be not null or length more then 0");
            }
            this.enemyShipPrefabs = enemyShipPrefabs;

            ManagerProvider.EventManager.SquadDieEvent.Subscribe(OnSquadDie);

            Squads.AddRange(CreateSquads());

            _enable = true;
        }

        public void Generate()
        {
            foreach (BaseSquad squad in Squads)
            {
                squad.Generate();
            }
        }

        public void Activate()
        {
            foreach (BaseSquad squad in Squads)
            {
                squad.Activate();
            }

            _enable = true;
        }

        public void Deactivate()
        {
            foreach (BaseSquad squad in Squads)
            {
                squad.Deactivate();
            }

            _enable = false;
        }

        public void Dispose()
        {
            ManagerProvider.EventManager.SquadDieEvent.Unsubscribe(OnSquadDie);
        }

        protected abstract BaseSquad[] CreateSquads();

        private void OnSquadDie(BaseSquad squad)
        {
            if (_enable)
            {
                squad.Dispose();
                Squads.Remove(squad);

                if (Squads.Count == 0)
                {
                    ManagerProvider.EventManager.FormationDieEvent.OnEvent();
                }
            }
        }
    }
}