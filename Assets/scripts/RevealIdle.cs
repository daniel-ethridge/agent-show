using UnityEngine;

public class RevealIdle : BaseState
{
    public BoolVariable keyInLock;
    private RevealStateMachine ai;

    public BaseState onKeyInLock;
    private void OnKeyInLock() => ai.ChangeState(onKeyInLock);

    void Start()
    {
        ai = gameObject.GetComponent<RevealStateMachine>();
    }

    public override void OnEnter() {}

    public override void OnUpdate()
    {
        if (keyInLock.Value)
            OnKeyInLock();
    }

    public override void OnExit() {}
}
