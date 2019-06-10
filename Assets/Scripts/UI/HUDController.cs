using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Managers;

namespace UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField]
        private Text scoreText;
        [SerializeField]
        private GameObject[] healthImages;

        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = ManagerProvider.PlayerManager.MaxHealth;
            ManagerProvider.EventManager.PlayerDieEvent.Subscribe(OnPlayerDie);
            ManagerProvider.EventManager.HealthPickedEvent.Subscribe(OnHealthPicked);
        }

        private void OnDestroy()
        {
            ManagerProvider.EventManager.PlayerDieEvent.Unsubscribe(OnPlayerDie);
            ManagerProvider.EventManager.HealthPickedEvent.Unsubscribe(OnHealthPicked);
        }

        private void Update()
        {
            ScoreUpdate();
        }

        private void ScoreUpdate()
        {
            this.scoreText.text = string.Format("Score: {0}", ManagerProvider.ScoreManager.Score);
        }

        private void OnHealthPicked()
        {
            this.healthImages[_currentHealth].SetActive(true);
            _currentHealth++;
        }

        private void OnPlayerDie()
        {
            _currentHealth--;
            this.healthImages[_currentHealth].SetActive(false);
        }
    }
}