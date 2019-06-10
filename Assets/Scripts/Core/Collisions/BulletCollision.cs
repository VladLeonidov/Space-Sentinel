using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using Core.Managers;
using Core.WeaponComponents;

namespace Core.Collisions
{
    [RequireComponent(typeof(Damager))]
    public class BulletCollision : BaseCollision
    {
        [SerializeField]
        private GameObject shootEffectPrefab;

        private Damager _damager;

        private void Awake()
        {
            _damager = GetComponent<Damager>();
        }

        protected override void EnterCollisionHandling(Collider2D collision)
        {
            if (collision.tag == "Enemy" && this.tag == "PlayerBullet")
            {
                CollisionWithEnemy(collision);
                PlayShootEffect(collision);
            }

            if (collision.tag == "Player" && this.tag == "EnemyBullet")
            {
                CollisionWithPlayer(collision);
                PlayShootEffect(collision);
            }
        }

        protected override void ExitCollisionHandling(Collider2D collision)
        {
            if (collision.tag == "Bound")
            {
                LeanPool.Despawn(this.gameObject);
            }
        }

        private void CollisionWithEnemy(Collider2D enemy)
        {
            enemy.GetComponent<EnemyDie>().TakeDamage(_damager.Damage);
            
            LeanPool.Despawn(this.gameObject);
        }

        private void CollisionWithPlayer(Collider2D player)
        {
            player.GetComponent<PlayerDie>().TakeDamage(_damager.Damage);

            LeanPool.Despawn(this.gameObject);
        }

        private void PlayShootEffect(Collider2D collision)
        {
            float rand = Random.Range(0.3f, 1f);

            Vector2 shootEffectPosition = new Vector2
                (
                    this.transform.position.x,
                    Mathf.Lerp(this.transform.position.y, collision.transform.position.y, rand)
                );

            ManagerProvider.AnimationManager.PlayAnimatedObject
            (
                this.shootEffectPrefab,
                shootEffectPosition,
                Quaternion.identity,
                0.5f            
            );
        }
    }
}