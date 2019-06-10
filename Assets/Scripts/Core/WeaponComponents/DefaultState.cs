using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.WeaponComponents
{
    public class DefaultState : IWeaponState
    {
        public void ChangeState(WeaponController weaponController)
        {
            weaponController.CurrentAttacker = weaponController[0];
            weaponController.SetDefaultWeaponBulletsSpawnStratagy();
        }
    }
}