using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WebCamSetup))]
public class WebCamSetupEditor : Editor
{
   public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WebCamSetup cam = target as WebCamSetup;

        if (GUILayout.Button("Get Devices")) cam.GetDevices();
        if (GUILayout.Button("Play")) cam.Play();
        if (GUILayout.Button("Pause")) cam.Pause();
        if (GUILayout.Button("Stop")) cam.Stop();
        if (GUILayout.Button("Take Photo")) cam.Stop();
    }
}
