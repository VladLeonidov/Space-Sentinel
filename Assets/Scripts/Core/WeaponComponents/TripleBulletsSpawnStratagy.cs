using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

namespace Core.WeaponComponents
{
    public class TripleBulletsSpawnStratagy : IBulletsSpawnStratagy
    {
        private float _offset;
        private float _angle;

        public TripleBulletsSpawnStratagy(float offset, float angle)
        {
            _offset = offset;
            _angle = angle;
        }

        public void SpawnBullets(GameObject bulletPrefab, Vector2 position, Quaternion rotation)
        {
            Vector2 leftBulletPosition = new Vector2(position.x - _offset, position.y);
            Vector2 middleBulletPosition = new Vector2(position.x, position.y);
            Vector2 rightBulletPosition = new Vector2(position.x + _offset, position.y);

            LeanPool.Spawn(bulletPrefab, leftBulletPosition, rotation);
            LeanPool.Spawn(bulletPrefab, middleBulletPosition, rotation);
            LeanPool.Spawn(bulletPrefab, rightBulletPosition, rotation);
        }
    }
}