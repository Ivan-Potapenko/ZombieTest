using Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game {

    public class ResultLoader : MonoBehaviour {

        [SerializeField]
        private Image _image;

        [SerializeField]
        private TextMeshProUGUI _descriptionText;

        [SerializeField]
        private TextMeshProUGUI _titleText;

        [SerializeField]
        private Button _restartButton;

        public UnityAction onRestartButton;

        private void OnEnable() {
            _restartButton.onClick.AddListener(onRestartButton);
        }

        private void OnDisable() {
            _restartButton.onClick.RemoveAllListeners();
        }

        public void LoadResult(ResultDataId resultDataId, string language) {
            var resultData = resultDataId.GetData();
            _descriptionText.text = resultData.Description.GetText(language);
            _titleText.text = resultData.Title.GetText(language);
            _image.sprite = resultData.Background;
        }
    }
}
