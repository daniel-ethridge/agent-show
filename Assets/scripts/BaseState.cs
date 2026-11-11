using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}
