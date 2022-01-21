//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 선택 드래그 상태 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SelectDraggingState : State
{
    [Header("State")]
    [SerializeField] private MultiSelectState multiSelectState;
    public override State RunCurrentState()
    {

            if (Input.GetMouseButtonUp(0))
            {
                leftP3 = Input.mousePosition;
                return multiSelectState;
            }

            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject(-1))
            {

                    
                    leftP2 = Input.mousePosition;

                    deploymentSceneUIManager.DrawSelectBox(leftP1, leftP2);
                    deploymentSceneUIManager.UIOnOffWithoutJobList(false);
                    deploymentSceneUIManager.ActiveDeploymentPickBtn(false);
                    deploymentSceneUIManager.ActiveChooseJobList(false);
                    return this;
                
            }
            return this;

    }
}
