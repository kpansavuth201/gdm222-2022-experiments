using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bonnie.Demo
{
    public enum GameState
    {
        NONE,
        INIT,
        LOGIN,
        INTRO,
        GAMEPLAY,           
        RESULT
    }
    
    public class GameStateManager : MonoBehaviour
    {
        private static GameStateManager _sharedInstance;
        public static GameStateManager SharedInstance {
            get{ return _sharedInstance; }
        }
        
        public delegate void StateChangedDelegate(GameState previousState, GameState currentState);

        public StateChangedDelegate OnGameStateChanged;        
        
        public GameState CurrentGameState {
            get {
                return _currentState;
            }
        }

        public GameState PreviousGameState {
            get {
                return _previousState;
            }
        } 
        
        private GameState _currentState = GameState.NONE;
        private GameState _previousState = GameState.NONE;

        void Awake() {
            _sharedInstance = this;
        }
        
        public bool ChangeGameState(GameState newState) {
            // Check if any restrict new state condition
            // For ex. :
            // if(_previousState == GameState.LOGIN && newState == GameState.RESULT) {
            //     return false;
            // }
            
            
            _previousState = _currentState;

            _currentState = newState;

            if(OnGameStateChanged != null) {
                OnGameStateChanged(_previousState, _currentState);
            }
            return true;
        }
    }
}