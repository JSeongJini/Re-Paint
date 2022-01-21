//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 배틀 시작
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
