//                               수정일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 상태 추상화 클래스 및 전체 할당 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{

    protected static DeploymentSceneUIManager deploymentSceneUIManager = null;
    protected static BattleSceneUIManager battleSceneUIManager = null;
    protected static SelectManager selectManager;
    protected static Deployment deployment;
    protected static BattleSceneManager battleSceneManager;
    protected static Vector3 leftP1 = default; // 클릭
    protected static Vector3 leftP2 = default; // 드래그
    protected static Vector3 leftP3 = default; // 떼기

    protected static Vector3 rightP1 = default;
    protected static Vector3 rightP2 = default;
    protected static Vector3 rightP3 = default;

    public abstract State RunCurrentState();

    private void Start()
    {
        deploymentSceneUIManager = GameObject.FindObjectOfType<DeploymentSceneUIManager>();
        battleSceneUIManager = GameObject.FindObjectOfType<BattleSceneUIManager>();
        selectManager = GameObject.FindObjectOfType<SelectManager>();
        deployment = GameObject.FindObjectOfType<Deployment>();
        battleSceneManager = GameObject.FindObjectOfType<BattleSceneManager>();
    }

}
