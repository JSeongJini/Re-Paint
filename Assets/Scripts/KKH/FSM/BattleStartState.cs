//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ��Ʋ ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartState : State
{
    [Header("State")]
    [SerializeField] private BattleModeState battleModeState;
    public override State RunCurrentState()
    {
        battleSceneManager.StartBattle();
        selectManager.ListInitialization();
        return battleModeState;
    }
}
