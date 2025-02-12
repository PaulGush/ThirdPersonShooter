using _Project.Scripts.Weapons.WeaponData.GunData;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Weapons
{
    public class Gun : Weapon
    {
        [InlineEditor, SerializeField] private GunData m_gunData;
        
        private Camera m_camera;
        
        private int m_currentAmmoInMagazine;
        private int m_currentAmmoInReserve;
        private GunData.FireMode m_fireMode;
        private float m_fireRate;
        
        private void Awake()
        {
            m_camera = Camera.main;
            Setup();
        }
        
        private void Setup()
        {
            m_currentAmmoInMagazine = m_gunData.magazineSize;
        }

        private void RequestShot()
        {
            if (m_currentAmmoInMagazine == 0) return;
            
            Shoot();
        }

        private void Shoot()
        {
            m_currentAmmoInMagazine--;
            var screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            var ray = m_camera.ScreenPointToRay(screenCenter);
            if (Physics.Raycast(ray, out var hit, 100f))
            {
                
            }
        }
    }
}
