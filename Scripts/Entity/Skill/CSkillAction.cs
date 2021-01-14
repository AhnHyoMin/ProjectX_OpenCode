using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class CSkillAction
{
    [SerializeField]
    private List<CSkillActionEvent> m_CSkillActionEventList = new List<CSkillActionEvent>();

    public void Initialize()
    {
        for (int i = 0; i < m_CSkillActionEventList.Count; i++)
        {
            m_CSkillActionEventList[i].Initialize();
        }
    }
}
