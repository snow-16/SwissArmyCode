using System;
using System.Linq;

namespace Snow.SwissArmyCode.Processor
{
    public class EnumUtil
    {
        public static T[] ListUp<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        }
    }
}
