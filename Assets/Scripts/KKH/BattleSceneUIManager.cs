//                               수정일 : 2021/12/18                                   //
//                               수정시간 : 3 : 30                                    //
//                               담당 : 김귀현                                         //
//                               기능 : 배틀씬 배틀파트 UI매니저
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleSceneUIManager : MonoBehaviour
{
    [SerializeField] private SelectManager selectManager;

    [SerializeField] private CameraController battleSceneCamera = null;

    [SerializeField] private Image knightStatusImage;
    [SerializeField] private Image BattlePickBtn = null;
    [SerializeField] private GameObject influenceHolder = null;

    [SerializeField] private Slider allyCountGage;
    [SerializeField] private Slider enemyCountGage;

    [Header("State Manager")]
    [SerializeField] private StateManager stateManager = null;


    [SerializeField] private Button battlePickBtn;
    [SerializeField] private Button ascendingBtn;

    [Header("InactiveUIs")]
    [SerializeField] private GameObject[] inactiveUI = null;

    private Text[] knightStatus = null;

    private KnightInformation selectedKnight = null;

    private void Start()
    {
        knightStatus = knightStatusImage.GetComponentsInChildren<Text>();
        stateManager = GameObject.FindObjectOfType<StateManager>();


        
        battlePickBtn.onClick.AddListener(() => BattlePick());
        InactiveUI();
    }

    private void InactiveUI()
    {
        for (int i = 0; i < inactiveUI.Length; i++)
            inactiveUI[i].SetActive(false);
    }

    public void UpdateAllyCountUI(int _aliveCount,int _totalCount)
    {
        allyCountGage.value = _aliveCount / (float)_totalCount;
    }
    public void UpdateEnemyCountUI(int _aliveCount, int _totalCount)
    {
        enemyCountGage.value = _aliveCount / (float)_totalCount;
    }


    public void TurnOnKnightStatus()
    {
        selectedKnight = selectManager.Selected_table[0].GetComponentInChildren<KnightInformation>();
        knightStatus[0].text = selectedKnight.KnightName;
        switch(selectedKnight.KnightType)
        {
            case EKnightType.Default:
                knightStatus[1].text = "인형";
                break;
            case EKnightType.Sword:
                knightStatus[1].text = "검병";
                break;
            case EKnightType.Spear:
                knightStatus[1].text = "창병";
                break;
            case EKnightType.Bow:
                knightStatus[1].text = "궁병";
                break;

        }
        knightStatus[2].text = selectedKnight.KnightRank.ToString();
        knightStatusImage.gameObject.SetActive(true);

        DescendGod();

    }
    public void TurnOffKnightStatus()
    {

        knightStatusImage.gameObject.SetActive(false);
    }


    public void ActiveBattlePickBtn(bool _bool)
    {
        BattlePickBtn.gameObject.SetActive(_bool);
    }

    public void ActiveInfluenceHolder()
    {
        influenceHolder.SetActive(true);
    }
    public void ActiveAscendingBtn(bool _bool)
    {
        ascendingBtn.gameObject.SetActive(_bool);
    }
    #region 버튼관리




    public void BattlePick()
    {
        stateManager.SetCurrentState(stateManager.GetComponentInChildren<BMPickState>());
    }
    public void BattleDescend()
    {
        stateManager.SetCurrentState(stateManager.GetComponentInChildren<BattleDescendState>());
    }
    public void BattleAscend()
    {
        stateManager.SetCurrentState(stateManager.GetComponentInChildren<BattleAscendState>());

    }
    public void DescendGod()
    {
        Knight knight = selectManager.Selected_table[0].GetComponentInChildren<Knight>();
        Button button = knightStatusImage.GetComponentInChildren<Button>();


        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => knight.ToggleControll());
        button.onClick.AddListener(() => battleSceneCamera.CameraViewToggle(knight.GetCamHolder()));
        button.onClick.AddListener(() => BattleDescend());

        AscendGod();
    }
    public void AscendGod()
    {
        Knight knight = selectManager.Selected_table[0].GetComponentInChildren<Knight>();
        

        ascendingBtn.onClick.RemoveAllListeners();
        ascendingBtn.onClick.AddListener(() => knight.ToggleControll());
        ascendingBtn.onClick.AddListener(() => battleSceneCamera.CameraViewToggle(knight.GetCamHolder(), BattleAscend));

    }
    #endregion
}
