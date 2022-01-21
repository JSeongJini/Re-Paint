//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 강림 해제 상태  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAscendState : State
{
    [SerializeField] BattleModeState battleModeState;
    public override State RunCurrentState()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        battleSceneUIManager.ActiveAscendingBtn(false);
        return battleModeState;
    }
}

