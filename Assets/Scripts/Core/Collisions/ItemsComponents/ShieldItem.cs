using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Collisions.ItemsComponents
{
    public class ShieldItem : BaseItem
    {
        protected override bool UseItem(Collider2D playerCollision)
        {
            PlayerDie diePlayer = playerCollision.GetComponent<PlayerDie>();
            if (!diePlayer.IsShield)
            {
                diePlayer.ActivateShield();
                return true;
            }

            return false;
        }
    }
}