using Data;
using UnityEditor;
using UnityEngine;

namespace Utils {

    [CustomEditor(typeof(TestData)), CanEditMultipleObjects]
    public class TestDataEditor : Editor {

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            var questionData = target as TestData;
            if (GUILayout.Button("Translate")) {
                questionData.Translate();
            }
        }
    }
}
