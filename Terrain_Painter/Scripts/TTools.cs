using UnityEditor;
using UnityEngine;

public class TTools : ScriptableObject
{
    [MenuItem("Tools/TTools")]
    static void Init()
    {
        if (GameObject.FindObjectOfType<TToolsScript>() != null)
            return;

        GameObject manager = new GameObject();
        manager.name = "TToolsManager";
        TToolsScript tools = manager.AddComponent<TToolsScript>();
    }
}
