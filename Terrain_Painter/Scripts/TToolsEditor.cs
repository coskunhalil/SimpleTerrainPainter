using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TToolsScript))]
public class TToolsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("The layers required for the terrain can be changed if you want.", MessageType.Info);
        EditorGUILayout.HelpBox("The variables for the terrain texturing you can changes.", MessageType.Info);

        TToolsScript tools = (TToolsScript)target;

        if (GUILayout.Button("Set Options"))
        {
            tools.Option();
        }

        EditorGUILayout.HelpBox("Set Terrain Options", MessageType.Warning);

        if (GUILayout.Button("Texture!!!"))
        {
            tools.TTexturing();
        }

        EditorGUILayout.HelpBox("Texturing!!!", MessageType.Info);
    }
}
