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

        public T NextSimple()
        {
            return Next().Prize;
        }

        public ProbSet<T> Next()
        {
            if(_probTable.Count == 0)
            {
                Debug.LogError($"{typeof(T)}のガチャの確率テーブルは空です。");
                return default;
            }

            var underBorder = 0f;
            var denom = _probTable.Sum(p => p.Prob);
            var r = UnityEngine.Random.Range(0, denom);

            foreach(var p in _probTable)
            {
                if(r >= underBorder && r < underBorder + p.Prob)
                {
                    return p;
                }

                underBorder += p.Prob;
            }

            return _probTable.Last();
        }

        public T[] NextNoDuplicates(int count)
        {
            if(_probTable.Count < count)
            {
                Debug.LogError($"{typeof(T)}のガチャの要素数より多い抽選回数が指定されています。");
                return null;
            }

            var arr = new T[count];
            var copyTable = new List<ProbSet<T>>(_probTable);

            for(int i = 0; i < count; i++)
            {
                var newPrize = Next();
                arr[i] = newPrize.Prize;
                _probTable.Remove(newPrize);
            }

            _probTable = copyTable;
            return arr;
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
