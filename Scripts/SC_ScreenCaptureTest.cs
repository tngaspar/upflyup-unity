using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SC_ScreenCaptureTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Press Q to capture screenshot
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(CaptureScreen());
        }
    }

    IEnumerator CaptureScreen()
    {
        yield return new WaitForEndOfFrame();

        //Here is a captured screenshot
        Texture2D screenshot = SC_ScreenAPI.CaptureScreen();

        //And here is how you get a byte array of the screenshot, you can use it to save the image locally, upload it to server etc.
        byte[] bytes = screenshot.EncodeToPNG();
        var dirPath = Application.dataPath + "/../SaveImages/";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        File.WriteAllBytes(dirPath + "Image" + ".png", bytes);
    }
}