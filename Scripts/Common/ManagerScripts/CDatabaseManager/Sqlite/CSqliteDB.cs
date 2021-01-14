using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SqlCipher4Unity3D;
using System.IO;
using System;

public static class CSqliteTableName
{

}

public class CSqliteDB
{
    private string m_DBFileName = "PlayerDB_{0}.sqlite3";
    protected string m_PlarformFilePath = "";
    private CSQLiteConnection m_CSQLiteConnection = null;

    public void Initialize()
    {
        if (!IsExitDBFile())
        {
            // Sqlite파일이 존재하지 않음 새로 생성
            SQLiteConnectionString _SQLiteConnectionString = new SQLiteConnectionString(GetDBFilePath(), SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite, true, "xodidakstp11!!");

            m_CSQLiteConnection = new CSQLiteConnection(_SQLiteConnectionString);

            if (m_CSQLiteConnection == null)
            {
                Debug.LogError("m_DbConnection is Null");
                return;
            }

        }


        if (DBConnection() == true)
        {
            try
            {
                InitTable();
            }
            catch (Exception e)
            {
                Debug.LogError("Debug : " + e.Message);
            }

        }
        else
        {
            Debug.LogError($"DbConnection  Connect Faild ");
        }
    }

    private void InitTable()
    {

    }

    public bool IsExitDBFile()
    {
        return File.Exists(GetDBFilePath());
    }
    public byte[] GetDBFile()
    {
        byte[] _Data = null;
        if (IsExitDBFile() == true)
            _Data = File.ReadAllBytes(GetDBFilePath());

        return _Data;
    }
    public string GetDBFilePath()
    {
        m_PlarformFilePath = $"{Application.persistentDataPath}/{m_DBFileName}";
        Debug.Log($"SQlite Path : {m_PlarformFilePath}");
        return m_PlarformFilePath;
    }

    public bool DBConnection()
    {
        SQLiteConnectionString _SQLiteConnectionString = new SQLiteConnectionString(GetDBFilePath(), SQLiteOpenFlags.ReadWrite, true, "xodidakstp11!!");

        CSQLiteConnection _SQLiteConnection = new CSQLiteConnection(_SQLiteConnectionString);

        if (_SQLiteConnection != null)
        {
            return _SQLiteConnection.IsOpen();
        }
        else
        {
            Debug.LogError($"Path : {GetDBFilePath()} is Not Found");

            return false;
        }
    }
}
