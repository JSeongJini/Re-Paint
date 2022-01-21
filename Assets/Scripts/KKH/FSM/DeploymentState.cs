//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 배치하기 상태
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
