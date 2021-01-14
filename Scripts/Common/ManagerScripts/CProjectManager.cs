using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CProjectManager : MonoBehaviour
{
    private static CProjectManager m_Instance = null;

    public static class ObjectName
    {
        // 소유자 Object의 이름.
        public const string Owner = "ProjectManager";
    }
    public static CProjectManager Get
    {
        get
        {
            if (Application.isPlaying)
            {
                if (m_Instance == null)
                {
                    GameObject _GameObject = GameObject.Find(ObjectName.Owner);

                    if (_GameObject == null)
                    {
                        _GameObject = Resources.Load(ObjectName.Owner, typeof(GameObject)) as GameObject;
                        _GameObject = Instantiate(_GameObject) as GameObject;

                        m_Instance = _GameObject.GetComponent<CProjectManager>();
                        DontDestroyOnLoad(_GameObject);
                    }

                }
            }

            return m_Instance;
        }
    }




    [SerializeField, Header("DBSetting")]
    private string m_DBPassStr = "";


    #region Manager
    [Header("Manager")]
    [SerializeField]
    private CResourcesManager m_CResourcesManager = null;

    [SerializeField]
    private CDatabaseManager m_CDatabaseManager = null;

    [SerializeField]
    private CDataTableManager m_CDataTableManager = null;

    [SerializeField]
    private CUIManager m_CUIManager = null;

    [SerializeField]
    private CSceneManager m_CSceneManager = null;


    #region ManagerProperty
    public CResourcesManager CResourcesManager { get => m_CResourcesManager; private set => m_CResourcesManager = value; }
    public CDatabaseManager CDatabaseManager { get => m_CDatabaseManager; private set => m_CDatabaseManager = value; }
    public CDataTableManager CDataTableManager { get => m_CDataTableManager; private set => m_CDataTableManager = value; }
    public CUIManager CUIManager { get => m_CUIManager; private set => m_CUIManager = value; }
    public CSceneManager CSceneManager { get => m_CSceneManager; private set => m_CSceneManager = value; }

    #endregion

    #endregion

    private void Awake()
    {
        m_Instance = this;
        DontDestroyOnLoad(this.gameObject);


        Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        CSceneManager.Get.LoadScene(ESceneType.eTitleScene);

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CResourcesManager.Get.CAddressableManager.InstantiateAsync("Cube",
                (bool _State, GameObject _GameObject) =>
                {
                    if (_State == true)
                    {
                        Debug.Log(_GameObject.name);
                    }

                });
        }
    }

    private void Initialize()
    {
        if (m_CResourcesManager == null)
            m_CResourcesManager = transform.Find(CResourcesManager.ObjectName.Owner).GetComponent<CResourcesManager>();

        if (m_CDatabaseManager == null)
            m_CDatabaseManager = transform.Find(CDatabaseManager.ObjectName.Owner).GetComponent<CDatabaseManager>();

        if (m_CDataTableManager == null)
            m_CDataTableManager = transform.Find(CDataTableManager.ObjectName.Owner).GetComponent<CDataTableManager>();

        if (m_CUIManager == null)
            m_CUIManager = transform.Find(CUIManager.ObjectName.Owner).GetComponent<CUIManager>();

        if (m_CSceneManager == null)
            m_CSceneManager = transform.Find(CSceneManager.ObjectName.Owner).GetComponent<CSceneManager>();
    }
}
