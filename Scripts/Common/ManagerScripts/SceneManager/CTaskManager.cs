using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CTaskManager 
{
    private Queue<CTask> m_TaskList = new Queue<CTask>();

    private bool m_IsStart = false;
    private bool m_IsFinish = true;

    private float m_CurrentProgerss = 0;


    public float CurrentProgerss { get => m_CurrentProgerss; private set => m_CurrentProgerss = value; }

    public void Add(IEnumerator _Action)
    {
        CTask _CTask = new CTask(_Action);
        m_TaskList.Enqueue(_CTask);
    }

    public void Add(Action _Action)
    {
        CTask _CTask = new CTask(_Action);
        m_TaskList.Enqueue(_CTask);
    }

    public IEnumerator TaskRun(Action _OnCompleteAction)
    {
        m_IsStart = true;
        m_IsFinish = false;
        m_CurrentProgerss = 0;

        int _TotalCount = 0;
        int _CurrentCount = 0;

        _TotalCount = m_TaskList.Count;

        while (m_TaskList.Count > 0)
        {
            CTask _CTask = m_TaskList.Dequeue();

            if (_CTask.Current is Action)
            {
                Action _Action = _CTask.Current as Action;
                _Action();
            }
            else if(_CTask.Current is IEnumerator)
            {
                yield return _CTask.Current;

                _CTask.MoveNext();
            }
            _CurrentCount++;

            m_CurrentProgerss = m_CurrentProgerss / _TotalCount;
            yield return null;
        }


        if (_OnCompleteAction != null)
            _OnCompleteAction();

        m_IsStart = false;
        m_IsFinish = true;;

        yield return null;
    }
}
