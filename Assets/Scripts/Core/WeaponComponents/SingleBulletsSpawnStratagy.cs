using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

namespace Core.WeaponComponents
{
    public class SingleBulletsSpawnStratagy : IBulletsSpawnStratagy
    {
        public void SpawnBullets(GameObject bulletPrefab, Vector2 position, Quaternion rotation)
        {
            LeanPool.Spawn(bulletPrefab, position, rotation);
        }
    }
}