using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Collisions
{
    [RequireComponent(typeof(EnemyDie))]
    public class EnemyCollision : BaseCollision
    {
        [SerializeField]
        private int selfDamage;

        protected override void EnterCollisionHandling(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                GetComponent<EnemyDie>().TakeDamage(this.selfDamage);
            }
        }

        protected override void ExitCollisionHandling(Collider2D collision)
        {
            //NOP
        }
    }
}