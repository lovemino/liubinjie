using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskParall : TaskBase
{
    public TaskParall(TaskBase[] array = null)
    {

        if (array != null)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    tasks.Add(array[i]);;
                }
            }
        }
    }
    public List<TaskBase> tasks = new List<TaskBase>();
    private bool isBegin = false;

    public TaskParall Begin()
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
        for (int i = 0; i < tasks.Count; i++)
        {
            TaskBase task = tasks[i];
            task.Update(deltaTime);
        }
        for (int i = tasks.Count -1; i >= 0; i--)
        {
            TaskBase task = tasks[i];

            if (task.IsFinished)
            {
                tasks.RemoveAt(i);
            }
            
        }
        if (tasks.Count == 0)
        {
            this.continuation?.Invoke();
            this.continuation = null;
            isBegin = false;
        }
    }

}
