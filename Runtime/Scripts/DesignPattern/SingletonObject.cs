using UnityEngine;

namespace Snow.SwissArmyCode.DesignPattern
{
    public abstract class SingletonObject<T> : MonoBehaviour where T : SingletonObject<T>
    {
        private static T _instance;
        public static T Instance => _instance;

        void Start()
        {
            if (_instance)
            {
                Debug.Log($"{typeof(T)}のシングルトンインスタンス{gameObject.name}は競合により破棄されました。");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log($"{typeof(T)}のシングルトンインスタンス{gameObject.name}が生成されました。");
                _instance = (T)this;
                DontDestroyOnLoad(gameObject);
                OnStarted();
            }
        }

        protected abstract void OnStarted();
    }
}
