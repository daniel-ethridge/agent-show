using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Resolume))]
public class ResolumeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Resolume resolume = target as Resolume;

        if (GUILayout.Button("Send Message"))
        {
            resolume.SendCommand();
        }
    }
}