//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ���� ���� ���� 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSelectState : State
{
    [Header("State")]
    [SerializeField] private DeploymentModeState deploymentModeState;
   
    public override State RunCurrentState()
    {

        selectManager.OnSingleSelect(leftP1);
        if(selectManager.Selected_table.Count == 1)
            deploymentSceneUIManager.ActiveDeploymentPickBtn(true);
        else
        {
            deploymentSceneUIManager.ActiveDeploymentPickBtn(false);
        }
        return deploymentModeState;
    }
}
