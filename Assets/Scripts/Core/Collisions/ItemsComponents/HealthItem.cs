using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;

namespace Core.Collisions.ItemsComponents
{
    public class HealthItem : BaseItem
    {
        [SerializeField]
        private int increasingHealth;

        private PlayerManager _playerManager;

        private void Awake()
        {
            _playerManager = ManagerProvider.PlayerManager;
        }

        private void OnDestroy()
        {
            _playerManager = null;
        }

        protected override bool UseItem(Collider2D playerCollision)
        {
            if (_playerManager.CurrentHealth < _playerManager.MaxHealth)
            {
                _playerManager.CurrentHealth += this.increasingHealth;
                ManagerProvider.EventManager.HealthPickedEvent.OnEvent();
                return true;
            }

            return false;
        }
    }
}