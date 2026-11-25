using UnityEngine;

namespace Snow.SwissArmyCode.Processor
{
    public class ObjectGenerator : MonoBehaviour
    {
        public static T QuickInstantiate<T>(T obj) where T : Object
        {
            return Instantiate(obj);
        }

        public static T QuickInstantiate<T>(T obj, Vector3 pos) where T : Object
        {
            return Instantiate(obj, pos, Quaternion.identity);
        }

        public static T QuickInstantiate<T>(T obj, Vector3 pos,  Vector3 rot) where T : Object
        {
            return Instantiate(obj, pos, Quaternion.Euler(rot));
        }

        public static T QuickInstantiate<T>(T obj, Transform parent) where T : Object
        {
            return Instantiate(obj, parent.position, parent.rotation);
        }

        public static T QuickInstantiateChild<T>(T obj, Transform parent) where T : Object
        {
            return Instantiate(obj, parent.position, parent.rotation, parent);
        }
    }
}
