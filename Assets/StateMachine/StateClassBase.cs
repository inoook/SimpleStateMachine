public abstract class StateClassBase : IState
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

    public virtual void OnInit() { }
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
}