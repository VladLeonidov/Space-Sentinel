using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;
using Lean.Pool;
using Core.WeaponComponents;

namespace Core
{
    [RequireComponent(typeof(ImmortalEffect))]
    public class PlayerDie : BaseDie
    {
        [SerializeField]
        private GameObject shield;
        [SerializeField]
        private float immortalTimeAfterSpawn;

        private float _immortalTime;
        private bool _immortal;
        private Transform _selfTransform;
        private ImmortalEffect _immortalEffect;

        public bool IsShield { get; private set; }

        private void Awake()
        {
            base.CurrentHealth = base.health;
            _selfTransform = this.transform;
            this.shield.SetActive(false);
            _immortalEffect = GetComponent<ImmortalEffect>();
        }

        private void Update()
        {
            if (_immortal)
            {
                DecreaseImmortalTime();
                _immortalEffect.PlayEffect();
            }
        }

        public override void OnSpawn()
        {
            base.OnSpawn();
            ActivateImmortal(immortalTimeAfterSpawn);
        }

        public override void TakeDamage(int damage)
        {
            if (!IsShield && !_immortal)
            {
                base.TakeDamage(damage);
            }

            if (IsShield && !_immortal)
            {
                IsShield = false;
                this.shield.SetActive(false);
            }

            if (CurrentHealth <= 0)
            {
                ManagerProvider.AnimationManager.PlayAnimatedObject
                    (
                        base.explosionPrefab, 
                        _selfTransform.position, 
                        _selfTransform.rotation
                    );
                ManagerProvider.AudioManager.PlaySound(base.explosionAudio);
                ManagerProvider.EventManager.PlayerDieEvent.OnEvent();

                GetComponentInChildren<WeaponController>().SetState(WeaponType.Laser);
                LeanPool.Despawn(this.gameObject);
            }
        }

        public void ActivateShield()
        {
            IsShield = true;
            this.shield.SetActive(true);
        }

        public void ActivateImmortal(float immortalTime)
        {
            _immortal = true;
            _immortalTime = immortalTime;
        }

        public override void OnDespawn()
        {
            _immortal = false;
            IsShield = false;
            this.shield.SetActive(false);
        }

        private void DeactivateImmortal()
        {
            _immortal = false;
            _immortalTime = 0;
            _immortalEffect.SetSourceAlfa();
        }

        private void DecreaseImmortalTime()
        {
            _immortalTime -= Time.deltaTime;
            if (_immortalTime <= 0)
            {
                DeactivateImmortal();
            }
        }
    }
}