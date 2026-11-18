using UnityEngine;

namespace Snow.SwissArmyCode.Processor
{
    public class ObjectGenerator : MonoBehaviour
    {
        public static T QuickInstantiate<T>(T obj) where T : Object
        {
            return Instantiate(obj);
        }
    }
}
