using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : Component {
	private static T instance = null;
    private static bool isQuitting = false;
	public static T Instance {
		get {
			if(instance == null && !isQuitting)
                FindOrCreateInstance();
			return instance;
		}
	}

    static private void FindOrCreateInstance() {
        T[] instanceArray = FindObjectsOfType<T>();
        if(instanceArray.Length == 0) {
            GameObject singleton = new GameObject(string.Empty);
            instance = singleton.AddComponent<T>();
            DontDestroyOnLoad(singleton);
        } else if(instanceArray.Length == 1) {
            instance = instanceArray[0];
            DontDestroyOnLoad(instance);
        } else if(instanceArray.Length > 1) {
            Debug.LogError("Multiple instances of a singleton exists.");
            Debug.Break();
        }
    }

    private void OnApplicationQuit() {
        isQuitting = true;
    }
}