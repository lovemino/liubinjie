using UnityEngine;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

public class TaskBase: INotifyCompletion
{
    public bool canceled=false;
    public bool IsFinished = false;
    public bool IsCompleted { get { return IsFinished; } }
    
    
    public virtual void Update(float deltaTime)
    {
        if(IsFinished)
        {
            this.continuation?.Invoke();
            this.continuation = null;
            return;
        }

        if (IsFinished)
        {
            return;
        }
    }
   
    public virtual void Cancel()          
    {
        canceled = true;
        this.continuation?.Invoke();
        this.continuation = null;
    }

    public Action continuation;
    public void OnCompleted(Action continuation)
    {
        this.continuation += continuation;  
        Debug.Log("回调OnCompleted");
       
        
    }
    public TaskBase GetAwaiter()
    {
        Debug.Log("getawaiter");
        return this;
    }

    public virtual TaskBase GetResult()
    {
        if (canceled)
        {
            throw new Exception("canceled"); 
        }

        Debug.Log("getresult");
        return this;
    } 
}
