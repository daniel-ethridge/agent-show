using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LeaveCube))]
public class LeaveCubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LeaveCube leaveCube = target as LeaveCube;

        if (GUILayout.Button("Make Bound Cube"))
        {
            leaveCube.GenerateCube();
        }
    }
}