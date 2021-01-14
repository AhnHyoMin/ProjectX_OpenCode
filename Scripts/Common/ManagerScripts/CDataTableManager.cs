using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDataTableManager : MonoBehaviour
{
    public static class ObjectName
    {
        // 소유자 Object의 이름.
        public const string Owner = "DataTableManager";
    }

    public static CDataTableManager Get
    {
        get { return CProjectManager.Get.CDataTableManager; }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

}
