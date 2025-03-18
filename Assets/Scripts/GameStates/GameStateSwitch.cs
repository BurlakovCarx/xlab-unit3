using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateSwitch : MonoBehaviour
{
    [SerializeField] private AGameState _startState;

    private AGameState _currentState;

    private void Start()
    {
        SwitchState(_startState);
    }

    public void SwitchState(AGameState state)
    {
        _currentState?.Exit();

        _currentState = state; 
        _currentState.Enter(); 
    }
}
