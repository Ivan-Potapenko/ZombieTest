using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game {

    public class FadeController : MonoBehaviour {

        [SerializeField]
        private Image _image;

        [SerializeField]
        private float _fadeTime;

        private bool _isActive;

        public Action onFadeActive;

        public void StartFade() {
            if (_isActive) {
                return;
            }
            StartCoroutine(FadeCoroutine());
        }

        private IEnumerator FadeCoroutine() {
            _isActive = true;
            _image.enabled = true;
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0);
            var halfFadeTime = _fadeTime / 2;
            for (float i = 0; i < halfFadeTime; i += Time.deltaTime) {
                SetImageAlpha(Time.deltaTime / halfFadeTime, 1);
                yield return null;
            }
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1);
            onFadeActive?.Invoke();
            for (float i = 0; i < halfFadeTime; i += Time.deltaTime) {
                SetImageAlpha(Time.deltaTime / halfFadeTime, 0);
                yield return null;
            }
            _image.enabled = false;
            _isActive = false;
            onFadeActive = null;
        }

        private void SetImageAlpha(float step, float targetValue) {
            var alpha = Mathf.Lerp(_image.color.a, targetValue, step);
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, alpha);
        }
    }
}
