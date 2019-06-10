using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

namespace Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour, IPoolable
    {
        [SerializeField]
        protected float speed;

        public Vector2 Direction { get; set; }

        public float Speed { get { return this.speed; } }

        protected Rigidbody2D Rb { get; set; }

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            Direction = Vector2.up;
        }

        private void FixedUpdate()
        {
            Move();
        }

        public virtual void OnSpawn()
        {
            //NOP
        }

        public virtual void OnDespawn()
        {
            Direction = Vector2.up;
        }

        protected virtual void Move()
        {
            Rb.velocity = Direction * speed;
        }
    }
}