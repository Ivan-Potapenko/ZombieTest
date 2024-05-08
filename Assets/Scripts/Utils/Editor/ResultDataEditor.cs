using Data;
using UnityEditor;
using UnityEngine;

namespace Utils {

    [CustomEditor(typeof(ResultData)), CanEditMultipleObjects]
    public class ResultDataEditor : Editor {

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            var resultData = target as ResultData;
            if (GUILayout.Button("Translate")) {
                resultData.Translate();
            }
        }
    }
}
