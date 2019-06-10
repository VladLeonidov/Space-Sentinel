using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.WeaponComponents
{
    public interface IBulletsSpawnStratagy
    {
        void SpawnBullets(GameObject bulletPrefab, Vector2 position, Quaternion rotation);
    }
}