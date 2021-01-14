using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using System.Security.Cryptography;

public static partial class CUtileEx
{

    /// <summary>
    /// Vector3 0을 중심으로 TargetVec +/- 범위 사이의 랜덤값을 반환
    /// </summary>
    /// <param name="_TargetVec"></param>
    /// <returns></returns>
    public static Vector3 RandomRangeBox(Vector3 _TargetVec)
    {
        UnityEngine.Random.InitState(UnityEngine.Random.Range(0, int.MaxValue));
        Vector3 _ResultVector3 = Vector3.zero;

        _ResultVector3.x = UnityEngine.Random.Range(-_TargetVec.x, _TargetVec.x);
        _ResultVector3.y = UnityEngine.Random.Range(-_TargetVec.y, _TargetVec.y);
        _ResultVector3.z = UnityEngine.Random.Range(-_TargetVec.z, _TargetVec.z);

        return _ResultVector3;
    }

    public static Vector2 RandomCircle(float _Radius)
    {
        return UnityEngine.Random.insideUnitCircle * _Radius;
    }

    public static Vector3 RandomSphere(float _Radius)
    {
        return UnityEngine.Random.insideUnitSphere * _Radius;
    }

    /// <summary>
    /// int _Value1 + _Value2 = 값이 int.Max를 넘는지 체크
    /// </summary>
    /// <param name="_Value1"></param>
    /// <param name="_Value2"></param>
    /// <returns></returns>
    public static int CheckValue(int _Value1, int _Value2,bool _Init = false)
    {
        int _Value = 0;

        try
        {
            _Value = checked(_Value1 + _Value2);
        }
        catch
        {
            Debug.LogError("int Value OverFlow");
            if (_Init == false)
                _Value = int.MaxValue;
            else
                _Value = 0;
        }

        return _Value;
    }


    public static float SprDistance(Vector3 _Origin, Vector3 _Target)
    {
        Vector3 _Dir = _Target - _Origin;

        return _Dir.sqrMagnitude;
    }

    public static float SqrValue(float _Value)
    {
        return _Value * _Value;
    }

    public static int SqrValue(int _Value)
    {
        return _Value * _Value;
    }

    /// <summary>
    /// An utility function to calculate a distance between a point and a segment.
    /// </summary>
    public static float DistanceToSegment(Vector3 point, Vector3 p0, Vector3 p1)
    {
        var lengthSqr = (p1 - p0).sqrMagnitude;
        if (lengthSqr <= float.Epsilon) return Vector3.Distance(point, p0);

        var t = Mathf.Clamp01(((point.x - p0.x) * (p1.x - p0.x) +
                               (point.y - p0.y) * (p1.y - p0.y) +
                               (point.z - p0.z) * (p1.z - p0.z)) / lengthSqr);

        return Vector3.Distance(point, p0 + (p1 - p0) * t);
    }

    /// <summary>
    /// An utility function to calculate a vector between a point and a segment.
    /// </summary>
    public static Vector3 VectorToSegment(Vector3 point, Vector3 p0, Vector3 p1)
    {
        var lengthSqr = (p1 - p0).sqrMagnitude;
        if (lengthSqr <= float.Epsilon) return p0 - point;

        var t = Mathf.Clamp01(((point.x - p0.x) * (p1.x - p0.x) +
                               (point.y - p0.y) * (p1.y - p0.y) +
                               (point.z - p0.z) * (p1.z - p0.z)) / lengthSqr);

        return p0 + (p1 - p0) * t - point;
    }

    public static IEnumerator AppVersionCheck(Action<bool> _State)
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        string _AppID = "https://play.google.com/store/apps/details?id=com.RaGames.DungeonCrisis";
#elif UNITY_EDITOR
        string _AppID = "https://play.google.com/store/apps/details?id=com.RaGames.DungeonCrisis";
#endif

        UnityWebRequest _WebRequest = UnityWebRequest.Get(_AppID);

        yield return _WebRequest.SendWebRequest();

        // 정규식으로 전채 문자열중 버전 정보가 담겨진 태그를 검색한다.
        string _Pattern = @"<span class=""htlgb"">[0-9]{1}[.][0-9]{1}[.][0-9]{1}<";
        Regex _Regex = new Regex(_Pattern, RegexOptions.IgnoreCase);
        Match _Match = _Regex.Match(_WebRequest.downloadHandler.text);

        if (_Match != null)
        {
            // 버전 정보가 담겨진 태그를 찾음
            // 해당 태그에서 버전 넘버만 가져온다
            _Match = Regex.Match(_Match.Value, "[0-9]{1,3}[.][0-9]{1,3}[.][0-9]{1,3}");

            if (_Match != null)
            {
                try
                {
                    int[] _ClientVersion = VersionPaser(Application.version);
                    int[] _AppStoreVersion = VersionPaser(_Match.Value);

                    Debug.Log("  Application.version : " + Application.version + ", AppStore version :" + _Match.Value);

                    if (_AppStoreVersion[0] != _ClientVersion[0] || _AppStoreVersion[1] != _ClientVersion[1] || _AppStoreVersion[2] != _ClientVersion[2])
                    {
                        if (_State != null)
                            _State(true);

                        yield break;
                    }
                }
                catch (Exception Ex)
                {
                    // 비정상 버전정보 파싱중 Exception처리

                    Debug.LogError("비정상 버전 정보 Exception : " + Ex);
                    Debug.LogError("  Application.version : " + Application.version + ", AppStore version :" + _Match.Value);
                }
            }
            else
            {
                Debug.LogError("Not Found AppStoreVersion Info");
            }
        }

        if (_State != null)
            _State(false);
    }

    private static int[] VersionPaser(string _Version)
    {
        string[] _TempSpilt = _Version.Split('.');

        int[] _Temp = new int[3];
        for (int i = 0; i < _TempSpilt.Length; i++)
        {
            _Temp[i] = int.Parse(_TempSpilt[i]);
        }
        return _Temp;
    }

    public static void ListIndexChange<T>(List<T> _ListData, int _Index, bool _IndexUp = true)
    {
        if(_IndexUp == true)
        {
            if (_Index - 1 >= 0)
            {
                T _CSkillActionData = _ListData[_Index];
                _ListData.RemoveAt(_Index);

                _ListData.Insert(_Index - 1, _CSkillActionData);
            }
        }
        else
        {
            if (_Index + 1 <= _ListData.Count -1)
            {
                T _CSkillActionData = _ListData[_Index];
                _ListData.RemoveAt(_Index);

                _ListData.Insert(_Index + 1, _CSkillActionData);
            }
        }

    }


    public static string GetUniqueId(int length = 8, string mask = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890")
    {
        char[] chars = mask.ToCharArray();
        RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        byte[] data = new byte[length];
        crypto.GetNonZeroBytes(data);
        StringBuilder result = new StringBuilder(length);
        foreach (byte b in data)
        {
            result.Append(chars[b % (chars.Length - 1)]);
        }
        return result.ToString();
    }

}
