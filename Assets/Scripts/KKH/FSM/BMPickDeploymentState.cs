//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 배틀모드 찝기 배치 상태  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMPickDeploymentState : State
{

    [Header("State")]
    [SerializeField] private BattleModeState battleModeState;
    public override State RunCurrentState()
    {
        selectManager.SetPickMode(false);
        deployment.PickDeploy();
        battleSceneUIManager.ActiveBattlePickBtn(false);
        battleSceneUIManager.TurnOffKnightStatus();

        return battleModeState;
        
    }
}
