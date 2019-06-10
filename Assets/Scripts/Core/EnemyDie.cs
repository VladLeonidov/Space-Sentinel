using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;
using Lean.Pool;

namespace Core
{
    [RequireComponent(typeof(ItemsDroper))]
    public class EnemyDie : BaseDie
    {
        [SerializeField]
        private long scoreCost;

        private ItemsDroper _itemDropper;

        private void Awake()
        {
            _itemDropper = GetComponent<ItemsDroper>();
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            if (CurrentHealth <= 0)
            {
                Transform selfTransform = this.transform;

                ManagerProvider.AnimationManager.PlayAnimatedObject
                    (base.explosionPrefab, selfTransform.position, selfTransform.rotation);

                ManagerProvider.AudioManager.PlaySound(base.explosionAudio);

                _itemDropper.DropRandomItem(selfTransform.position, selfTransform.rotation);

                ManagerProvider.ScoreManager.Score += this.scoreCost;

                ManagerProvider.EventManager.EnemyDieEvent.OnEvent(this.gameObject);

                LeanPool.Despawn(this.gameObject);
            }
        }
    }
}