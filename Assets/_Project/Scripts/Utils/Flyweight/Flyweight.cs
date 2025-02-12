using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Flyweight {
    // ABSTRACT
    public abstract class Flyweight : MonoBehaviour {
        public FlyweightSettings settings; // Intrinsic state
    }
    
    public abstract class FlyweightSettings : ScriptableObject {
        public FlyweightType type;
        public GameObject prefab;

        public abstract Flyweight Create();
        
        public virtual void OnGet(Flyweight f) => f.gameObject.SetActive(true);
        public virtual void OnRelease(Flyweight f) => f.gameObject.SetActive(false);
        public virtual void OnDestroyPoolObject(Flyweight f) => Destroy(f.gameObject);
    }

    public enum FlyweightType { Bullet, Ice }

}