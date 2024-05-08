using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Data {

    public class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject {

        private static bool _hasInstance;
        public static bool HasInstance => _hasInstance;

        private static T _instance;
        public static T Instance {
            get {
                if (!_hasInstance) {
#if UNITY_EDITOR
                    var guid = AssetDatabase.FindAssets($"t:{typeof(T).FullName}").FirstOrDefault();
                    if (guid != null) {
                        var path = AssetDatabase.GUIDToAssetPath(guid);
                        _instance = AssetDatabase.LoadAssetAtPath<T>(path);
                    }
#else
                    _instance = ScriptableObjectSingletonStorage.Instance.GetInstance<T>();
#endif
                    _hasInstance = _instance != null;
                }
                return _instance;
            }
        }
    }
}