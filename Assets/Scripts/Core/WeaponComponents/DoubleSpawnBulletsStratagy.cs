using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

namespace Core.WeaponComponents
{
    public class DoubleSpawnBulletsStratagy : IBulletsSpawnStratagy
    {
        private float _offset;

        public DoubleSpawnBulletsStratagy(float offset)
        {
            _offset = offset;
        }

        public void SpawnBullets(GameObject bulletPrefab, Vector2 position, Quaternion rotation)
        {
            Vector2 leftBulletPosition = new Vector2(position.x - _offset, position.y);
            Vector2 rightBulletPosition = new Vector2(position.x + _offset, position.y);

            LeanPool.Spawn(bulletPrefab, leftBulletPosition, rotation);
            LeanPool.Spawn(bulletPrefab, rightBulletPosition, rotation);
        }
    }
}