using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class Test : MonoBehaviour
{

    private  TaskSerial list1=new TaskSerial(new TaskBase[] {new TaskWaitFrame(2), new TaskWaitTime(5.0f) });
    private  TaskParall list2=new TaskParall(new TaskBase[] {new TaskWaitFrame(1), new TaskWaitTime(3.0f) });

    async void Start()
    {

        await list1.Begin();
        print("11111");
        await list2.Begin();
        print("22");
    }
    
    void Update()
    {
       
        list1.Update(Time.deltaTime);
        list2.Update(Time.deltaTime);
    }

    public void oncancelbutton()
    {
        list1.Cancel();
        list2.Cancel();
    }
    
}
