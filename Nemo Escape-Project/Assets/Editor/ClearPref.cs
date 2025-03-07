using UnityEngine;
using UnityEditor;

public class ClearPlayerPrefsTool : MonoBehaviour
{
    [MenuItem("Tools/Clear PlayerPrefs")]
    public static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs has been cleared!");
    }
}
