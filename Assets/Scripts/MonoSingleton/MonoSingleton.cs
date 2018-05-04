/*  Description: Allows attachement to a MonoBehaviour for easy access as a Singleton
 *  Brogrammer: Vastlee
 */

using UnityEngine;

/// <summary>
/// Extend with Class Name to automatically create a Singleton
/// </summary>
/// <typeparam name="T"></typeparam>
public class MonoSingleton<T> : MonoBehaviour where T : Component {
    private static T instance = null;
    private static bool isQuitting = false;
    public static T Instance {
        get {
            if(instance == null && !isQuitting) {
                FindOrCreateInstance();
            }
            return instance;
        }
    }


    /// <summary>
    /// Looks for an existing instance, if not found creates one. If multiple are found, reports error.
    /// </summary>
    static private void FindOrCreateInstance() {
        Application.quitting += SetIsQuittingTrue;
        T[] instanceArray = FindObjectsOfType<T>();
        if(instanceArray.Length == 0) {
            GameObject singleton = new GameObject(string.Empty);
            instance = singleton.AddComponent<T>();
            DontDestroyOnLoad(singleton);
        } else if(instanceArray.Length == 1) {
            instance = instanceArray[0];
            DontDestroyOnLoad(instance);
        } else if(instanceArray.Length > 1) {
            Debug.LogError("<color=yellow>Multiple instances of a singleton exists.</color>");
            Debug.Break();
        }
    }

    /// <summary>
    /// Toggles the isQuitting in case something attempts to access the Singleton while it's exiting.
    /// </summary>
    static void SetIsQuittingTrue() {
        isQuitting = true;
    }
}
