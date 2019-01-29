# SimpleStateMachine
~~~cs
public enum State
{
    ReturnHome,
    Wander
}

[SerializeField] StateMachine stateMachine;

void Start()
{
    // state の登録
    stateMachine.AddState(State.ReturnHome, new ReturnHomeState(this));
    stateMachine.AddState(State.Wander, new WanderState(this));

    stateMachine.SetState(currentState);
}
~~~

~~~cs
IState.cs

public virtual void Tick() { }

public virtual void OnInit() { }
public virtual void OnStateEnter() { }
public virtual void OnStateExit() { }
~~~
