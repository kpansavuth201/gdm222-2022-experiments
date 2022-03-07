using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bonnie.Demo
{
    public class ExampleGamePlay : MonoBehaviour
    {
        public delegate void GeneralDelegate();

        private GeneralDelegate OnUpdate;
        
        void Start()
        {            
            BindGameStateEvent();
        }

        private void InitializeGameplay() {
            // Initialize gameplay logic
        }

        private void ResetGameplay() {
            // Reset gameplay logic, for ex: reset object pool
        }

        private void BindGameStateEvent() {
            GameStateManager.SharedInstance.OnGameStateChanged += (GameState prevState, GameState currState) => {
                if(currState == GameState.GAMEPLAY) {
                    InitializeGameplay();
                    OnUpdate += PlayerMovement;
                    OnUpdate += EnemyMovement;
                }
                if(prevState == GameState.GAMEPLAY) {
                    OnUpdate -= PlayerMovement;
                    OnUpdate -= EnemyMovement;
                    // Alternatively
                    // OnUpdate = null;

                    ResetGameplay();
                }
            };
        }


        void Update()
        {
            if(OnUpdate != null) {
                OnUpdate();
            }
        }

        private void PlayerMovement() {
            // Do some player movement logic
        }

        private void EnemyMovement() {
            // Do some enemy logic
        }
    }
}
