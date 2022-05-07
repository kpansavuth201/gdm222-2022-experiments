using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine {
    public string ID;

    public StateMachine(string id) {
        ID = id;
    }

    public delegate void DelegateNoArg();

    public DelegateNoArg OnEnter;
    public DelegateNoArg OnExit;
    public DelegateNoArg OnUpdate;
    public DelegateNoArg OnFixedUpdate;

    public void Enter() {
        OnEnter?.Invoke();
    }
    
    public void Exit() {
        OnExit?.Invoke();
    }

    public void Update() {
        OnUpdate?.Invoke();
    }
}

public class FiniteStateMachine {

    private Dictionary<string, StateMachine> stateMachineDict;

    private StateMachine currentStateMachine;

    public FiniteStateMachine() {
        stateMachineDict = new Dictionary<string, StateMachine>();
    }

    public void AddState(StateMachine state) {
        stateMachineDict.Add(state.ID, state);
    }

    public StateMachine GetState(string id) {
        if(stateMachineDict.ContainsKey(id)) {
            return stateMachineDict[id];
        } else {
            return null;
        }
    }

    private void SetCurrentState(StateMachine newState) {
        
        // If new state is same as current state, do nothing
        if(currentStateMachine == newState) {
            return;
        }
        
        // Change state process
        
        // First, exit from the current state
        if (currentStateMachine != null) {
            currentStateMachine.Exit();
        }

        // Second, enter a new state
        newState.Enter();
    
        // Finally, update currentStateMachine variable
        currentStateMachine = newState;
    }

    public void ChangeCurrentState(string id) {
        if(stateMachineDict.ContainsKey(id)) {
            StateMachine newState = stateMachineDict[id];
            SetCurrentState(newState);
        }
    }

    public void UpdateCurrentState() {
        if (currentStateMachine != null) {
            currentStateMachine.Update();
        }
    }
}
