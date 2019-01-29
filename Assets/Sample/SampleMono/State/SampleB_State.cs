using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleB_State : StateMonoBase {
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Invoke("Next", 2);
    }
    void Next()
    {
        stateMachine.SetState(Sample.MyState.A);
    }

    private void Update()
    {
        Debug.Log("SampleB_State: update");
    }
}
