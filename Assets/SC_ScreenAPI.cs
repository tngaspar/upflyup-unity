using UnityEngine;

public static class SC_ScreenAPI
{
    /// <summary>
    /// </summary>
    /// <param name="limitSize">If above 0, will make sure that the width and height of the captured image are equal or less than specified.</param>
    /// <returns>Returns a Texture2D.</returns>
    public static Texture2D CaptureScreen(int limitSize = 0)
    {
        //Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);
        //Read screen contents into the texture
        screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        screenshot.Apply();

        if (limitSize > 0)
        {
            screenshot = ScaleTexture(screenshot, limitSize);
        }

        return screenshot;
    }

    static Texture2D ScaleTexture(Texture2D source, int limitSize)
    {
        int width = source.width;
        int height = source.height;
        bool resize = false;

        if (limitSize > 0)
        {
            if (width > limitSize || height > limitSize)
            {
                int newWidth = 0;
                int newHeight = 0;

                float tmpRatio = (width * 1.000f) / (height * 1.000f);
                if (tmpRatio == 1)
                {
                    newWidth = limitSize;
                    newHeight = limitSize;
                }
                else
                {
                    if (tmpRatio > 1)
                    {
                        newWidth = limitSize;
                        newHeight = (int)(limitSize / tmpRatio);
                    }
                    else
                    {
                        newWidth = (int)(limitSize * tmpRatio);
                        newHeight = limitSize;
                    }
                }

                width = newWidth;
                height = newHeight;
                if (width > 0 && height > 0)
                {
                    resize = true;
                }
            }
        }

        if (resize)
        {
            Texture2D result = new Texture2D(width, height, source.format, true);
            Color[] rpixels = result.GetPixels(0);
            float incX = (1.0f / (float)width);
            float incY = (1.0f / (float)height);
            for (int px = 0; px < rpixels.Length; px++)
            {
                rpixels[px] = source.GetPixelBilinear(incX * ((float)px % width), incY * ((float)Mathf.Floor(px / width)));
            }
            result.SetPixels(rpixels, 0);
            result.Apply();
            return result;
        }

        return source;
    }
}