using System.Collections;
using UnityEngine;
using Core.Managers;
using Core.AI.EnemyWaves.Formations;

namespace Core.AI.EnemyWaves
{
    public class EnemyWave : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] enemyShipPrefabs;
        [SerializeField]
        private Vector2 startPosition;
        [SerializeField]
        private float squadOffset;
        [SerializeField]
        private float shipOffset;
        [SerializeField]
        private int countShipsInSquad;
        [SerializeField]
        private int countSqudsInFormation;
        [SerializeField]
        private int countKindsOfFormation = 4;

        private bool _enable;

        public BaseFormation Formation { get; private set; }

        public void Initialize()
        {
            Formation = CreateRandomFormation();
            Deactivate();
            ManagerProvider.EventManager.FormationDieEvent.Subscribe(OnFormationDie);
        }

        public void Generate()
        {
            Formation.Generate();
        }

        public void Activate()
        {
            Formation.Activate();
            _enable = true;
        }

        public void Deactivate()
        {
            Formation.Deactivate();
            _enable = false;
        }

        private void OnDestroy()
        {
            Formation.Dispose();
            Formation = null;
            ManagerProvider.EventManager.FormationDieEvent.Unsubscribe(OnFormationDie);
        }

        private void OnFormationDie()
        {
            if (_enable)
            {
                Formation.Dispose();
                Formation = CreateRandomFormation();
                ManagerProvider.EventManager.CanGenerateNewWaveEvent.OnEvent();
            }
        }

        private BaseFormation CreateRandomFormation()
        {
            int rand = Random.Range(0, this.countKindsOfFormation);
            switch (rand)
            {
                case 0:
                    return new FalangeFormation
                        (
                            this.startPosition, this.squadOffset, this.shipOffset, 
                            this.countShipsInSquad, this.countSqudsInFormation, 
                            this.enemyShipPrefabs
                        );
                case 1:
                    return new WedgeFormation
                        (
                            this.startPosition, this.squadOffset, this.shipOffset,
                            this.countShipsInSquad, this.countSqudsInFormation, 
                            this.enemyShipPrefabs
                        );
                case 2:
                    return new ShieldFormation
                        (
                            this.startPosition, this.squadOffset, this.shipOffset,
                            this.countShipsInSquad, this.countSqudsInFormation, 
                            this.enemyShipPrefabs
                        );
                case 3:
                    return new ChessFormation
                        (
                            this.startPosition, this.squadOffset, this.shipOffset,
                            this.countShipsInSquad, this.countSqudsInFormation, 
                            this.enemyShipPrefabs
                        );
                default:
                    goto case 0;
            }
        }
    }
}