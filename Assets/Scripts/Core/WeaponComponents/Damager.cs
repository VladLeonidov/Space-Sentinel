using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.WeaponComponents
{
    public class Damager : MonoBehaviour
    {
        [SerializeField]
        private int damage;

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                this.damage = value;
                if (this.damage < 1)
                {
                    this.damage = 1;
                }
            }
        }
    }
}