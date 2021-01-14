using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CAnimationUtile
{
    /// <summary>
    /// _TargetFrame이 _AnimTime에 해당하는 시간을 계산함
    /// </summary>
    /// <param name="_AnimTime"></param>
    /// <param name="_TotalFrame"></param>
    ///     /// <param name="_TargetFrame"></param>
    public static float GetTargetFrameTime(float _AnimTime, int _TotalFrame, int _TargetFrame)
    {
        _TotalFrame = (int)(_AnimTime * _TotalFrame);

        return (_AnimTime / _TotalFrame) * _TargetFrame;
    }
}

