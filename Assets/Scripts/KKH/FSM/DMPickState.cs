//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ��ġ��� ��� ����  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMPickState : State
{

    [Header("State")]
    [SerializeField] private DMPickDeploymentState dmpickDeploymentState;
    public override State RunCurrentState()
    {
        if (Input.GetMouseButtonUp(1))
        {
            return dmpickDeploymentState;
        }
        else
        {
            selectManager.SetPickMode(true);
            selectManager.Pick();
            deploymentSceneUIManager.ActiveDeploymentPickBtn(false);
            deploymentSceneUIManager.UIOnOffWithoutJobList(false);
            deploymentSceneUIManager.ActiveChooseJobList(false);

            
            return this;
        }

    }
}
