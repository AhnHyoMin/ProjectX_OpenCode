using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSceneBase : MonoBehaviour
{
    private CTaskManager m_CTaskManager = null;


    public virtual void initialize()
    {
        m_CTaskManager = new CTaskManager();
        BuildTask();
        StartCoroutine(m_CTaskManager.TaskRun(OnCompleteTask));
    }

    /// <summary>
    /// 로딩처리할 목록 지정
    /// </summary>
    protected virtual void BuildTask()
    {
        // EX). m_CTaskManager.Add(Test());
    }

    protected void AddBuildTask(IEnumerator _Task)
    {
        m_CTaskManager.Add(_Task);
    }
    protected void AddBuildTask(Action _Task)
    {
        m_CTaskManager.Add(_Task);
    }

    protected virtual void OnCompleteTask()
    {

    }
}
