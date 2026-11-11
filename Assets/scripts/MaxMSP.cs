using UnityEngine;
using extOSC;
using System.Collections;

public class MaxMSP : MonoBehaviour
{
    private OSCTransmitter transmitter;

    [Header("Remote Machine Settings")]
    public string remoteHost;
    public int remotePort;

    private OSCMessage message;

    [Header("Reveal Sound Settings")]
    public string levelMessageName = "/reveal/level";
    public string toggleMessageName = "/reveal/toggle";
    public string rotateMessageName = "/reveal/rotate";
    [Range(0.1f, 3f)] public float fadeUpTime = 0.5f;
    [Range(0.1f, 10f)] public float rotateTime = 2f;
    [Range(0.1f, 10f)] public float lifeTime = 5f;
    [Range(0.1f, 10f)] public float fadeDownTime = 5f;
    [Range(-60f, 0f)] public float maxVolume = -5f;

    [Header("SI Merge Settings")]
    public string siChoiceName = "/si/choice";
    public int numChoices = 7;

    private bool revealRunning = false;
    private bool siRunning = false;

    private Coroutine revealAudio;
    private Coroutine siMergeAudio;

    void Start()
    {
        transmitter = gameObject.AddComponent<OSCTransmitter>();
        transmitter.RemoteHost = remoteHost;
        transmitter.RemotePort = remotePort;
        transmitter.Connect();
    }

    public void OnReveal()
    {
        if (!revealRunning)
        {
            revealRunning = true;
            revealAudio = StartCoroutine(RevealAudio());
        }
    }

    public void OnSIMerge()
    {
        Debug.Log("SI Merge");
        if (!siRunning)
        {
            siRunning = true;
            siMergeAudio = StartCoroutine(SIMerge());
        }
    }

    private IEnumerator RevealAudio()
    {
        float level = -60f;
        OSCMessage levelMessage = new OSCMessage(levelMessageName);
        levelMessage.AddValue(OSCValue.Int(-60));
        transmitter.Send(levelMessage);

        float rotation = -180;
        OSCMessage rotateMessage = new OSCMessage(rotateMessageName);
        rotateMessage.AddValue(OSCValue.Int((int)rotation));
        transmitter.Send(rotateMessage);

        OSCMessage toggleMessage = new OSCMessage(toggleMessageName);
        toggleMessage.AddValue(OSCValue.Int(1));
        transmitter.Send(toggleMessage);

        while (level <= maxVolume - 1f)
        {
            level += Time.deltaTime * 60f/fadeUpTime;
            levelMessage.Values.Clear();
            levelMessage.AddValue(OSCValue.Int((int)level));
            transmitter.Send(levelMessage);
            yield return null;
        }

        while(rotation < -90f)
        {
            rotation += Time.deltaTime * 60f / rotateTime;
            rotateMessage.Values.Clear();
            rotateMessage.AddValue(OSCValue.Int((int)rotation));
            transmitter.Send(rotateMessage);
            yield return null;
        }

        yield return new WaitForSeconds(lifeTime);

        while (level >= -60f)
        {
            level -= Time.deltaTime * 60f/fadeDownTime;
            levelMessage.Values.Clear();
            levelMessage.AddValue(OSCValue.Int((int)level));
            transmitter.Send(levelMessage);
            yield return null;
        }

        toggleMessage.Values.Clear();
        toggleMessage.AddValue(OSCValue.Int(0));
        transmitter.Send(toggleMessage);

        revealRunning = false;
    }

    private IEnumerator SIMerge()
    {
        OSCMessage siMessage = new OSCMessage(siChoiceName);

        int selection = Random.Range(1, numChoices + 1);
        siMessage.AddValue(OSCValue.Int(selection));
        transmitter.Send(siMessage);

        yield return new WaitForSeconds(10f);
        siRunning = false;
    }

    public void StopAllSound()
    {
        if (revealAudio != null)
            StopCoroutine(revealAudio);
        if (siMergeAudio != null)
            StopCoroutine(siMergeAudio);

        // Stop reveal
        OSCMessage levelMessage = new OSCMessage(levelMessageName);
        levelMessage.AddValue(OSCValue.Int(-60));
        transmitter.Send(levelMessage);

        OSCMessage toggleMessage = new OSCMessage(toggleMessageName);
        toggleMessage.AddValue(OSCValue.Int(0));
        transmitter.Send(toggleMessage);
        revealRunning = false;

        OSCMessage siMessage = new OSCMessage(siChoiceName);
        siMessage.AddValue(OSCValue.Int(0));
        transmitter.Send(siMessage);
        siRunning = false;
    }

}
