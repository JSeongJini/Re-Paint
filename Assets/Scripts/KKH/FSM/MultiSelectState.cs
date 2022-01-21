//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ���� ���� ����  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSelectState : State
{
    [Header("State")]
    [SerializeField] DeploymentModeState deploymentModeState;
    public override State RunCurrentState()
    {
        selectManager.OnDragSelect(leftP1, leftP3);
        deploymentSceneUIManager.UIOnOffWithoutJobList(true);
        return deploymentModeState;
    }
}
