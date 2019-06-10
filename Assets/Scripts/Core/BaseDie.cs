using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

namespace Core
{
    public abstract class BaseDie : MonoBehaviour, IPoolable
    {
        [SerializeField]
        protected int health;
        [SerializeField]
        protected GameObject explosionPrefab;
        [SerializeField]
        protected AudioClip explosionAudio;

        protected int CurrentHealth { get; set; }

        public virtual void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
        }

        public virtual void OnSpawn()
        {
            CurrentHealth = health;
        }

        public virtual void OnDespawn()
        {
            //NOP
        }
    }
}