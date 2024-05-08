using System;
using UnityEngine;

namespace Data {

    [Serializable]
    public class ResultDataId {

        [SerializeField]
        private string _value;
        public string Value => _value;

        public ResultDataId(string value = "None") {
            _value = value;
        }

        public ResultData GetData() {
            return ResultDataCollection.Instance.GetResultData(_value);
        }
    }
}

