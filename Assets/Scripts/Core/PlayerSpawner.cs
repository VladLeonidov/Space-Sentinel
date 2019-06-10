using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using Core.Managers;

namespace Core
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject playerPrefab;
        [SerializeField]
        private Vector2 startPositionBeforeStartGame;
        [SerializeField]
        private Vector2 startPositionAfterStartGame;
        [SerializeField]
        private float delay;

        private void Awake()
        {
            LeanPool.Spawn(this.playerPrefab, this.startPositionBeforeStartGame, Quaternion.identity);
            ManagerProvider.EventManager.PlayerDieEvent.Subscribe(OnPlayerDie);
        }

        private void OnDestroy()
        {
            ManagerProvider.EventManager.PlayerDieEvent.Unsubscribe(OnPlayerDie);
        }

        private void OnPlayerDie()
        {
            if (ManagerProvider.PlayerManager.CurrentHealth > 0)
            {
                StartCoroutine(PlayerSpawnWithDelay());
            }
            else
            {
                ManagerProvider.LevelManager.LoadLevel(Levels.GameOverMenu);
            }
        }

        private IEnumerator PlayerSpawnWithDelay()
        {
            yield return new WaitForSeconds(this.delay);

            LeanPool.Spawn(this.playerPrefab, this.startPositionAfterStartGame, Quaternion.identity);
        }
    }
}