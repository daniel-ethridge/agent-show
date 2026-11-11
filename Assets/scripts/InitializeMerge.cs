using UnityEngine;

public class InitializeMerge : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent initialize;

    public void Initialize() => initialize.Invoke();
}
