using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

/// <summary>
/// string 관련 Utile 모아둠
/// </summary>
public static class CStringUtile 
{
    private static StringBuilder m_StringBuilder = new StringBuilder(1024);



    public static string AppendFormat(string _Format, params string[] _args)
    {
        m_StringBuilder.Clear();
        return m_StringBuilder.AppendFormat(_Format, _args).ToString();
    }

}
