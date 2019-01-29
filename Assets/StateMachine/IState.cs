public interface IState {

    void SetStateMachine(StateMachine stateMachine);
    void SetState(StateClassBase state);
    void SetState<T>(T state);

    void OnInit();
    void OnStateEnter();
    void Tick();
    void OnStateExit();
}
