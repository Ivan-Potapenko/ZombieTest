using Data;
using UnityEditor;
using UnityEngine;

namespace Utils {

    [CustomEditor(typeof(QuestionData)), CanEditMultipleObjects]
    public class QuestionDataEditor : Editor {

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            var questionData = target as QuestionData;
            if (GUILayout.Button("Translate")) {
                questionData.Translate();
            }
        }
    }
}

