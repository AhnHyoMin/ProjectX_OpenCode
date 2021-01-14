using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ESceneType
{
    eNone,
    eTitleScene,
}

public class CSceneManager : MonoBehaviour
{

    public static class ObjectName
    {
        // 소유자 Object의 이름.
        public const string Owner = "SceneManager";
    }

    public static CSceneManager Get
    {
        get { return CProjectManager.Get.CSceneManager; }
    }

    [SerializeField]
    private Transform m_TrRoot = null;

    [SerializeField]
    private ESceneType m_CurSceneType = ESceneType.eNone;
    private CSceneBase m_CurScene = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    /// <summary>
    /// 씬 로드
    /// </summary>
    /// <param name="_EScene"></param>
    public void LoadScene(ESceneType _EScene)
    {
        Clear();

        m_CurScene =  CreateScene(_EScene);
        m_CurSceneType = _EScene;
        if (m_CurScene != null)
        {
            m_CurScene.initialize();
        }
        else
        {
            Debug.LogError($"{_EScene} is Not Found");
        }
    }


    /// <summary>
    /// 씬 생성
    /// </summary>
    /// <param name="_EScene"></param>
    /// <returns></returns>
    private CSceneBase CreateScene(ESceneType _EScene)
    {
        CSceneBase _CSceneBase = null;
        switch (_EScene)
        {
            case ESceneType.eTitleScene:
                {
                    GameObject _GameObject = new GameObject("TitleScene");
                    _CSceneBase =  _GameObject.AddComponent<CTitleScene>();
                    _GameObject.transform.parent = m_TrRoot;
                }
                break;
        }
        return _CSceneBase;
    }

    /// <summary>
    /// 씬 전환시 정리 할것들
    /// </summary>
    private void Clear()
    {
        if(m_CurScene != null)
        {
            Destroy(m_CurScene.gameObject);
            m_CurScene = null;
        }



        GC.Collect();
    }

}
