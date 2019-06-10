using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using Core.Managers;

namespace Core.Collisions
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            EnterCollisionHandling(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            ExitCollisionHandling(collision);
        }

        protected abstract void EnterCollisionHandling(Collider2D collision);
        protected abstract void ExitCollisionHandling(Collider2D collision);
    }
}