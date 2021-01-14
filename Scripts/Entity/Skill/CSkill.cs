using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CSkill
{
    [SerializeField]
    private List<CSkillAction> m_SkillActionList = new List<CSkillAction>();

    private bool m_IsPlay = false;
    private bool m_IsStop = true;


    public void Initialize()
    {
        for (int i = 0; i < m_SkillActionList.Count; i++)
        {
            m_SkillActionList[i].Initialize();
        }
    }


    public void PlayAction()
    {

    }

    public void IsPlay()
    {

    }

    public void IsStop()
    {

    }


    public void Update()
    {

    }
}
