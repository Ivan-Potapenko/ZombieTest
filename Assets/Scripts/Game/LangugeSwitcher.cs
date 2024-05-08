using Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LangugeSwitcher : MonoBehaviour
{
    private int _currentLangugeIndex = 0;
    private string[] _languges;

    public Text textLanguge;

    private void Start() {
        _currentLangugeIndex = 0;
        _languges = Enum.GetNames(typeof(Languages));
        textLanguge.text = _languges[0];
    }

    public void SwitchLanguge() {
        YandexGame.Instance._SwitchLanguage(_languges[_currentLangugeIndex]);
        textLanguge.text = _languges[_currentLangugeIndex];
        _currentLangugeIndex++;
        if(_currentLangugeIndex >= _languges.Length) {
            _currentLangugeIndex = 0;
        }
    }
}
