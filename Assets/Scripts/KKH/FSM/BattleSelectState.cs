//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ��Ʋ��� ���� ����(�ൿ)
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
