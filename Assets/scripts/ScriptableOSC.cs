using UnityEngine;
using extOSC;

[CreateAssetMenu(fileName = "ScriptableOSC", menuName = "Scriptable Objects/ScriptableOSC")]
public class ScriptableOSC : ScriptableObject
{
    public OSCMessage message;
}
