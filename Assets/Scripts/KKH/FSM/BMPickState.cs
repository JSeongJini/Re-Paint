//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ��Ʋ��� ��� ���� 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMPickState : State
{
    [Header("State")]
    [SerializeField] private BMPickDeploymentState bmpickDeploymentState;
    public override State RunCurrentState()
    {
        if (Input.GetMouseButtonUp(1))
        {
            return bmpickDeploymentState;
        }
        else
        {
            selectManager.SetPickMode(true);
            selectManager.Pick();
            battleSceneUIManager.ActiveBattlePickBtn(false);
            battleSceneUIManager.TurnOffKnightStatus();

            return this;
        }

    }
}
