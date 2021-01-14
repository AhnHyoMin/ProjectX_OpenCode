using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CUIManager : MonoBehaviour
{
    public static class ObjectName
    {
        // ������ Object�� �̸�
        public const string Owner = "UIManager";
    }

    public static CUIManager Get
    {
        get { return CProjectManager.Get.CUIManager; }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    //----------------------------------------------------------------------------------------------//
    [SerializeField]
    private Canvas m_UIRoot = null;
    [SerializeField]
    private int m_OderLayer = -1;

    private bool m_WebLoading = false;

    /// <summary>
    /// Esc, �ڷΰ��� Ű
    /// </summary>
    private bool m_IsCanBackKey = true;

    // Ȱ��ȭ�� UI����Ʈ 

    [ShowInInspector]
    private LinkedList<CUIBase> m_UIWindowList = new LinkedList<CUIBase>();

    [ShowInInspector]
    private Dictionary<UIWindowKey, CUIBase> m_UIWindowDic = new Dictionary<UIWindowKey, CUIBase>();
    [ShowInInspector]
    private Dictionary<UIWindowKey, Dictionary<UIModule, CUIModuleBase>> m_UIModuleDic = new Dictionary<UIWindowKey, Dictionary<UIModule, CUIModuleBase>>();


    /* ���� �ػ� ���� */
    private float screenResolutionRatio = 0.0f;

    private float screenResolutionRateUnity = 0.0f;

    //----------------------------------------------------------------------------------------------//
    #region Property

    public float ScreenResolutionRatio
    {
        get
        {
            Debug.Log("screenResolutionRatio = " + screenResolutionRatio);
            return screenResolutionRatio;
        }
    }

    public float ScreenResolutionRatioUnity
    {
        get { return screenResolutionRateUnity; }
    }

    public bool WebLoading { get => m_WebLoading; set => m_WebLoading = value; }
    public Canvas UIRoot { get => m_UIRoot; private set => m_UIRoot = value; }
    public bool IsCanBackKey { get => m_IsCanBackKey; set => m_IsCanBackKey = value; }

    #endregion


    //----------------------------------------------------------------------------------------------//
    #region MonoBehaviour
    private void Awake()
    {
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && m_IsCanBackKey)
        {
            LinkedListNode<CUIBase> _LastNode = m_UIWindowList.Last;

            if (_LastNode == null)
                return;


            if (_LastNode.Value.IsEsc() == true)
                CloseLast();

        }

        if (m_WebLoading == true)
        {

        }
    }
    #endregion
    //----------------------------------------------------------------------------------------------//

    /// <summary>
    /// �ڷ� ���� Ű ��� ����(Ű���� or ����� ���ư)
    /// </summary>
    /// <param name="_IsUse"></param>
    public void SetUseBackKey(bool _IsUse)
    {
        m_IsCanBackKey = _IsUse;
    }

    /// <summary>
    /// UIWindow�� ����.
    /// </summary>
    /// <param name="_UIWindowKey"></param>
    public void OpenWindow(UIWindowKey _UIWindowKey, UIWindowParamBase _UIWindowParamBase = null)
    {
        CreateOpenWindow(_UIWindowKey, _UIWindowParamBase);
    }

    /// <summary>
    /// UIWindow�� ����
    /// </summary>
    /// <param name="_UIWindowKey"></param>
    public T OpenWindow<T>(UIWindowKey _UIWindowKey, UIWindowParamBase _UIWindowParamBase = null) where T : CUIBase
    {
        return CreateOpenWindow(_UIWindowKey, _UIWindowParamBase) as T;
    }

    /// <summary>
    /// UI�����ؼ� UIDictionary�� �����Ѵ�.
    /// Ư��UI�� �̸� �����س��� ������ ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_UIWindowKey"></param>
    /// <param name="_Visible"></param>
    /// <param name="_UIWindowParamBase"></param>
    /// <returns></returns>
    public T CreateWindow<T>(UIWindowKey _UIWindowKey, bool _Visible = false, UIWindowParamBase _UIWindowParamBase = null) where T : CUIBase
    {
        CUIBase _CUIBase = null;

        if (!m_UIWindowDic.TryGetValue(_UIWindowKey, out _CUIBase))
        {
            _CUIBase = CreateUI(_UIWindowKey) as T;
        }

        if (_CUIBase != null)
        {
            _CUIBase.SetVisible(_Visible);
        }


        return _CUIBase as T;
    }
    /// <summary>
    /// UI�����ؼ� UIDictionary�� �����Ѵ�.
    /// Ư��UI�� �̸� �����س��� ������ ���
    /// </summary>
    /// <param name="_UIWindowKey"></param>
    /// <param name="_Visible"></param>
    /// <param name="_UIWindowParamBase"></param>
    public void CreateWindow(UIWindowKey _UIWindowKey, bool _Visible = false, UIWindowParamBase _UIWindowParamBase = null)
    {
        CUIBase _CUIBase = CreateUI(_UIWindowKey);
        _CUIBase.SetVisible(_Visible);

    }
    public T GetWindow<T>(UIWindowKey _UIWindowKey) where T : class
    {
        CUIBase _CUIBase = null;

        if (m_UIWindowDic.TryGetValue(_UIWindowKey, out _CUIBase))
            return _CUIBase as T;

        return null;
    }

    public CUIBase GetWindow(UIWindowKey _UIWindowKey)
    {
        CUIBase _CUIBase = null;

        if (m_UIWindowDic.TryGetValue(_UIWindowKey, out _CUIBase))
            return _CUIBase;

        return null;
    }

    public bool IsOpen(UIWindowKey _UIWindowKey)
    {
        CUIBase _CUIBase = GetWindow(_UIWindowKey);

        if (_CUIBase != null && _CUIBase.IsVisible == true)
            return true;

        return false;
    }

    /// <summary>
    /// UIWindow�� �����ϰų�, ��������ִ� UI�� ����.
    /// </summary>
    /// <param name="_UIWindowKey"></param>
    /// <returns></returns>
    private CUIBase CreateOpenWindow(UIWindowKey _UIWindowKey, UIWindowParamBase _UIWindowParamBase)
    {
        CUIBase _OpenUI = null;

        if (m_UIWindowDic.TryGetValue(_UIWindowKey, out _OpenUI))
        {
            //// �ߺ��� UI ����
            m_UIWindowList.Remove(_OpenUI);
        }
        else
        {
            _OpenUI = CreateUI(_UIWindowKey);
        }

        if (_OpenUI == null)
            return null;

        LinkedListNode<CUIBase> _LastNode = m_UIWindowList.Last;
        if (_LastNode != null)
        {
            CUIBase _CloseUI = _LastNode.Value;

            if ((_OpenUI.UIWindowMode & UIWindowMode.WindowClose) == UIWindowMode.WindowClose &&
                  (_CloseUI.UIWindowMode & UIWindowMode.Base) != UIWindowMode.Base)
            {
                // m_OderLayer--;
                _CloseUI.CloseEvent();
                _CloseUI.SetVisible(false);
                m_UIWindowList.RemoveLast();
            }
            else if ((_OpenUI.UIWindowMode & UIWindowMode.WindowClose) == UIWindowMode.WindowClose &&
                  (_CloseUI.UIWindowMode & UIWindowMode.Base) == UIWindowMode.Base)
            {
                _CloseUI.CloseEvent();
                _CloseUI.SetVisible(false);
            }

            if ((_OpenUI.UIWindowMode & UIWindowMode.WindowClose) != UIWindowMode.WindowClose &&
                    (_OpenUI.UIWindowMode & UIWindowMode.WindowOverlay) == UIWindowMode.WindowOverlay &&
                     (_CloseUI.UIWindowMode & UIWindowMode.WindowOverlay) == UIWindowMode.WindowOverlay)
            {
                _CloseUI.SetVisible(false);
            }
        }
        else
        {
            //  m_OderLayer = -1;
        }



        m_UIWindowList.AddLast(_OpenUI);

        m_OderLayer = m_UIWindowList.Count;
        _OpenUI.transform.SetSiblingIndex(m_OderLayer);

        _OpenUI.SetVisible(true);
        _OpenUI.Initialize(_UIWindowParamBase);

        return _OpenUI;
    }

    public void UpdateUIWindowText()
    {
        foreach (var item in m_UIWindowDic.Values)
        {
            item.InitializeText();
        }


    }

    /// <summary>
    /// �ƹ��� �ൿ ���ϰ� ���� ������ UI�� �ݴ´�
    /// </summary>
    /// <param name="_Destroy"></param>
    public void OnlyCloseLast(bool _Destroy = false)
    {
        LinkedListNode<CUIBase> _LastNode = m_UIWindowList.Last;

        if (_LastNode != null &&
            (_LastNode.Value.UIWindowMode & UIWindowMode.Base) != UIWindowMode.Base)
        {
            // ����UI�� �ƴҶ��� �ݱ� ó��
            _LastNode.Value.CloseEvent();

            if (_Destroy == true)
            {
                Destroy(_LastNode.Value.gameObject);
                m_UIWindowDic.Remove(_LastNode.Value.UIWindowKey);
            }
            else
            {
                _LastNode.Value.SetVisible(false);
            }

            m_UIWindowList.RemoveLast();
            m_OderLayer = m_UIWindowList.Count;
        }
    }

    /// <summary>
    /// ���� ���������� UI�� �ݴ´�(���ش�)
    /// </summary>
    public void CloseLast(bool _Destroy = false)
    {
        LinkedListNode<CUIBase> _LastNode = m_UIWindowList.Last;


        if (_LastNode != null &&
            (_LastNode.Value.UIWindowMode & UIWindowMode.Base) != UIWindowMode.Base)
        {
            // ����UI�� �ƴҶ��� �ݱ� ó��
            _LastNode.Value.CloseEvent();

            if (_Destroy == true)
            {
                Destroy(_LastNode.Value.gameObject);
                m_UIWindowDic.Remove(_LastNode.Value.UIWindowKey);
            }
            else
            {
                _LastNode.Value.SetVisible(false);
            }

            LinkedListNode<CUIBase> _UIWindowListPrevious = m_UIWindowList.Last.Previous;
            m_UIWindowList.RemoveLast();
            m_OderLayer = m_UIWindowList.Count;


            if (_UIWindowListPrevious != null)
            {
                _UIWindowListPrevious.Value.AfterCloseEvent();

                if ((_UIWindowListPrevious.Value.UIWindowMode & UIWindowMode.Base) != UIWindowMode.Base &&
                    (m_UIWindowList.Last.Value.UIWindowMode & UIWindowMode.WindowOverlay) != UIWindowMode.WindowOverlay)
                {
                    // m_OderLayer++;
                }
                _UIWindowListPrevious.Value.transform.SetSiblingIndex(m_OderLayer);
                _UIWindowListPrevious.Value.SetVisible(true);

                //if ((m_UIWindowList.Last.Value.UIWindowMode & UIWindowMode.WindowOverlay) != UIWindowMode.WindowOverlay)
                //    _UIWindowListPrevious.Value.Initialize(_UIWindowListPrevious.Value.UIWindowParamBase);


            }

            //m_UIWindowList.RemoveLast();

        }
    }

    /// <summary>
    /// UIWindowMode.Base�� ������ ��� UIWindow�� �ݴ´�.
    /// </summary>
    public void CloseAll(bool _Destroy = false)
    {
        foreach (var item in m_UIWindowList.Reverse())
        {
            if (_Destroy == true)
            {
                m_UIWindowDic.Remove(item.UIWindowKey);
                m_UIModuleDic.Remove(item.UIWindowKey);
                Destroy(item.gameObject);
            }
            else
            {
                CUtileEx.SetActive(item, false);
            }

            m_UIWindowList.RemoveLast();
        }
    }

    public void RemoveAll()
    {
        foreach (var item in m_UIWindowDic.Values.Reverse())
        {
            m_UIWindowDic.Remove(item.UIWindowKey);
            m_UIModuleDic.Remove(item.UIWindowKey);
            Destroy(item.gameObject);
        }

        m_UIWindowDic.Clear();
        m_UIModuleDic.Clear();
    }

    /// <summary>
    /// UI�� �����Ѵ�.
    /// </summary>
    /// <param name="_UIWindowKey"></param>
    /// <returns></returns>
    private CUIBase CreateUI(UIWindowKey _UIWindowKey)
    {

        GameObject pObj = null;
        // Prfabs/UI/Window/Window.prpeb
        string _Path = string.Format("{0}{1}", CResourcePath.UIPath, _UIWindowKey.ToString());


      //  pObj = CResourcesManager.Get.CreateResData(_Path, m_UIRoot.transform);
        if (pObj == null)
        {
            Debug.LogError("pObj == null");
            return null;
        }
        pObj.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        pObj.GetComponent<RectTransform>().sizeDelta = Vector3.zero;
        CUIBase _CUIBase = pObj.GetComponent(typeof(CUIBase)) as CUIBase;


        m_UIWindowDic.Add(_UIWindowKey, _CUIBase);
        return _CUIBase;
    }


    /// <summary>
    /// ��� �߰�
    /// </summary>
    /// <param name="_ParentUI"></param>
    /// <param name="_UIWindowKey"></param>
    /// <param name="_UIModule"></param>
    /// <returns></returns>
    public CUIModuleBase AddModule(CUIBase _ParentUI, UIWindowKey _UIWindowKey, UIModule _UIModule)
    {
        CUIModuleBase _CUIModuleBase = null;
        if (m_UIModuleDic.ContainsKey(_UIWindowKey))
        {
            // �ش� ������ Ű�� ���� ��� 
            if (!m_UIModuleDic[_UIWindowKey].ContainsKey(_UIModule))
            {
                // ������� ���� �����ؼ� �߰�
                _CUIModuleBase = CreateModule(_ParentUI, _UIWindowKey, _UIModule);
            }
            else
            {
                // ������ �ִ� �� ��ȯ 
                _CUIModuleBase = m_UIModuleDic[_UIWindowKey][_UIModule];
                // ��� �ѹ� ������Ʈ 
                _CUIModuleBase.Initialize();
            }
        }
        else
        {
            _CUIModuleBase = CreateModule(_ParentUI, _UIWindowKey, _UIModule);
        }

        return _CUIModuleBase;
    }

    private CUIModuleBase CreateModule(CUIBase _ParentUI, UIWindowKey _UIWindowKey, UIModule _UIModule)
    {
        GameObject pObj = null;
        // Prfabs/UI/Window/Window.prpeb
        string _Path = string.Format("{0}{1}", CResourcePath.UIModulePath, _UIModule.ToString());


      //  pObj = CResourcesManager.Get.CreateResData(_Path, m_UIRoot.transform);
        if (pObj == null)
        {
            Debug.LogError("pObj == null");
            return null;
        }
        pObj.transform.SetParent(_ParentUI.transform);
        // pObj.transform.localPosition = Vector3.zero;
        CUIModuleBase _CUIModuleBase = pObj.GetComponent(typeof(CUIModuleBase)) as CUIModuleBase;
        _CUIModuleBase.Initialize();

        if (m_UIModuleDic.ContainsKey(_UIWindowKey))
        {
            m_UIModuleDic[_UIWindowKey].Add(_UIModule, _CUIModuleBase);
        }
        else
        {
            Dictionary<UIModule, CUIModuleBase> _TempModuleDic = new Dictionary<UIModule, CUIModuleBase>();
            _TempModuleDic.Add(_UIModule, _CUIModuleBase);
            m_UIModuleDic.Add(_UIWindowKey, _TempModuleDic);
        }

        return _CUIModuleBase;
    }

    public CUIModuleBase GetModule(UIWindowKey _UIWindowKey, UIModule _UIModule)
    {
        if (m_UIModuleDic.ContainsKey(_UIWindowKey))
        {
            if (m_UIModuleDic[_UIWindowKey].ContainsKey(_UIModule))
            {
                return m_UIModuleDic[_UIWindowKey][_UIModule];
            }
        }

        return null;
    }

    public T GetModule<T>(UIWindowKey _UIWindowKey, UIModule _UIModule) where T : CUIModuleBase
    {
        if (m_UIModuleDic.ContainsKey(_UIWindowKey))
        {
            if (m_UIModuleDic[_UIWindowKey].ContainsKey(_UIModule))
            {
                return m_UIModuleDic[_UIWindowKey][_UIModule] as T;
            }
        }

        return null;
    }

    public void RemoveModule(UIWindowKey _UIWindowKey)
    {

        if (m_UIModuleDic.ContainsKey(_UIWindowKey))
        {
            foreach (var item in m_UIModuleDic[_UIWindowKey].Values)
            {
                Destroy(item.gameObject);
            }

            m_UIModuleDic.Remove(_UIWindowKey);
        }
    }

    private void RemoveAllModule()
    {
        foreach (var Modules in m_UIModuleDic.Values)
        {
            foreach (var item in Modules.Values)
            {
                Destroy(item.gameObject);
            }
        }

        m_UIModuleDic.Clear();
    }

    public void UpdateModule(UIModule _UIModule)
    {
        foreach (var item in m_UIModuleDic.Values)
        {
            if (item.ContainsKey(_UIModule))
                item[_UIModule].UpdateModule();
        }
    }

}
