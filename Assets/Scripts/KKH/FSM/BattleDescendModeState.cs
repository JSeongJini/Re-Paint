//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ���� ��� ����  
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
