using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_State_Manager : MonoBehaviour
{
    public State currentState;
    public GameObject stateName;

    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
    }
    
    void Awake()
    {
        stateName.name = "Idle State";
    }

    private void RunStateMachine()
    {
        State changeToNextState = currentState?.RunCurrentState();

        if (changeToNextState != null)
        {
            //switches to the next state
            SwitchToNextState(changeToNextState);
        }
    }

    private void SwitchToNextState(State changeToNextState)
    {
        currentState = changeToNextState;
    }
}