using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.WeaponComponents;

namespace Core.Collisions.ItemsComponents
{
    public class WeaponModItem : BaseItem
    {
        protected override bool UseItem(Collider2D playerCollision)
        {
            WeaponController weapon = playerCollision.GetComponentInChildren<WeaponController>();
            if (weapon.IsLastWeaponMod)
            {
                return false;
            }

            weapon.ChangeWeaponMod();
            return true;
        }
    }
}