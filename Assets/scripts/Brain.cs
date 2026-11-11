using UnityEngine;
using extOSC;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public struct Action
{
    public string incomingMessage;
    public UnityEvent pertinentEvent;
}

public class Brain : MonoBehaviour
{
    // public ScriptableOSC maxMSP;
    private OSCReceiver receiver;

    [Header("OSC Receive Settings")]
    public int port;
    public Action[] actions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        receiver = gameObject.AddComponent<OSCReceiver>();
        receiver.LocalPort = port;

        // receiver.Bind("/accelerometer", MessageReceived);
        for (int i = 0; i < actions.Length; i++)
        {
            receiver.Bind(actions[i].incomingMessage, MessageReceived);
        }
        receiver.Connect();
    }

    public void MessageReceived(OSCMessage message)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            string address = actions[i].incomingMessage;
            if (address == message.Address)
            {
                // maxMSP.message = new OSCMessage(message.Address);
                // maxMSP.message.AddRange(message.Values);
                actions[i].pertinentEvent.Invoke();
            }
        }
    }

    // private IEnumerator SendMessages()
    // {
    //     int n = 0;
    //     while (true)
    //     {
    //         for (int i = 0; i < transmitters.Length; i++)
    //         {
    //             OSCMessage message = new OSCMessage(transmitters[i].message);

    //             message.AddValue(OSCValue.String($"{transmitters[i].value}_{n}"));
    //             transmitters[i].transmitter.Send(message);
    //         }

    //         yield return new WaitForSeconds(0.1f);
    //         n += 1;
    //     }
    // }
}
