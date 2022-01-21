//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ��ġ�ϱ� ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentState : State
{

    [Header("State")]
    [SerializeField] DeploymentModeState deploymentModeState;

    public override State RunCurrentState()
    {
        selectManager.SetSelected(false);
        deployment.OnDeploy();
        deploymentSceneUIManager.UIOnOffWithoutJobList(true);
        return deploymentModeState;
    }
}
