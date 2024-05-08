using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game {

    public class InfoWindow : MonoBehaviour {

        [SerializeField]
        private Button _closeButton;

        private void Awake() {
            _closeButton.onClick.AddListener(Close);
        }

        public void Close() {
            gameObject.SetActive(false);
        }

        public void Open() {
            gameObject.SetActive(true);
        }
    }
}