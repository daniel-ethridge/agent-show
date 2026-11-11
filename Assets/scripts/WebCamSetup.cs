using UnityEngine;
using UnityEngine.UI;
using System;

public class WebCamSetup : MonoBehaviour
{
    WebCamTexture webCamTexture;
    public int deviceNumber;
    RawImage img;

    Color[] texturePixelArray;
    public string outString {get; private set;}

    public void Play()
    {
        WebCamDevice device = WebCamTexture.devices[deviceNumber];
        webCamTexture = new WebCamTexture(device.name);
        img = gameObject.GetComponent<RawImage>();
        img.texture = webCamTexture;
        webCamTexture.Play();
    }

    public void Pause() => webCamTexture.Pause();
    public void Stop() => webCamTexture.Stop();

    public void GetDevices()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log($"Device {i}: {devices[i].name}");
        }
    }

    public void GetPhotoImage()
    {
        Pause();

        Texture2D tex = img.texture as Texture2D;
        byte[] textureData = ImageConversion.EncodeToPNG(tex);
        outString = Convert.ToBase64String(textureData);
    }
}
