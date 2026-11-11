using UnityEngine;

public class RevealStateMachine : BaseStateMachine
{
    public BaseState initialState;

    void Start()
    {
        ChangeState(initialState);
    }
}
