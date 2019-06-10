using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.WeaponComponents
{
    public class PlasmaState : IWeaponState
    {
        public void ChangeState(WeaponController weaponController)
        {
            for (int i = 0; i < weaponController.WeaponsLength; i++)
            {
                weaponController[i].SetActive(false);
            }

            weaponController.CurrentAttacker = weaponController[(int) WeaponType.Plasma];
            weaponController.CurrentAttacker.SetActive(true);

            weaponController.SetDefaultWeaponBulletsSpawnStratagy();
        }
    }
}