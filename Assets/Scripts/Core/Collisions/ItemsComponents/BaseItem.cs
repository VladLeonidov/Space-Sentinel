using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using Core.Managers;

namespace Core.Collisions.ItemsComponents
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseItem : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 100)]
        private float dropShance;
        [SerializeField]
        private AudioClip pickUpItemSound;

        public float DropShance
        {
            get { return this.dropShance; }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                bool canDestroy = UseItem(collision);

                if (canDestroy)
                {
                    if (pickUpItemSound != null)
                    {
                        ManagerProvider.AudioManager.PlaySound(pickUpItemSound);
                    }

                    LeanPool.Despawn(this.gameObject);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Bound")
            {
                LeanPool.Despawn(this.gameObject);
            }
        }

        protected abstract bool UseItem(Collider2D playerCollision);
    }
}