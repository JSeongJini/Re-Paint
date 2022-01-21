using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour
{
    [SerializeField] private Button newGameButton = null;

    private GameManager gm = null;

    private void Awake()
    {
        if (newGameButton) newGameButton.onClick.AddListener(LoadWorldMapScene);

        gm = GameManager.Instance;
    }



    private void LoadWorldMapScene()
    {
        gm.LoadSceneWithName("WorldMap");
    }
}
