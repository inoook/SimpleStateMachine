using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class StateMachine : MonoBehaviour {

    private Dictionary<object, IState> stateDic = new Dictionary<object, IState>();

    public delegate void OnChangeState(IState state);
    public OnChangeState onStateEnter;

    private IState currentState;
    [SerializeField] string currentStateClassName;

    public void AddState<T>(T stateEnum, IState state)
    {
        if (stateDic.ContainsKey(stateEnum)) {
            Debug.LogWarningFormat("Error: {0} は登録済みです。", stateEnum);
            return; // END
        }
        stateDic.Add(stateEnum, state);

        state.OnInit();
        state.SetStateMachine(this);
    }

    public void Initialize()
    {
        foreach (var o in stateDic)
        {
            (o.Value).OnInit();
        }
    }

    public void SetState<T>(T state)
    {
        if (!stateDic.ContainsKey(state)){
            return;// no key END
        }

        IState s = stateDic[state];
        SetState(s);
    }

    void SetState(IState state)
    {
        if(currentState == state) { return; } // END 

        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = state;
        //currentState.SetStateMachine(this);

        if (currentState != null)
        {
            currentState.OnStateEnter();
            currentStateClassName = currentState.GetType().Name;

            if (onStateEnter != null)
            {
                onStateEnter(currentState);
            }
        }
    }
    
    public IState GetCurrentState()
    {
        return currentState;
    }

    public T GetCurrentState<T>()
    {
        var key = stateDic.First(x => x.Value == currentState).Key;
        return (T)key;
    }

    public string GetCurrentStateName()
    {
        return currentStateClassName;
    }

    private void Update()
    {
        currentState.Tick();
    }

}
