//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ���� ����  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDescendState : State
{
    [Header("State")]
    [SerializeField]BattleDescendModeState battleDescendModeState;
    public override State RunCurrentState()
    {
        selectManager.ListInitialization();
        battleSceneUIManager.ActiveBattlePickBtn(false);

        battleSceneUIManager.TurnOffKnightStatus();

        return battleDescendModeState;
    }
}
