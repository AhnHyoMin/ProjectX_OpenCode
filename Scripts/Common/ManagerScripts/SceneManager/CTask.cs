using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CTask : IEnumerator
{
    private Action m_TaskAction = null;
    private IEnumerator m_TaskEnumerator = null;
    private object current = null;

    public object Current { get => current; private set => current = value; }


    public CTask(IEnumerator _Task)
    {
        m_TaskEnumerator = _Task;
        Current = _Task;
    }

    public CTask(Action _Task)
    {
        m_TaskAction = _Task;
        current = _Task;
    }


    public bool MoveNext()
    {
        if (current is Action)
        {
            return true;
        }
        else if (Current is IEnumerator)
        {
            return m_TaskEnumerator.MoveNext();
        }
        else
            return false;
    }

    public void Reset()
    {
        m_TaskEnumerator.Reset();
    }
}
