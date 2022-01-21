//                               ������ : 2021/12/17                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ���� �Ŵ��� 
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
        //Debug.Log("���� ���´� " + currentState);
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
