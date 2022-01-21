//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ���� ���� ����  
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

