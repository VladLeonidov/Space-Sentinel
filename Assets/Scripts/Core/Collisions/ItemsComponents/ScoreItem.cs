using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;

namespace Core.Collisions.ItemsComponents
{
    public class ScoreItem : BaseItem
    {
        [SerializeField]
        private int increasingScore;

        protected override bool UseItem(Collider2D playerCollision)
        {
            ManagerProvider.ScoreManager.Score += this.increasingScore;
            return true;
        }
    }
}