using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using Core.Collisions.ItemsComponents;

namespace Core
{
    public class ItemsDroper : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] dropItems;

        public void DropRandomItem(Vector2 position, Quaternion rotation)
        {
            int randomIndexItem = Random.Range(0, this.dropItems.Length);
            BaseItem item = this.dropItems[randomIndexItem].GetComponent<BaseItem>();

            if (Random.Range(1, 101) <= item.DropShance)
            {
                LeanPool.Spawn(this.dropItems[randomIndexItem], position, rotation);
            }
        }
    }
}