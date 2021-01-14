using SqlCipher4Unity3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSQLiteConnection : SQLiteConnection
{
    public CSQLiteConnection(SQLiteConnectionString connectionString) : base(connectionString)
    {
    }
    public bool IsOpen()
    {
        return _open;
    }
}
