using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.WeaponComponents
{
    public enum WeaponType
    {
        Ion, Laser, Plasma, Enemy
    }

    public class WeaponController : MonoBehaviour
    {
        [SerializeField]
        private WeaponData weaponsConteiner;

        private Attacker _currentAttacker;

        private int _weaponMod = 0;
        private int _maxWeaponMod = 2;
        private float _offsetBulletsSpawn = 8f;
        private float _angleBulletsSpawn = 15f;

        public Attacker this[int index]
        {
            get { return this.weaponsConteiner[index]; }
        }

        public int WeaponsLength { get { return this.weaponsConteiner.Length; } }

        public Attacker CurrentAttacker { get; set; }

        public bool IsLastWeaponMod { get { return _weaponMod == _maxWeaponMod; } }

        public WeaponType CurrentWeaponType { get; set; }

        private IWeaponState WeaponState { get; set; }

        private void Awake()
        {
            if (this.gameObject.tag == "Enemy")
            {
                SetState(WeaponType.Enemy);
            }
            else
            {
                SetState(WeaponType.Laser);
            }
        }

        public void SetState(WeaponType stateType)
        {
            switch (stateType)
            {
                case WeaponType.Ion:
                    IonState();
                    break;
                case WeaponType.Laser:
                    LaserState();
                    break;
                case WeaponType.Plasma:
                    PlasmaState();
                    break;
                case WeaponType.Enemy:
                    EnemyState();
                    break;
            }
        }

        public void SetState(IWeaponState state)
        {
            WeaponState = state;
            WeaponState.ChangeState(this);
        }

        private void IonState()
        {
            WeaponState = new IonState();
            WeaponState.ChangeState(this);
            CurrentWeaponType = WeaponType.Ion;
        }

        private void LaserState()
        {
            WeaponState = new LaserState();
            WeaponState.ChangeState(this);
            CurrentWeaponType = WeaponType.Laser;
        }

        private void PlasmaState()
        {
            WeaponState = new PlasmaState();
            WeaponState.ChangeState(this);
            CurrentWeaponType = WeaponType.Plasma;
        }

        private void EnemyState()
        {
            WeaponState = new EnemyState();
            WeaponState.ChangeState(this);
            CurrentWeaponType = WeaponType.Enemy;
        }

        public void ChangeWeaponMod()
        {
            _weaponMod++;
            if (_weaponMod > 2)
            {
                _weaponMod = 2;
            }

            switch (_weaponMod)
            {
                case 1:
                    CurrentAttacker.BulletsSpawnStratagy =
                        new DoubleSpawnBulletsStratagy(_offsetBulletsSpawn);
                    break;
                case 2:
                    CurrentAttacker.BulletsSpawnStratagy =
                        new TripleBulletsSpawnStratagy(_offsetBulletsSpawn, _angleBulletsSpawn);
                    break;
                default:
                    SetDefaultWeaponBulletsSpawnStratagy();
                    break;
            }
        }

        public void SetDefaultWeaponBulletsSpawnStratagy()
        {
            CurrentAttacker.BulletsSpawnStratagy = new SingleBulletsSpawnStratagy();
            _weaponMod = 0;
        }
    }
}