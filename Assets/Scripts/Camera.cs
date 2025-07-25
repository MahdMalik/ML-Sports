using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class Camera : MonoBehaviour
{
    public WebCamTexture webcam;
    bool hasWebcam;

    bool startMethodDone = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        ushort countdownToAccept = 0;
        const ushort MAX_FRAME_COUNT = 600;
        bool gotPerms = true;
        if (Application.platform == RuntimePlatform.Android && !Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
            while (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                countdownToAccept++;
                if (countdownToAccept == MAX_FRAME_COUNT)
                {
                    break;
                }
                yield return null;
            }
            //one final check
            gotPerms = Permission.HasUserAuthorizedPermission(Permission.Camera);
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer && !Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            //ask for perms
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            //if we still don't get it, break out 
            if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                gotPerms = false;
            }
        }

        //first, let's make sure there's actually devices to even loop through
        if (gotPerms && WebCamTexture.devices.Length > 0)
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            foreach (WebCamDevice device in devices)
            {
                if (device.isFrontFacing)
                {
                    webcam = new WebCamTexture(device.name);
                    hasWebcam = true;
                    webcam.Play();
                    Debug.Log($"Webcam succeed!");
                    startMethodDone = true;
                    yield break;
                }
            }
        }
        hasWebcam = false;
        Debug.Log($"Webcam failed!");
        startMethodDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startMethodDone)
        {
            if (hasWebcam && webcam.didUpdateThisFrame)
            {
                //it uses a flattened array
                Color32[] thePixels = webcam.GetPixels32();
                Color32 centerPixel = thePixels[webcam.width / 2 + (webcam.width * webcam.height / 2)];
                // Debug.Log($"The center pixel color is: {centerPixel}");
            }
        }
    }
}
