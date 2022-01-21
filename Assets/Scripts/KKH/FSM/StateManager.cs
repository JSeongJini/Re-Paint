//                               수정일 : 2021/12/17                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 상태 매니저 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StateManager : MonoBehaviour
{

    [SerializeField] State currentState;

    void Update()
    {
        RunStateMachine();
        //Debug.Log("현재 상태는 " + currentState);
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if(nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }
    public State GetCurrentState()
    {
        return currentState;
    }
    public void SetCurrentState(State _state)
    {
        currentState = _state;
    }
}
