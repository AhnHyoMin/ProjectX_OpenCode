using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class CRandomUtile
{
    static int _Select = 0;
    public static int Next(int _Min, int _Max)
    {
        return Random.Range(_Min, _Max);
    }
    public static int Next(int _Max)
    {
        return Random.Range(0,_Max);
    }

    public static float NextFloat()
    {
        return Random.value;
    }

    public static float Next(float _Min, float _Max)
    {
        float _RandomValue = Random.Range(_Min, _Max);
        return _RandomValue;
    }


    public static void InitSeed(int _Seed)
    {
        _Select = CUtileEx.CheckValue(_Select, _Seed, true);
        Random.InitState(_Select);
        //_Select = _Seed + (int)(Time.time * 100);
    }

    public static void InitSeed()
    {
        CRandomUtile.InitSeed((int)System.DateTime.Now.Second);
    }
}

