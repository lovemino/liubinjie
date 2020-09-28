using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSerial : TaskBase
{

    public TaskSerial(TaskBase[] array)
    {
        
        if (array != null)
        {
            for (int i = 0; i < array.Length; i++)
            {
                tasks.Add(array[i]);
            }
        }
       
    }
    public List<TaskBase> tasks = new List<TaskBase>();
    private bool isBegin = false;

    public TaskSerial Begin()
    {
        isBegin = true;
        return this;
    }

    public override void Update(float deltaTime)
    {
        if (!isBegin)
        {
            return;
        }

        if (tasks.Count > 0)
        {
            TaskBase task = tasks[0];
            task.Update(deltaTime);
            if (task.IsFinished)
            {
                tasks.RemoveAt(0);
            }
        }
        if (tasks.Count == 0 )
        {
            this.continuation?.Invoke();
            this.continuation = null;
            isBegin = false;
        }

    }

}
