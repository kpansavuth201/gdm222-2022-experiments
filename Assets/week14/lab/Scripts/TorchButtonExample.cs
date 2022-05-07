using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchButtonExample : MonoBehaviour
{
    private FiniteStateMachine finiteStateMachine;

    public GameObject LightObject;
    
    private void Initialize() {
        finiteStateMachine = new FiniteStateMachine();
        
        StateMachine buttonOnState = new StateMachine("BUTTON_ON");
        buttonOnState.OnEnter += () => {
            Debug.Log("Enter [BUTTON_ON]");
            LightOn();
        };
        buttonOnState.OnExit += () => {
            Debug.Log("Exit [BUTTON_ON]");
        };
        finiteStateMachine.AddState(buttonOnState);

        StateMachine buttonOffState = new StateMachine("BUTTON_OFF");
        buttonOffState.OnEnter += () => {
            Debug.Log("Enter [BUTTON_OFF]");
            LightOff();
        };
        buttonOffState.OnExit += () => {
            Debug.Log("Exit [BUTTON_OFF]");
        };
        finiteStateMachine.AddState(buttonOffState);

        // Set default state
        finiteStateMachine.ChangeCurrentState("BUTTON_OFF");
    }

    private void LightOn() {
        LightObject.SetActive(true);
    }

    private void LightOff() {
        LightObject.SetActive(false);
    }

    private void UpdateKeyboardInput() {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            Debug.Log("Up Arrow Pressed");
            finiteStateMachine.ChangeCurrentState("BUTTON_ON");
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            Debug.Log("Down Arrow Pressed");
            finiteStateMachine.ChangeCurrentState("BUTTON_OFF");
        }
    }

    void Awake() {
        Initialize();
    }
    
    void Start() {
        
    }

    void Update() {
        UpdateKeyboardInput();
        finiteStateMachine.UpdateCurrentState();
    }
}
