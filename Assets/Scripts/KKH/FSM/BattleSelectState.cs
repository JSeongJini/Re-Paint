//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 배틀모드 선택 상태(행동)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSelectState : State
{

    [Header("State")]
    [SerializeField] private BattleModeState battleModeState;
    public override State RunCurrentState()
    {
        selectManager.OnBattleSingleSelect(leftP3);
        if (selectManager.IsSelected())
        {
            battleSceneUIManager.ActiveBattlePickBtn(true);
            battleSceneUIManager.TurnOnKnightStatus();
        }
        else
        {
            battleSceneUIManager.TurnOffKnightStatus();
            battleSceneUIManager.ActiveBattlePickBtn(false);
        }
        return battleModeState;
    }
}
