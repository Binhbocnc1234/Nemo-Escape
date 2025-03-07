using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("Singleton")]
    private static T _instance;

    public static T Instance
    {
        get
        {
            // if (_instance == null){
            //     Debug.LogError("You haven't created a Singleton of " + typeof(T).Name);
            //     return null;
            // }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null){
            _instance = this as T;
        }
        else{
            Debug.LogError("Detect multiple singleton: " + typeof(T).Name);
            Destroy(gameObject); // Prevent duplicates
        }
    }
}
