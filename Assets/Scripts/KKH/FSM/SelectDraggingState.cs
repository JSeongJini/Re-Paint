//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ���� �巡�� ���� 
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
