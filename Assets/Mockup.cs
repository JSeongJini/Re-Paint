using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mockup : MonoBehaviour
{
    [SerializeField] public Knight[] knights;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartBattle();
        }
    }

    public void StartBattle()
    {
        foreach(Knight knight in knights)
        {
            knight.InitializeKnightInfomation(EKnightType.Sword);
            knight.StartBattle();
        }
    }
}
