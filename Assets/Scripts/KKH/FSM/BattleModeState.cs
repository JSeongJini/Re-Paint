//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 배틀 모드 상태(배틀 IDLE)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModeState : State
{
    [Header("State")]
    [SerializeField] private BattleSelectState battleSelectState = null;
    public override State RunCurrentState()
    {
        if(!selectManager.IsSelected())
            battleSceneUIManager.ActiveBattlePickBtn(false);
        if (Input.GetMouseButtonUp(0))
        {
            leftP3 = Input.mousePosition;
            return battleSelectState;
        }
        
        return this;
    }
}
