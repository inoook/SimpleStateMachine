using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleA_State : StateMonoBase {
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Invoke("Next", 2);
    }
    void Next()
    {
        stateMachine.SetState(Sample.MyState.B);
    }

    private void Update()
    {
        Debug.Log("SampleA_State: update");
    }
}
