using UnityEngine;

namespace _Project.Scripts.Weapons.WeaponData.GunData
{
    [CreateAssetMenu(menuName = "Create GunData", fileName = "GunData", order = 0)]
    public class GunData : WeaponData
    {
        public string Name;
        public int damage;
        public float fireRate;
        public float range;
        public float reloadTime;
        public int magazineSize;
        public int maxAmmo;
        public enum FireMode
        {
            Single,
            Burst,
            Auto
        }
        public FireMode fireMode;
    }
}
