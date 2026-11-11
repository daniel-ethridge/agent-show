using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    private BaseState currentState;

    void Update()
    {
        currentState?.OnUpdate();
    }

    public void ChangeState(BaseState newState)
    {
        currentState?.OnExit();
        currentState = newState;
        currentState.OnEnter();
    }
}
