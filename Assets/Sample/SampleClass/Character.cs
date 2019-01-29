using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum State
    {
        ReturnHome,
        Wander
    }

    [SerializeField] StateMachine stateMachine;
    [SerializeField] private State currentState = State.ReturnHome;

    void Start()
    {
        // state の登録
        stateMachine.AddState(State.ReturnHome, new ReturnHomeState(this));
        stateMachine.AddState(State.Wander, new WanderState(this));

        stateMachine.onStateEnter = (IState state) => {
            currentState = stateMachine.GetCurrentState<State>();
            Debug.Log("onStateEnter: "+currentState);
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


    [SerializeField] private float moveSpeed = 1f;

    public void MoveToward(Vector3 destination)
    {
        var direction = GetDirection(destination);
        transform.Translate(direction * Time.deltaTime * moveSpeed);
    }

    private Vector3 GetDirection(Vector3 destination)
    {
        return (destination - transform.position).normalized;
    }

}