using UnityEngine;
using extOSC;

public class Resolume : MonoBehaviour
{
    public Brain brain;
    [Range(0f, 1f)] public float valueToChange;

    public void SendCommand()
    {
        // OSCTransmitter transmitter = brain.transmitters[0].transmitter;
        // OSCMessage message = new OSCMessage("/agent/hear");

        // message.AddValue(OSCValue.String("Draw a picture of the beach and the sky."));
        // transmitter.Send(message);
    }
}
