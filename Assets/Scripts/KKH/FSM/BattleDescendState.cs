//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 강림 상태  
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
