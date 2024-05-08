#if YG_NEWTONSOFT_FOR_AUTOLOCALIZATION
using System;
using System.Linq;
using System.Net;
#endif
using UnityEngine;
#if YG_NEWTONSOFT_FOR_AUTOLOCALIZATION
using UnityEngine.Networking;
#endif

namespace Utils {

    public static class AutoTranslator {

        public static string TranslateGoogle(string text, string translationTo = "en") {
#if YG_NEWTONSOFT_FOR_AUTOLOCALIZATION
            var url = String.Format("https://translate.google." + "us" + "/translate_a/single?client=gtx&dt=t&sl={0}&tl={1}&q={2}",
                "auto", translationTo, WebUtility.UrlEncode(text));
            UnityWebRequest www = UnityWebRequest.Get(url);
            www.SendWebRequest();
            while (!www.isDone) {

            }
            string response = www.downloadHandler.text;
            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<object[][][]>(response, new Newtonsoft.Json.JsonSerializerSettings {
                Error = (_, e) => { e.ErrorContext.Handled = true; }
            });

            try {
                response = string.Join("", json[0].SelectMany(x => x.Skip(0)?.Take(1)).Cast<string>()).Replace("\\n", "\n").Replace("\n ", "\n");
            } catch {
                Debug.LogError("The process is not completed! Most likely, you made too many requests. In this case, the Google Translate API blocks access to the translation for a while.  Please try again later. Do not translate the text too often, so that Google does not consider your actions as spam");
            }
            return response;
#else
            Debug.LogError("Missing library 'Newtonsoft.Json.Linq'. You need to import it. You need to import 'Newtonsoft Json' for auto-localization.");
            return null;
#endif
        }
    }
}

