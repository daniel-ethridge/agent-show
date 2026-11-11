using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TakePhoto))]
public class TakePhotoEditor : Editor
{
   public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TakePhoto take = target as TakePhoto;

        if (GUILayout.Button("Trigger Countdown")) take.StartCountdown();
    }
}
