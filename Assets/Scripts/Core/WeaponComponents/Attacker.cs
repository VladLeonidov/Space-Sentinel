using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;

namespace Core.WeaponComponents
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField]
        private GameObject bulletPrefab;
        [SerializeField]
        private float attackSpeed;
        [SerializeField]
        private AudioClip shootAudio;

        public IBulletsSpawnStratagy BulletsSpawnStratagy { get; set; }

        private Transform _selfTransform;
        private float _attackSpeedTimer;

        bool _firstAttack = true;

        private void Awake()
        {
            _selfTransform = this.transform;
            BulletsSpawnStratagy = new SingleBulletsSpawnStratagy();
        }

        private void Update()
        {
            if (_firstAttack)
            {
                float randDelay = Random.Range(0f, this.attackSpeed);
                _attackSpeedTimer = randDelay;
                _firstAttack = false;
            }

            Attack();
            IncreaseAttackSpeedTimer();
        }

        public void SetActive(bool active)
        {
            this.gameObject.SetActive(active);
        }

        private void Attack()
        {
            if (_attackSpeedTimer == 0)
            {
                BulletsSpawnStratagy.SpawnBullets
                    (
                        this.bulletPrefab, 
                        _selfTransform.position, 
                        _selfTransform.rotation
                    );
                if (this.shootAudio != null)
                {
                    ManagerProvider.AudioManager.PlaySound(this.shootAudio);
                }
            }
        }

        private void IncreaseAttackSpeedTimer()
        {
            _attackSpeedTimer += Time.deltaTime;
            if (_attackSpeedTimer >= this.attackSpeed)
            {
                _attackSpeedTimer = 0f;
            }
        }
    }
}