using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;

namespace Core.AI.EnemyWaves.Squads
{
    public abstract class BaseSquad
    {
        protected List<GameObject> enemyShips;
        protected GameObject enemyShipPrefab;
        protected Vector2 startPosition;
        protected float shipOffset;
        protected int countShips;

        private bool _enable;

        public List<GameObject> EnemyShips
        {
            get
            {
                return this.enemyShips;
            }
        }

        public BaseSquad
            (
                GameObject enemyShipPrefab, Vector2 startPosition, 
                float shipOffset, int countShips
            )
        {
            enemyShips = new List<GameObject>();
            this.enemyShipPrefab = enemyShipPrefab;
            this.startPosition = startPosition;
            this.shipOffset = shipOffset;
            this.countShips = countShips;
            ManagerProvider.EventManager.EnemyDieEvent.Subscribe(OnEnemyShipDie);
            _enable = true;
        }

        public void Generate()
        {
            if (this.enemyShips.Count == 0)
            {
                GenerateShips();
            }
        }

        public void Activate()
        {
            _enable = true;
        }

        public void Deactivate()
        {
            _enable = false;
        }

        public void Dispose()
        {
            ManagerProvider.EventManager.EnemyDieEvent.Unsubscribe(OnEnemyShipDie);
        }

        protected abstract void GenerateShips();

        private void OnEnemyShipDie(GameObject enemyShip)
        {
            if (_enable)
            {
                this.enemyShips.Remove(enemyShip);

                if (this.enemyShips.Count == 0)
                {
                    ManagerProvider.EventManager.SquadDieEvent.OnEvent(this);
                }
            }
        }
    }
}