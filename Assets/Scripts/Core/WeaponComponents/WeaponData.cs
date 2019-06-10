using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.WeaponComponents
{
    [System.Serializable]
    public class WeaponData
    {
        [SerializeField]
        private Attacker[] weapons;

        public Attacker this[int index]
        {
            get
            {
                if (index >= this.weapons.Length)
                {
                    Debug.LogError
                        (
                            string.Format
                            (
                                "Index out of range, index={0}, length={1}", 
                                index, 
                                this.weapons.Length
                            )
                        );
                }

                return this.weapons[index];
            }
        }

        public int Length { get { return this.weapons.Length; } }

        public void SetActiveWeapon(int index, bool active)
        {
            if (this.weapons[index] != null)
            {
                this.weapons[index].gameObject.SetActive(active);
            }
        }
    }
}