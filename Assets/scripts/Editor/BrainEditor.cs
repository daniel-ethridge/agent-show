using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Brain))]
public class BrainEditor : Editor
{
   public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Brain brain = target as Brain;

        for (int i = 0; i < brain.actions.Length; i++)
        {
            if (GUILayout.Button($"Test action {i+1}"))
            {
                brain.actions[i].pertinentEvent.Invoke();
            }
        }
    }
}
