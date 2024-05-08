#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;


namespace Data {

    [CreateAssetMenu(fileName = "TestData", menuName = "Test/TestData")]
    public class TestData : ScriptableObject {

        [SerializeField]
        private QuestionData[] _questions;
        public QuestionData[] Questions => _questions;

#if UNITY_EDITOR
        public void Translate() {
            foreach (var question in _questions) {
                question.Translate();
                EditorUtility.SetDirty(question);
            }
        }
#endif
    }
}