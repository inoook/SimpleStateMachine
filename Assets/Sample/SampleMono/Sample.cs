using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour {

    public enum MyState
    {
        A, B
    }

    [SerializeField] StateMachine stateMachine;
    [SerializeField] StateMonoBase[] states;

    [SerializeField] MyState currentState = MyState.A;

    [SerializeField] StateMonoBase _myState;

    // Use this for initialization
    void Start () {
        stateMachine.AddState(MyState.A, states[0]);
        stateMachine.AddState(MyState.B, states[1]);

        stateMachine.onStateEnter = (state) => {
            _myState = (StateMonoBase)state;
            currentState = stateMachine.GetCurrentState<MyState>();
        };
        stateMachine.SetState(currentState);
    }

    public void OnValidate()
    {
        if (Application.isPlaying)
        {
            stateMachine.SetState(currentState);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
