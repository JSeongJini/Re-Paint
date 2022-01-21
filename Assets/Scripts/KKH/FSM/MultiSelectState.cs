//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 다중 선택 상태  
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
