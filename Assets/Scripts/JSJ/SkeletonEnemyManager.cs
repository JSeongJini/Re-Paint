using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemyManager: KnightManager
{
    [SerializeField] private KnightCustomizer customizer = null;

    protected override void Awake()
    {
        knights = new List<Knight>(GetComponentsInChildren<Knight>());
    }

    protected override void Start()
    {
        gameObject.SetActive(false);
    }

    public new void StartBattle()
    {
        gameObject.SetActive(true);

        foreach (Knight knight in knights)
        {
            knight.StartBattle();
        }
    } 
}