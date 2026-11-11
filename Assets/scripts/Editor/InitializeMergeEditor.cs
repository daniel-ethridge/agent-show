using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InitializeMerge))]
public class InitializeMergeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        InitializeMerge merge = target as InitializeMerge;
        if (GUILayout.Button("From the Top")) merge.Initialize();

    }
}
