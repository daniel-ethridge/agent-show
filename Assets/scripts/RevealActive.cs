using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class RevealActive : BaseState
{
    public BoolVariable keyInLock;
    private RevealStateMachine ai;
    public float minTimeInState;
    private bool canLeaveState = false;

    public BaseState startState;
    private void OnReturnToStartState() => ai.ChangeState(startState);
    public UnityEvent onRevealTraining;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ai = gameObject.GetComponent<RevealStateMachine>();
    }

    public override void OnEnter()
    {
        onRevealTraining.Invoke();
        canLeaveState = false;
        StartCoroutine(CanLeaveState());
    }

    public override void OnUpdate()
    {
        if (!canLeaveState)
            return;

        if (!keyInLock.Value)
            OnReturnToStartState();
    }
    public override void OnExit() {}

    private IEnumerator CanLeaveState()
    {
        yield return new WaitForSeconds(minTimeInState);
        canLeaveState = true;
    }
}
