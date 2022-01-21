//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 단일 선택 상태 
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
