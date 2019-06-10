using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.WeaponComponents;

namespace Core.Collisions.ItemsComponents
{
    public class WeaponTypeItem : BaseItem
    {
        [SerializeField]
        private WeaponType weaponType;

        protected override bool UseItem(Collider2D playerCollision)
        {
            WeaponController weapon = playerCollision.GetComponentInChildren<WeaponController>();

            switch (this.weaponType)
            {
                case WeaponType.Ion:
                    if (weapon.CurrentWeaponType == WeaponType.Ion)
                    {
                        return false;
                    }
                    weapon.SetState(WeaponType.Ion);
                    return true;
                case WeaponType.Laser:
                    if (weapon.CurrentWeaponType == WeaponType.Laser)
                    {
                        return false;
                    }
                    weapon.SetState(WeaponType.Laser);
                    return true;
                case WeaponType.Plasma:
                    if (weapon.CurrentWeaponType == WeaponType.Plasma)
                    {
                        return false;
                    }
                    weapon.SetState(WeaponType.Plasma);
                    return true;
                default:
                    return false;
            }
        }
    }
}