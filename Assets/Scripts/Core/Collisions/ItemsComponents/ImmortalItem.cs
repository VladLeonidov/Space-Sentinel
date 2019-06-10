using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Collisions.ItemsComponents
{
    public class ImmortalItem : BaseItem
    {
        [SerializeField]
        private float immortalTime;

        protected override bool UseItem(Collider2D playerCollision)
        {
            playerCollision.GetComponent<PlayerDie>().ActivateImmortal(this.immortalTime);
            return true;
        }
    }
}