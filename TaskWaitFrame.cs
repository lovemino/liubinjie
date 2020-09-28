using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TaskWaitFrame : TaskBase
{
    
    public int waitForFrame = -1;
    public int currentWaitFrame;
    public TaskWaitFrame(int duration)
    {
        waitForFrame = duration;
    }
    public override void Update(float deltaTime){
    
                if (waitForFrame > 0)
               {
                   if (currentWaitFrame <= waitForFrame)
                   {
                       currentWaitFrame++;
                   }
               
                   else
                   {
                       IsFinished = true;
                   }
               }
    }
    
}
