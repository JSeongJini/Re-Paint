//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 배치모드 찝기 상태  
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
