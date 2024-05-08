using UnityEngine;
using UnityEngine.UI;

namespace Game {

    public class SettingsController : MonoBehaviour {

        [SerializeField]
        private Button _showInfoButton;

        [SerializeField]
        private Button _soundButton;
        
        [SerializeField]
        private Image _soundImage;

        [SerializeField]
        private float _disableSoundImageAlpha;

        [SerializeField]
        private AudioSource _soundSource;

        [SerializeField]
        private InfoWindow _infoWindow;

        private bool _soundEnabled = true;

        private void OnEnable() {
            _showInfoButton.onClick.AddListener(ActivateInfoWindow);
            _soundButton.onClick.AddListener(SwitchSound);
        }

        private void OnDisable() {
            _showInfoButton.onClick.RemoveAllListeners();
            _soundButton.onClick.RemoveAllListeners();
        }

        private void ActivateInfoWindow() {
            _infoWindow.Open();
        }

        private void SwitchSound() {
            _soundEnabled = !_soundEnabled;
            _soundSource.mute = !_soundEnabled;
            _soundImage.color = new Color(_soundImage.color.r, _soundImage.color.g, _soundImage.color.b, _soundEnabled ? 1 : _disableSoundImageAlpha);
        }
    }
}