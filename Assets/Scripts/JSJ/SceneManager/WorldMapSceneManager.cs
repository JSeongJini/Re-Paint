//                               수정일 : 2021/12/19                                  //
//                               수정시간 : 3 : 30                                    //
//                               담당 : 정성진                                         //
//                               기능 : 월드맵씬 매니저 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldMapSceneManager : MonoBehaviour
{
    [SerializeField] private WorldTrigger worldTrigger = null;
    [SerializeField] private GameObject tutorialManager = null;
   // [SerializeField] private DollManagePanel dollManagePanel = null;

    private GameManager gm = null;
    private GameObject tutorialPrefab = null;

    private void Awake()
    {
        gm = GameManager.Instance;
    }
    private void Start()
    {
        if (!GameManager.Instance.loadGame)
            tutorialPrefab = Instantiate(tutorialManager);
    }
    public void LoadBattleScene()
    {
        string sceneName = "Battle_" + worldTrigger.BattleField;
        gm.LoadSceneWithName(sceneName);
    }
}
