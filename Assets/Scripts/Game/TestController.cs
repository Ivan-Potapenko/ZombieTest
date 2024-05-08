using Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YG;

namespace Game {

    public class TestController : MonoBehaviour {

        [SerializeField]
        private QuestionLoader _questionLoader;

        [SerializeField]
        private ResultLoader _resultLoader;

        [SerializeField]
        private TestData _testData;

        private Dictionary<string, int> _resultCounter = new Dictionary<string, int>();

        [SerializeField]
        private FadeController _fadeController;

        private string Language =>  YandexGame.lang;

        private int _currentQuestion = 0;

        public QuestionData[] _questions;

        private void Start() {
            _questionLoader.onAnswerClick += OnAnswerReceived;
            _resultLoader.onRestartButton += Restart;
            ShuffleQuestionData();
            LoadQuestion();
        }

        private void ShuffleQuestionData() {
            var random = new System.Random();
            _questions = _testData.Questions.OrderBy(x => random.Next()).ToArray();
        }

        private void Restart() {
            _currentQuestion = 0;
            _resultCounter.Clear();
            ShuffleQuestionData();
            LoadQuestion();
        }

        private void OnAnswerReceived(ResultDataId resultDataId) {
            if (!_resultCounter.ContainsKey(resultDataId.Value)) {
                _resultCounter.Add(resultDataId.Value, 0);
            }
            _resultCounter[resultDataId.Value]++;
            _currentQuestion++;
            if (_currentQuestion < _questions.Length) {
                _fadeController.onFadeActive += LoadQuestion;
            } else {
                _fadeController.onFadeActive += LoadResult;
            }
            _fadeController.StartFade();
        }

        private void LoadQuestion() {
            _questionLoader.gameObject.SetActive(true);
            _resultLoader.gameObject.SetActive(false);
            _questionLoader.LoadQuestion(_questions[_currentQuestion], Language, _questions.Length, _currentQuestion);
        }

        private void LoadResult() {
            (string, int) currentResult = ("None",0);
            foreach (var result in _resultCounter) {
                if(currentResult.Item2 <= result.Value) {
                    currentResult = (result.Key, result.Value);
                }
            }
            _questionLoader.gameObject.SetActive(false);
            _resultLoader.gameObject.SetActive(true);
            _resultLoader.LoadResult(new ResultDataId(currentResult.Item1), Language);
        }
    }
}

