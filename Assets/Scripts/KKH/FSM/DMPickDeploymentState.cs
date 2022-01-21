//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 배치모드 찝기 배치 상태  
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
