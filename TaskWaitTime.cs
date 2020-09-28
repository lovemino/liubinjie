using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWaitTime : TaskBase
{

    public float waitForTime = -1.0f;
    public float currentWaitTime;
    public TaskWaitTime(float duration)
    {
        waitForTime = duration;
        Debug.Log(waitForTime);
    }

    public override void Update(float deltaTime)
    {
        if (waitForTime > 0)
        {
            if (currentWaitTime <= waitForTime)
            {
                currentWaitTime += deltaTime;
            }
        
            else
            {
                IsFinished = true;
            }
        }
    }

    
}
