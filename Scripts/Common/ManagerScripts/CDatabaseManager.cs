using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDatabaseManager : MonoBehaviour
{
    public static class ObjectName
    {
        // 소유자 Object의 이름.
        public const string Owner = "DatabaseManager";
    }

    public static CDatabaseManager Get
    {
        get { return CProjectManager.Get.CDatabaseManager; }
    }


    private CSqliteDB m_CSqliteDB = null;


    #region Property
    public CSqliteDB CSqliteDB { get => m_CSqliteDB; private set => m_CSqliteDB = value; }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
