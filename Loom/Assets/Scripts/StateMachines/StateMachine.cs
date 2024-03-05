using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;

    public void SwitchState(State newState)     // Exit current state, enter new state
    {
        if (currentState != null)
            currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        if(currentState != null)
            currentState.Tick(Time.deltaTime); // Ticks every frame
    }
}
