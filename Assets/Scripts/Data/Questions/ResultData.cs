using UnityEngine;

namespace Data {

    [CreateAssetMenu(fileName = "ResultData", menuName = "Test/ResultData")]
    public class ResultData : ScriptableObject {

        [SerializeField]
        private string _id;
        public string Id => _id;

        [SerializeField]
        private Sprite _background;
        public Sprite Background => _background;

        [SerializeField]
        private LocalizedText _title;
        public LocalizedText Title => _title;

        [SerializeField]
        private LocalizedText _description;
        public LocalizedText Description => _description;

        public void Translate() {
            _title.Translate();
            _description.Translate(); 
        }
    }
}