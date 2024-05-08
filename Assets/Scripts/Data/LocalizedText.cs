using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using Utils;

namespace Data {

    public enum Languages {
        ru,
        en,
        tr,
        az,
        be,
        he,
        hy,
        ka,
        et,
        fr,
        kk,
        ky,
        lt,
        lv,
        ro,
        tg,
        tk,
        uk,
        uz,
        es,
        pt,
        ar,
        id,
        ja,
        it,
        de,
        hi,
    }

    [Serializable]
    public class LocalizedText {

        [Serializable]
        public class LanguageText {
            public Languages language;
            public string text;
        }

        [SerializeField]
        public string _defaultText;

        [SerializeField]
        private List<LanguageText> _languages = new List<LanguageText>();

        public LocalizedText() {
            var languagesFromEnum = (Languages[])Enum.GetValues(typeof(Languages));
            foreach (var language in languagesFromEnum) {
                _languages.Add(new LanguageText { language = language, text = "" });
            }
        }

        public string GetText(Languages language) {
            var text = _languages.FirstOrDefault(text => text.language == language);
            if (text == null) {
                return _defaultText;
            }
            return text.text;
        }

        public string GetText(string language) {
            var text = _languages.FirstOrDefault(text => text.language.ToString() == language);
            if (text == null) {
                return _defaultText;
            }
            return text.text;
        }

        public void Translate() {
            if (_defaultText == GetText(Languages.ru)) {
                return;
            }
            foreach (var language in _languages) {
                language.text = AutoTranslator.TranslateGoogle(_defaultText, language.language.ToString());
            }
        }
    }

}