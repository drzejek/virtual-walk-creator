using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using System.Linq;

using Gvr.Internal;
public class VRToggle : MonoBehaviour
{
    public GyroController _gyroController;
    public ButtonManager _btnManager;
    [SerializeField] Camera mainCam;
    public Image black;

    void Start()
    {
        _gyroController = Camera.main.GetComponent<GyroController>();

        ToggleVR();

        StartCoroutine(WaitOneSecond());
        //black.enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void ToggleVR()
    {
        if(ButtonManager.deviceName == "Cardboard")
        {
            StartCoroutine(SwitchToVR()); 
        }
        else
        {
            StartCoroutine(SwitchTo2D());
        }
    }
    
    public IEnumerator SwitchToVR()
    {
        string desiredDevice = "Cardboard";
        if (String.Compare(XRSettings.loadedDeviceName, desiredDevice, true) != 0)
        {
            XRSettings.LoadDeviceByName(desiredDevice);
            yield return null;
        }
        XRSettings.enabled = true;
        mainCam.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public IEnumerator SwitchTo2D()
    {
        XRSettings.LoadDeviceByName(string.Empty);
        XRSettings.enabled = false;
        yield return null;
        mainCam.transform.rotation = GyroToUnity(Input.gyro.attitude);
        // ResetCameras();
    }

    // Resets camera transform and settings on all enabled eye cameras.
    void ResetCameras()
    {
        // Camera looping logic copied from GvrEditorEmulator.cs
        for (int i = 0; i < Camera.allCameras.Length; i++)
        {
            Camera cam = Camera.allCameras[i];
            if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None)
            {
                cam.transform.localPosition = Vector3.zero;
                cam.transform.localRotation = Quaternion.identity;
            }
        }
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1.1f);
        black.enabled = false;
    }
}
