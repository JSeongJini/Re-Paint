//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ��ġ��� ��� ��ġ ����  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMPickDeploymentState : State
{
    [Header("State")]
    [SerializeField] private DeploymentModeState deploymentModeState;
    
    public override State RunCurrentState()
    {
        deploymentSceneUIManager.UIOnOffWithoutJobList(true);
        selectManager.SetPickMode(false);
        deploymentSceneUIManager.ActiveDeploymentPickBtn(false);
        deployment.PickDeploy();
        return deploymentModeState;
        
    }
}
