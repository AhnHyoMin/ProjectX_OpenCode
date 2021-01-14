using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 해상도 관련 함수 
/// </summary>
public class CResolutionUtile 
{
    public static int CalculateBannerHeight()
    {
        Debug.Log("Screen.height : " + Screen.height);
        Debug.Log("Screen.dpi : " + Screen.dpi);

        if (Screen.height <= 400 * Mathf.RoundToInt(Screen.dpi / 160))
        {
            int _HeightSzie = 32 * Mathf.RoundToInt(Screen.dpi / 160);
            if (_HeightSzie >= 50)
                _HeightSzie = 50;

            return _HeightSzie;
        }
        else if (Screen.height <= 720 * Mathf.RoundToInt(Screen.dpi / 160))
        {
            int _HeightSzie = 50 * Mathf.RoundToInt(Screen.dpi / 160);
            if (_HeightSzie >= 100)
                _HeightSzie = 100;

            return _HeightSzie;
        }
        else
        {
            int _HeightSzie = 90 * Mathf.RoundToInt(Screen.dpi / 160);

            if (_HeightSzie >= 250)
                _HeightSzie = 250;

            return _HeightSzie;
        }
    }

    public static int CalculateBannerWidth()
    {
        if (Screen.width <= 800 * Mathf.RoundToInt(Screen.dpi / 160))
        {
            return 32 * Mathf.RoundToInt(Screen.dpi / 160);
        }
        else if (Screen.width <= 1280 * Mathf.RoundToInt(Screen.dpi / 160))
        {
            return 50 * Mathf.RoundToInt(Screen.dpi / 160);
        }
        else
        {
            return 90 * Mathf.RoundToInt(Screen.dpi / 160);
        }
    }

    /// <summary>
    /// fFixedResoulutionHeight 내가 고정한 해상도 높이 (720x1280으로 고정했다면 1280)
    /// fdpHeight 바꾸고자 하는 dp(애드몹 배너 320x50일 때 50)
    /// </summary>
    /// <param name="fFixedResoulutionHeight"></param>
    /// <param name="fdpHeight"></param>
    /// <returns></returns>
    public static float DPToPixel(float fFixedResoulutionHeight, float fdpHeight)
    {
        float fNowDpi = (Screen.dpi * fFixedResoulutionHeight) / Screen.height;
        Debug.Log("DPToPixel - fNowDpi : " + fNowDpi);
        float scale = fNowDpi / 160;
        Debug.Log("DPToPixel - scale : " + scale);
        float pixel = fdpHeight * scale;
        Debug.Log("DPToPixel - pixel : " + pixel);
        return pixel;
    }


    public static float PixelToDP()
    {
        return 0f;
    }
}
