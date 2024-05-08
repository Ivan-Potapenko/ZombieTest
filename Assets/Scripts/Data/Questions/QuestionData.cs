using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "QuestionData", menuName = "Test/QuestionData")]
    public class QuestionData : ScriptableObject {

        [Serializable]
        public class AnswerData {

            [SerializeField]
            private ResultDataId _resultDataId;
            public ResultDataId ResultDataId => _resultDataId;

            [SerializeField]
            private LocalizedText _localizedText;
            public LocalizedText LocalizedText => _localizedText;
        }

        [SerializeField]
        private LocalizedText _questionText;
        public LocalizedText QuestionText => _questionText;

        [SerializeField]
        private AnswerData[] _answersData = new AnswerData[4];
        public AnswerData[] AnswersData => _answersData;

#if UNITY_EDITOR
        public void Translate() {
            _questionText.Translate();
            foreach (var answer in _answersData) {
                answer.LocalizedText.Translate();
            }
            EditorUtility.SetDirty(this);
        }
#endif
    }
}