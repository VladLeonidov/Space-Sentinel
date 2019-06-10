using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;

namespace Core.AI.EnemyWaves
{
    public class EnemyWavesController : MonoBehaviour
    { 
        [SerializeField]
        private float spawnDelay;

        private EnemyWave[] enemyWaves;
        private int _enemyWaveIndex;
        private bool _difficultUpped;
        private bool _gameStarted;

        private void Awake()
        {
            _enemyWaveIndex = 0;
            _gameStarted = false;

            this.enemyWaves = GetComponentsInChildren<EnemyWave>();

            ManagerProvider.EventManager.DifficultUpEvent.Subscribe(OnWaveChanged);
            ManagerProvider.EventManager.CanGenerateNewWaveEvent.Subscribe(OnWaveCanGenerte);
            ManagerProvider.EventManager.GameStartedEvent.Subscribe(OnGameStarted);
        }

        private void Start()
        {
            this.enemyWaves[_enemyWaveIndex].Initialize();
            this.enemyWaves[_enemyWaveIndex].Activate();

            for (int i = 1; i < this.enemyWaves.Length; i++)
            {
                this.enemyWaves[i].Initialize();
                this.enemyWaves[i].gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (_gameStarted)
            {
                GenerateNewWave(this.enemyWaves[_enemyWaveIndex]);
                _gameStarted = false;
            }
        }

        private void OnDestroy()
        {
            this.enemyWaves = null;
            _enemyWaveIndex = 0;
            ManagerProvider.EventManager.DifficultUpEvent.Unsubscribe(OnWaveChanged);
            ManagerProvider.EventManager.CanGenerateNewWaveEvent.Unsubscribe(OnWaveCanGenerte);
            ManagerProvider.EventManager.GameStartedEvent.Unsubscribe(OnGameStarted);
        }

        public EnemyWave GetCurrentEnemyWave()
        {
            return this.enemyWaves[_enemyWaveIndex];
        }

        private void OnWaveChanged()
        {
            if (_enemyWaveIndex < this.enemyWaves.Length - 1)
            {
                _enemyWaveIndex++;
                _difficultUpped = true;
            }
        }

        private void OnWaveCanGenerte()
        {
            if (!_difficultUpped)
            {
                if (this.enemyWaves != null)
                {
                    StartCoroutine(GenerateNewWaveWithDelay(this.enemyWaves[_enemyWaveIndex]));
                }
            }
            else
            {
                ChangeWaveDifficult();
                _difficultUpped = false;
            }
        }

        private void OnGameStarted()
        {
            _gameStarted = true;
        }

        private void ChangeWaveDifficult()
        {
            this.enemyWaves[_enemyWaveIndex - 1].Deactivate();
            this.enemyWaves[_enemyWaveIndex - 1].gameObject.SetActive(false);
            this.enemyWaves[_enemyWaveIndex].gameObject.SetActive(true);
            this.enemyWaves[_enemyWaveIndex].Activate();

            Debug.Log("Wave changed");
        }

        private void GenerateNewWave(EnemyWave wave)
        {
            wave.Generate();
            ManagerProvider.EventManager.EnemyWaveGeneratedEvent.OnEvent(wave);
        }

        private IEnumerator GenerateNewWaveWithDelay(EnemyWave wave)
        {
            yield return new WaitForSeconds(this.spawnDelay);
            wave.Generate();
            ManagerProvider.EventManager.EnemyWaveGeneratedEvent.OnEvent(wave);
        }
    }
}