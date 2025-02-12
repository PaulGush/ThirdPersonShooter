using Unity.VisualScripting;
using UnityEngine;
using UnityUtils;

// ReSharper disable once CheckNamespace
namespace Flyweight
{
    [CreateAssetMenu(menuName = "Flyweight/Projectile Settings")]
    public class ProjectileSettings : FlyweightSettings {
        public float despawnDelay = 5f;
        public float speed = 10f;
        public float damage = 10f;
        
        public override Flyweight Create() {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;
            
            var flyweight = go.GetOrAdd<Projectile>();
            flyweight.settings = this;
            
            return flyweight;
        }
        
        public override void OnRelease(Flyweight f) {
            base.OnRelease(f);
            f.gameObject.transform.Reset();
        }
    }
}