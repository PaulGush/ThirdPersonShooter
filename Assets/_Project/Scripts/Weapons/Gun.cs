using System;
using _Project.Scripts.Weapons.WeaponData.GunData;
using Flyweight;
using Sirenix.OdinInspector;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Weapons
{
    public class Gun : Weapon
    {
        [InlineEditor, SerializeField] private GunData m_gunData;
        [SerializeField] private ProjectileSettings m_projectileSettings;
        [SerializeField] private Transform m_shootPoint;
        [SerializeField] private PlayerInput m_playerInput;
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

        private void OnEnable()
        {
            m_playerInput.actions["Primary"].performed += PlayerInput_Primary;
        }

        private void OnDisable()
        {
            m_playerInput.actions["Primary"].performed -= PlayerInput_Primary;
        }

        private void PlayerInput_Primary(InputAction.CallbackContext obj)
        {
            RequestShot();
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

            Debug.Log("Current Ammo in Magazine: " + m_currentAmmoInMagazine);
            var bulletObject = FlyweightFactory.Spawn(m_projectileSettings);
            bulletObject.transform.position = m_shootPoint.position;
            bulletObject.transform.rotation = transform.rotation;
            
            
            /*var screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            var ray = m_camera.ScreenPointToRay(screenCenter);
            if (Physics.Raycast(ray, out var hit, 100f))
            {

            }*/
        }
    }
}
