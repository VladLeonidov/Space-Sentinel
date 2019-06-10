using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.WeaponComponents
{
    public interface IWeaponState
    {
        void ChangeState(WeaponController weaponController);
    }
}