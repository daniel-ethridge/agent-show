using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MaxMSP))]
public class MaxMSPEditor : Editor
{
   public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MaxMSP max = target as MaxMSP;

        if (GUILayout.Button("Reveal Sound")) max.OnReveal();
        if (GUILayout.Button("SI Merge Sound")) max.OnSIMerge();
        if (GUILayout.Button("Stop Reveal Sound")) max.StopAllSound();
    }
}
