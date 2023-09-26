using UnityEngine;
using UnityEngine.Pool;

namespace Utilities
{
    public class Pool<T> where T : MonoBehaviour
    {
        private readonly Transform parent;

        private readonly IObjectPool<T> pools;

        public Pool(Transform parent, T prefab)
        {
            this.parent = parent;

            pools = CreatePool(prefab);
        }

        public T Get() => pools.Get();

        public void Release(T item)
        {
            pools.Release(item);
        }

        private IObjectPool<T> CreatePool(T prefab)
        {
            var pool = new ObjectPool<T>(onCreate, onGet, onRelease, onDestroy);

            return pool;

            T onCreate() => Object.Instantiate(prefab, parent);

            void onGet(T item)
            {
                item.gameObject.SetActive(true);
            }

            void onRelease(T item)
            {
                item.gameObject.SetActive(false);
            }

            void onDestroy(T item)
            {
                Object.Destroy(item.gameObject);
            }
        }
    }
}
