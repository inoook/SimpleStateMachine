using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMonoBase : MonoBehaviour, IState
{
    protected StateMachine stateMachine;
    public void SetStateMachine(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public void SetState(StateClassBase state)
    {
        this.stateMachine.SetState(state);
    }
    public void SetState<T>(T state)
    {
        this.stateMachine.SetState(state);
    }
    public virtual void Tick() { }

    public virtual void OnInit()
    {
        this.enabled = false;
    }
    public virtual void OnStateEnter() {
        this.enabled = true;
    }
    public virtual void OnStateExit() {
        this.enabled = false;
    }
}