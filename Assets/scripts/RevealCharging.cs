using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class RevealCharging : BaseState
{
    public BoolVariable keyInLock;
    private RevealStateMachine ai;

    public float timeToInitialIndication;
    public float timeToFullyCharged;

    public BaseState onChargingFailed;
    public BaseState onChargingSuccess;

    private void OnChargingFailed() => ai.ChangeState(onChargingFailed);
    private void OnChargingSuccess() => ai.ChangeState(onChargingSuccess);
    
    public UnityEvent onInitialIndication;
    public UnityEvent chargingFailed;

    private Coroutine charge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ai = gameObject.GetComponent<RevealStateMachine>();
    }

    public override void OnEnter()
    {
        charge = StartCoroutine(Charge());
    }

    public override void OnUpdate()
    {
        if (!keyInLock)
        {
            OnChargingFailed();
        }
    }

    public override void OnExit()
    {
        StopCoroutine(charge);
    }

    private IEnumerator Charge()
    {
        yield return new WaitForSeconds(timeToInitialIndication);
        onInitialIndication.Invoke();

        float remainingTime = timeToFullyCharged - timeToInitialIndication;
        if (remainingTime < 0)
            OnChargingSuccess();

        yield return new WaitForSeconds(remainingTime);
        OnChargingSuccess();
    }
}
