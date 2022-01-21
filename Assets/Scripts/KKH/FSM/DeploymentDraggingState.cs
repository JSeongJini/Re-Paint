//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 배치 드래그 상태 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentDraggingState : State
{
    [Header("State")]
    [SerializeField] private DeploymentState deploymentState;

    public override State RunCurrentState()
    {
        if (Input.GetMouseButtonUp(1))
        {
            rightP3 = Input.mousePosition;
            return deploymentState;
        }

        if(Input.GetMouseButton(1))
        {
            rightP2 = Input.mousePosition;
            deployment.OnDeployDrag(rightP1, rightP2);
            deploymentSceneUIManager.UIOnOffWithoutJobList(false);
            deploymentSceneUIManager.ActiveChooseJobList(false);
            deploymentSceneUIManager.ActiveDeploymentPickBtn(false);
            return this;
        }
        else 
            return this;
    }
}
