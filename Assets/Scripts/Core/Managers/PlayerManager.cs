using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Managers
{
    public class PlayerManager : AbstractManager
    {
        [SerializeField]
        private int maxHealth;

        private int _currentHealth;

        public int MaxHealth { get { return this.maxHealth; } }

        public int CurrentHealth
        {
            get
            {
                return _currentHealth;
            }

            set
            {
                _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
            }
        }

        private void OnDestroy()
        {
            Finalization();
        }

        public void ResetHealth()
        {
            CurrentHealth = maxHealth;
        }

        public override void Initialization()
        {
            CurrentHealth = maxHealth;

            ManagerProvider.EventManager.PlayerDieEvent.Subscribe(OnPlayerDie);
        }

        public override void Finalization()
        {
            ManagerProvider.EventManager.PlayerDieEvent.Unsubscribe(OnPlayerDie);
        }

        private void OnPlayerDie()
        {
            CurrentHealth--;
        }
    }
}
