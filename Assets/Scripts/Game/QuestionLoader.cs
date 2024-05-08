using Data;
using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game {

    public class QuestionLoader : MonoBehaviour {

        private class AnswerButton {

            private Button _button;
            private TextMeshProUGUI _text;
            private ResultDataId _resultDataId;
            private Action<ResultDataId> _clickCallback;

            public AnswerButton(Button button, Action<ResultDataId> clickCallback) {
                _button = button;
                _text = _button.GetComponentInChildren<TextMeshProUGUI>();
                _button.onClick.AddListener(OnButtonClicked);
                _clickCallback = clickCallback;
            }

            public void SetData(QuestionData.AnswerData answerData, string language) {
                _resultDataId = answerData.ResultDataId;
                _text.text = answerData.LocalizedText.GetText(language);
            }

            private void OnButtonClicked() {
                _clickCallback?.Invoke(_resultDataId);
            }
        }

        [SerializeField]
        private Button[] _buttons;

        [SerializeField]
        private TextMeshProUGUI _questionsCountText;

        [SerializeField]
        private TextMeshProUGUI _questionText;

        [SerializeField]
        private Image _questionImage;

        private AnswerButton[] _answers;
        private AnswerButton[] Answers {
            get {
                if (_answers == null) {
                    _answers = _buttons.Select(button => new AnswerButton(button, onAnswerClick)).ToArray();
                }
                return _answers;
            }
        }

        public Action<ResultDataId> onAnswerClick;


        public void LoadQuestion(QuestionData questionData, string language, int questionsCount, int questionNumber) {
            _questionsCountText.text = $"{questionsCount}/{questionNumber}";
            _questionText.text = questionData.QuestionText.GetText(language);
            var random = new System.Random();
            var answers = questionData.AnswersData.OrderBy(x => random.Next()).ToArray();
            for (int i = 0; i < answers.Length; i++) {
                if (Answers.Length <= i) {
                    break;
                }
                Answers[i].SetData(answers[i], language);
            }
        }
    }
}