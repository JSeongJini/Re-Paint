using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanelUI : MonoBehaviour
{
    [SerializeField] private Text injureKightsText = null;
    [SerializeField] private Text deadKightsText = null;
    [SerializeField] private Text timeText = null;
    [SerializeField] private Text rewardText = null;

    float deadProbability = 30f;


    public void SetDeadKinghtsText(int _injured, int _dead)
    {
        injureKightsText.text = _injured.ToString();
        deadKightsText.text = _dead.ToString();
    }

    public void SetTimeText(int _sec)
    {
        int min = _sec / 60;
        int sec = _sec % 60;

        string value = min + "m " + sec + "s";
        timeText.text = value;
    }

    public void SetRewardText(int _value)
    {
        rewardText.text = "x " + _value;
    }

}
