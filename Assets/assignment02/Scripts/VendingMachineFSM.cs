using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineFSM : MonoBehaviour
{
    private FiniteStateMachine finiteStateMachine;

    private void Initialize() {
        finiteStateMachine = new FiniteStateMachine();

        // Help me implement these states
        // BAHT_0
        // BAHT_5
        // BAHT_10
    }

    // Action
    public void Insert5bahtCoin() {
        // Implement change state logic here
    } 
    public void Insert10bahtCoin() {
        // Implement change state logic here
    }

    private void DispenseColaCan() {
        Debug.Log("Dispense Cola can");
    }
    
    void Awake() {
        Initialize();
        // [Output] Default state -> current state: BAHT_0
    }
    
    void Start() {
        // Test case        
        
        Insert5bahtCoin();
        // [Output] current state: BAHT_5
        Insert10bahtCoin();
        // [Output] Dispense cola can, current state: BAHT_0
        Insert10bahtCoin();
        // [Output] current state: BAHT_10
        Insert10bahtCoin();
        // [Output] Dispense cola can, current state: BAHT_5
        Insert5bahtCoin();
        // [Output] current state: BAHT_10
        Insert5bahtCoin();
        // [Output] Dispense cola can, current state: BAHT_0
    }

    void Update() {
        finiteStateMachine.UpdateCurrentState();
    }
}
