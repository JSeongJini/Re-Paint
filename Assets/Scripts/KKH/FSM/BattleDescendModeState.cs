//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 강림 모드 상태  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDescendModeState : State
{
    public override State RunCurrentState()
    {
        battleSceneUIManager.ActiveAscendingBtn(true);
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if(Input.GetKeyUp(KeyCode.LeftAlt))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        return this;
    }
}
