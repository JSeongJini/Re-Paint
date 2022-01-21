//                               수정,생성일 : 2021/12/16                                   //
//                               수정시간 : 14 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 배틀씬 내의 기본 UI매니저                      //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DefaultUIManager : MonoBehaviour
{


    [Header("Default UI")]
    [SerializeField] private Button menuBtn = null;
    [SerializeField] private Button keepMenuBtn = null;
    [SerializeField] private Button exitBtn = null;
    [SerializeField] private Image menuImage = null;
    [SerializeField] private Image optionImage = null;

    private AllyKnightsManager allyKnightsManager = null;
    

    private void Start()
    {
        allyKnightsManager = FindObjectOfType<AllyKnightsManager>();

        AddMenuButtonListener();
        AddMenuKeepButtonListener();
        AddMenuQuitButtonListener();
    }
    private void AddMenuButtonListener()
    {
        menuBtn.onClick.AddListener(() => ActiveMenuOnOffButton(true));

    }
    private void AddMenuKeepButtonListener()
    {
        keepMenuBtn.onClick.AddListener(() => ActiveMenuOnOffButton(false));
    }

    private void AddMenuQuitButtonListener()
    {
        exitBtn.onClick.AddListener(() => ExitBattle());
    }

    private void ExitBattle()
    {
        Time.timeScale = 1f;
        GameManager.Instance.LoadSceneWithName("WorldMap");
        allyKnightsManager.OnBattleEnd();
    }
    public void ActiveMenuOnOffButton(bool _isActive)
    {
        menuImage.gameObject.SetActive(_isActive);

        Time.timeScale = _isActive ? 0 : 1;
    }
    public void ActiveOptionOnOffButton(bool _isActive)
    {
        optionImage.gameObject.SetActive(_isActive);
    }
}
