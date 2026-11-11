using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Collections;

public class TakePhoto : MonoBehaviour
{
    public TMP_Text countdownLeft;
    public TMP_Text countdownRight;

    public UnityEvent countdownFinished;

    public void StartCountdown()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        int count = 5;

        while (count >= 0)
        {
            countdownLeft.text = count.ToString();
            countdownRight.text = count.ToString();

            yield return new WaitForSeconds(1f);
            count -= 1;
        }

        countdownFinished.Invoke();

    }

}
