//                               ������ : 2021/12/16                                   //
//                               �����ð� : 14 : 30                                    //
//                               ��� : �����                                         //
//                               ��� : ���� �߻�ȭ Ŭ���� �� ��ü �Ҵ� 
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
    protected static Vector3 leftP1 = default; // Ŭ��
    protected static Vector3 leftP2 = default; // �巡��
    protected static Vector3 leftP3 = default; // ����

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
