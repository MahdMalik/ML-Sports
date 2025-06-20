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
        if (WebCamTexture.devices.Length > 0)
        {
            webcam = new WebCamTexture();
            webcam.Play();
            hasWebcam = true;
        }
        else
        {
            hasWebcam = false;
        }
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
