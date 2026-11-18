using System.Collections.Generic;
using Snow.SwissArmyCode.Processor;
using UnityEngine;

namespace Snow.SwissArmyCode.DesignPattern
{
    public class ObjectPool<T> where T : PoolableObject<T>
    {
        private readonly T _prefab;
        public Queue<T> Pool { get; private set; } = new();

        public ObjectPool(T prefab)
        {
            _prefab = prefab;
        }

        public T Take()
        {
            if(Pool.Count > 0)
            {
                var next = Pool.Dequeue();
                next.gameObject.SetActive(true);
                Debug.Log($"{typeof(T)}用プールから{next.gameObject.name}が引き出されました。");
                return next;
            }
            else
            {
                var next = ObjectGenerator.QuickInstantiate(_prefab);
                next.OnAppeared(this);
                Debug.Log($"{typeof(T)}用プールから{next.gameObject.name}が生成されました。");
                return next;
            }
        }

        public void Put(T obj)
        {
            Debug.Log($"{typeof(T)}用プールへ{obj.gameObject.name}が返還されました。");
            Pool.Enqueue(obj);
        }
    }
}