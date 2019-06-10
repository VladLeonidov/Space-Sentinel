using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using Core.Managers;

namespace Core.Collisions.ItemsComponents
{
    public class BombItem : BaseItem
    {
        protected override bool UseItem(Collider2D playerCollision)
        {
            playerCollision.GetComponent<PlayerDie>().TakeDamage(3);
            return true;
        }
    }
}