using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Collisions
{
    [RequireComponent(typeof(PlayerDie))]
    public class PlayerCollision : BaseCollision
    {
        [SerializeField]
        private int selfDamage;

        protected override void EnterCollisionHandling(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                GetComponent<PlayerDie>().TakeDamage(this.selfDamage);
            }
        }

        protected override void ExitCollisionHandling(Collider2D collision)
        {
            //NOP
        }
    }
}