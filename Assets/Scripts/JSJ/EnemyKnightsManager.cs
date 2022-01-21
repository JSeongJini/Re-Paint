using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnightsManager : KnightManager
{
    [SerializeField] private KnightCustomizer customizer = null;

    protected override void Awake()
    {
        knights = new List<Knight>(GetComponentsInChildren<Knight>());
    }

    protected override void Start()
    {
        if(customizer)
            customizer.CustomizeEnemyKnight(knights);

        gameObject.SetActive(false);
    }
}