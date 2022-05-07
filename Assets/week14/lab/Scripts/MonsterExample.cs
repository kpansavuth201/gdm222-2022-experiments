using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterExample : MonoBehaviour
{
    private FiniteStateMachine finiteStateMachine;

    public GameObject Player;
    public GameObject Monster;

    public Transform MonsterHomeLocator;

    private const float MOVE_SPEED = 1f;

    private const float AGGRESSIVE_DISTANCE = 3f;

    private const float HOME_DISTANCE = 10f;

    private bool CheckMonsterAggresssive() {
        float distance = Vector3.Distance(
            Player.transform.position,
            Monster.transform.position
        );

        if( distance < AGGRESSIVE_DISTANCE ) {
            return true;
        } else {
            return false;
        }
    }

    private bool CheckMonsterForFromHome() {
        float distance = Vector3.Distance(
            Monster.transform.position,
            MonsterHomeLocator.position
        );

        if( distance > HOME_DISTANCE ) {
            return true;
        } else {
            return false;
        }
    }

    private void SetColor(GameObject obj, Color color) {
        obj.GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    private void Initialize() {
        finiteStateMachine = new FiniteStateMachine();
    }
    
    void Awake() {
        Initialize();
    }
    
    void Start() {
        
    }

    void Update() {
        finiteStateMachine.UpdateCurrentState();
    }
}
