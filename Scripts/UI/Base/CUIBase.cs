using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CUIBase : MonoBehaviour {

    [SerializeField, TextArea,FormerlySerializedAs("m_PrefabsDescField")]
    private string m_UIDescField = "그냥 설명 적어두는 텍스트 필드";

    [SerializeField]
    private int m_TitleBarNameKey = 0;

    [SerializeField]
    protected UIWindowKey m_UIWindowKey = UIWindowKey.None;
    [SerializeField]
    protected UIWindowMode m_UIWindowMode = UIWindowMode.None;
    [SerializeField]
    protected UIModule m_UseModule = UIModule.None;


    private bool m_Visible;
    // 



    protected UIWindowParamBase m_UIWindowParamBase = null;
    //------------------------------------------------------------------------------

    //------------------------------------------------------------------------------
    #region Property
    public bool IsVisible
    {
        get
        {
            return m_Visible;
        }

        set
        {
            m_Visible = value;
        }
    }

    public UIWindowMode UIWindowMode { get => m_UIWindowMode; set => m_UIWindowMode = value; }
    public UIWindowKey UIWindowKey { get => m_UIWindowKey; set => m_UIWindowKey = value; }
    public UIWindowParamBase UIWindowParamBase { get => m_UIWindowParamBase; set => m_UIWindowParamBase = value; }
    #endregion

    private void OnDestroy()
    {
        //if (CUIManager.Get != null)
        //    CUIManager.Get.RemoveModule(m_UIWindowKey);
    }

    public virtual void Initialize(UIWindowParamBase _UIWindowParamBase)
    {
        m_UIWindowParamBase = _UIWindowParamBase;

        if ((m_UseModule & UIModule.UIModuleTitleBar) == UIModule.UIModuleTitleBar)
        {
            //UIModuleTitleBar _UIModuleTitleBar =  CUIManager.Get.AddModule(this, m_UIWindowKey, UIModule.UIModuleTitleBar) as UIModuleTitleBar;
           
            //if(_UIModuleTitleBar != null && m_TitleBarNameKey != 0)
            //{
            //    _UIModuleTitleBar.SetTitleText(m_TitleBarNameKey);
            //}
        }

        if ((m_UseModule & UIModule.UIModuleResourceBar) == UIModule.UIModuleResourceBar)
        {
            CUIManager.Get.AddModule(this, m_UIWindowKey, UIModule.UIModuleResourceBar);
        }
        if ((m_UseModule & UIModule.UIModuleBackClickBlock) == UIModule.UIModuleBackClickBlock)
        {
            CUIModuleBase _CUIModuleBase = CUIManager.Get.AddModule(this, m_UIWindowKey, UIModule.UIModuleBackClickBlock);
            _CUIModuleBase.transform.SetParent(this.transform);
            _CUIModuleBase.transform.SetAsFirstSibling();
        }

        if ((m_UseModule & UIModule.UIModuleCloseBgBtn) == UIModule.UIModuleCloseBgBtn)
        {
            CUIModuleBase _CUIModuleBase = CUIManager.Get.AddModule(this, m_UIWindowKey, UIModule.UIModuleCloseBgBtn);
            _CUIModuleBase.transform.SetParent(this.transform);
            _CUIModuleBase.transform.SetAsFirstSibling();
        }

        if ((m_UseModule & UIModule.UIModulePlayerInfo) == UIModule.UIModulePlayerInfo)
        {
            CUIManager.Get.AddModule(this, m_UIWindowKey, UIModule.UIModulePlayerInfo);
        }
    }

    protected T GetParam<T>() where T : UIWindowParamBase
    {
        return m_UIWindowParamBase as T;
    }

    public T GetModule<T>(UIModule _UIModule) where T : CUIModuleBase
    {
        return CUIManager.Get.GetModule<T>(m_UIWindowKey, _UIModule);
    }

    public virtual void InitializeText()
    {
        if ((m_UseModule & UIModule.UIModuleTitleBar) == UIModule.UIModuleTitleBar)
        {
            //UIModuleTitleBar _UIModuleTitleBar = CUIManager.Get.AddModule(this, m_UIWindowKey, UIModule.UIModuleTitleBar) as UIModuleTitleBar;

            //if (_UIModuleTitleBar != null && m_TitleBarNameKey != 0)
            //{
            //    _UIModuleTitleBar.SetTitleText(m_TitleBarNameKey);
            //}
        }
    }

    /// <summary>
    /// 열었던 UI가 닫히고 현재 UI로 되돌아 왔을때 호출
    /// </summary>
    public virtual void AfterCloseEvent()
    {

    }

    /// <summary>
    /// UI가 닫힐때 발생한다.
    /// </summary>
    public virtual void CloseEvent()
    {

    }

    /// <summary>
    /// Back키 버튼처리, // false라면 back를 사용하지 않는다
    /// </summary>
    /// <returns></returns>
    public virtual bool IsEsc()
    {
        return true;
    }

    public virtual void SetVisible(bool _Visible)
    {
        m_Visible = _Visible;
        if (this.gameObject.activeSelf != _Visible)
        {
            this.gameObject.SetActive(_Visible);
        }
    }

    #region OnClick

    public virtual void OnClickClose()
    {
        CUIManager.Get.CloseLast();
    }

    #endregion
}
