using UnityEngine;

namespace Snow.SwissArmyCode.DesignPattern
{
    public abstract class PoolableObject<T> : MonoBehaviour where T : PoolableObject<T>
    {
        protected ObjectPool<T> _pool;
        
        public void OnAppeared(ObjectPool<T> pool)
        {
            _pool = pool;
        }

        void OnDisable()
        {
            _pool.Put((T)this);
        }
    }
}