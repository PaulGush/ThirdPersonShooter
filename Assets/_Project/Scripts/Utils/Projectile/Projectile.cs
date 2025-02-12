using System.Collections;
using UnityEngine;
using UnityUtils;

// ReSharper disable once CheckNamespace
namespace Flyweight
{
    public class Projectile : Flyweight {
        new ProjectileSettings settings => (ProjectileSettings) base.settings;
        
        void OnEnable() {
            StartCoroutine(DespawnAfterDelay(settings.despawnDelay));
        }
        
        void Update() {
            this.transform.Translate(this.transform.forward * (settings.speed * Time.deltaTime));
        }

        IEnumerator DespawnAfterDelay(float delay) {
            yield return Helpers.GetWaitForSeconds(delay);
            FlyweightFactory.ReturnToPool(this);
        }
    }
}