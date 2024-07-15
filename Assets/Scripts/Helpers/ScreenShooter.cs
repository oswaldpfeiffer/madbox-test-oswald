using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShooter : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            string name = Time.frameCount.ToString() + ".png";
            Debug.Log("Capture screenshot " + name);
            ScreenCapture.CaptureScreenshot(name, 1);
        }
    }
}
