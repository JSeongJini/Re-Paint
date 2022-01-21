//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 배치모드 상태
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DeploymentModeState : State
{
    [Header("State")]
    [SerializeField] SelectDraggingState selectDraggingState;
    [SerializeField] SingleSelectState singleSelectState;
    [SerializeField] DeploymentDraggingState deploymentDraggingState;
    [SerializeField] DeploymentState deploymentState;

    public override State RunCurrentState()
    {

        deploymentSceneUIManager.ActiveSelectBox(false);
        if(selectManager.Selected_table.Count == 1)
            deploymentSceneUIManager.ActiveDeploymentPickBtn(true);
        deploymentSceneUIManager.ActiveChooseJobList(selectManager.IsSelected());

        if (Input.GetMouseButtonDown(0))
        {
            leftP1 = Input.mousePosition;
            return this;
        }

            if (Input.GetMouseButton(0)&& !EventSystem.current.IsPointerOverGameObject(-1))
            {
                leftP2 = Input.mousePosition;

                if (Mathf.Abs((leftP1 - leftP2).magnitude) > 40f)
                {
                    return selectDraggingState;
                }
                else
                    return this;
            }
        
        if (!EventSystem.current.IsPointerOverGameObject(-1))
        {
            if (Input.GetMouseButtonUp(0))
            {
                return singleSelectState;
            }
        }

            if(selectManager.IsSelected())
            {
            if (!EventSystem.current.IsPointerOverGameObject(-1))
            {
                if (Input.GetMouseButtonDown(1))
                {
                    rightP1 = Input.mousePosition;
                }
            }
                if (Input.GetMouseButton(1) && selectManager.Selected_table.Count > 0)
                {
                    rightP2 = Input.mousePosition;
 
                    return deploymentDraggingState;
                }
            if (!EventSystem.current.IsPointerOverGameObject(-1))
            {
                if (Input.GetMouseButtonUp(1))
                {
                    rightP3 = Input.mousePosition;

                    return deploymentState;
                }
            }
        }
        return this;  
    }
}
