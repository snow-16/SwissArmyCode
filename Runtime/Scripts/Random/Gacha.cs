using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snow.SwissArmyCode.Random
{
    [Serializable]
    public class Gacha<T>
    {
        [SerializeField]
        private List<ProbSet<T>> _probTable = new();

        public T Next()
        {
            if(_probTable.Count == 0)
            {
                Debug.LogError($"{typeof(T)}のガチャに確率テーブルは空です。");
                return default;
            }

            var underBorder = 0f;
            var denom = _probTable.Sum(p => p.Prob);
            var r = UnityEngine.Random.Range(0, denom);

            foreach(var p in _probTable)
            {
                if(r >= underBorder && r < underBorder + p.Prob)
                {
                    return p.Prize;
                }

                underBorder += p.Prob;
            }

            return _probTable.Last().Prize;
        }
    }

    [Serializable]
    public struct ProbSet<T>
    {
        [SerializeField]
        private float _prob;
        public float Prob => _prob;

        [SerializeField]
        private T _prize;
        public T Prize => _prize;
    }
}
