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

    private const float AGGRESSIVE_DISTANCE = 7f;

    private const float HOME_DISTANCE = 30f;

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

    private bool CheckMonsterFarFromHome() {
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

        StateMachine stateHome = new StateMachine("HOME");

        stateHome.OnEnter += () => {
            SetColor(Monster, Color.green);
        };
        stateHome.OnUpdate += () => {
            bool detectPlayer = CheckMonsterAggresssive();
            bool farFromHome = CheckMonsterFarFromHome();
            if(detectPlayer && !farFromHome) {
                finiteStateMachine.ChangeCurrentState("CHASE");
            }
        };

        finiteStateMachine.AddState(stateHome);

        StateMachine stateChase = new StateMachine("CHASE");

        stateChase.OnEnter += () => {
            SetColor(Monster, Color.red);
        };
        stateChase.OnUpdate += () => {
            bool detectPlayer = CheckMonsterAggresssive();
            bool farFromHome = CheckMonsterFarFromHome();
            if( !detectPlayer || farFromHome ) {
                finiteStateMachine.ChangeCurrentState("HOME");
            }
        };

        finiteStateMachine.AddState(stateChase);

        finiteStateMachine.ChangeCurrentState("HOME");
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
