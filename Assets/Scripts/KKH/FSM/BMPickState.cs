//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 배틀모드 찝기 상태 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMPickState : State
{
    [Header("State")]
    [SerializeField] private BMPickDeploymentState bmpickDeploymentState;
    public override State RunCurrentState()
    {
        if (Input.GetMouseButtonUp(1))
        {
            return bmpickDeploymentState;
        }
        else
        {
            selectManager.SetPickMode(true);
            selectManager.Pick();
            battleSceneUIManager.ActiveBattlePickBtn(false);
            battleSceneUIManager.TurnOffKnightStatus();

            return this;
        }

    }
}
