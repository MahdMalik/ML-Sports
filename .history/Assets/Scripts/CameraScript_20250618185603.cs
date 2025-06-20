using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public WebCamTexture webcam;
    bool hasWebcam;

    // Start is called before the first frame update
    void Start()
    {
        //first, let's make sure there's actually devices to even loop through
        if (WebCamTexture.devices.Length > 0)
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            foreach (WebCamDevice device in devices)
            {
                if (device.isFrontFacing)
                {
                    webcam = new WebCamTexture(device.name);
                    hasWebcam = true;
                    webcam.Play();
                    break;
                }
            }
        }
        hasWebcam = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasWebcam && webcam.didUpdateThisFrame)
        {
            //it uses a flattened array
            Color32[] thePixels = webcam.GetPixels32();
            Color32 centerPixel = thePixels[webcam.width / 2 + (webcam.width * webcam.height / 2)];
            Debug.Log($"The center pixel color is: {centerPixel}");
        }
    }
}
