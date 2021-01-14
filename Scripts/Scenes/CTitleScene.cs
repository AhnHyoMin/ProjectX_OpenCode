using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTitleScene : CSceneBase
{
    public override void initialize()
    {
        base.initialize();
    }

    protected override void BuildTask()
    {
        AddBuildTask(Task1);
        AddBuildTask(Task2());
    }


    private void Task1()
    {
        Debug.Log("Task1");
    }

    private IEnumerator Task2()
    {
        Debug.Log("Task2");

        yield return true;
    }
}
