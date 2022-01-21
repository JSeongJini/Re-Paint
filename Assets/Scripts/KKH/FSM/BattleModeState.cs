//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ��Ʋ ��� ����(��Ʋ IDLE)
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
