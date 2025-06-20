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
            hasWebcam = true'
        }
    }

    // Update is called once per frame
    void Update()
    {  
        
    }
}
