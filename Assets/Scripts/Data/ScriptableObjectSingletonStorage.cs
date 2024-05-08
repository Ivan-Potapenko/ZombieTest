using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectSingletonStorage : MonoBehaviour
{
    private static ScriptableObjectSingletonStorage _instance;
    public static ScriptableObjectSingletonStorage Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<ScriptableObjectSingletonStorage>();
                if (_instance != null) {
                    DontDestroyOnLoad(_instance);
                }
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<ScriptableObject> _singletons;

    private void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(_instance);
        } else if (_instance != this) {
            _instance._singletons.AddRange(_singletons);
            Destroy(this);
        }
    }

    public T GetInstance<T>() where T : ScriptableObject {
        for (int i = 0; i < _singletons.Count; i++) {
            if (_singletons[i] is T) {
                return _singletons[i] as T;
            }
        }
        Debug.LogErrorFormat("Singleton {0} is not in storage!", typeof(T).ToString());
        return null;
    }
}
