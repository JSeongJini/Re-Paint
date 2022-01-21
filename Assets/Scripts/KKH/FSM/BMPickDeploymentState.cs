//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ��Ʋ��� ��� ��ġ ����  
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
