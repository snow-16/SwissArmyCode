using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Snow.SwissArmyCode.State
{
    public class BitFlag<T> where T : Enum
    {
        private int _flag = 0;
        public T Flag => Int2Flag(_flag);

        public BitFlag()
        {
            if((int)Enum.GetValues(typeof(T)).GetValue(0) == 0)
            {
                Debug.LogError($"{typeof(T)}は重複なしの単ビット構成ではありません。");
            }
        }

        public void Set(T flag)
        {
            _flag |= Flag2Int(flag);
        }

        public void UnSet(T flag)
        {
            _flag &= ~Flag2Int(flag);
        }

        public bool Has(T flag)
        {
            var iFlag = Flag2Int(flag);
            return (_flag & iFlag) == iFlag;
        }

        private static int Flag2Int(T flag)
        {
            return Unsafe.As<T, int>(ref flag);
        }

        private static T Int2Flag(int value)
        {
            return Unsafe.As<int, T>(ref value);
        }
    }
}
