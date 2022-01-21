using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MVPPanelUI : MonoBehaviour
{
    [SerializeField] private Text killCountText = null;
    [SerializeField] private Text mvpNameText = null;

    public void SetKillCountText(int _killCount)
    {
        killCountText.text = _killCount + " KILL";
    }

    public void SetMVPNameText(string _name)
    {
        mvpNameText.text = _name;
    }

}
