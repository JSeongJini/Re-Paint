using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class KnightManager : SingleTon<KnightManager>
{
    [SerializeField] protected SelectManager selectManager;
    [SerializeField] protected List<Knight> knights = new List<Knight>();

    protected KnightsSpawner knightsSpawner = null;
    protected KnightCustomizer knightCustomizer = null;

    [SerializeField] protected List<KnightInformation> defaultKnight = new List<KnightInformation>();
    [SerializeField] protected List<KnightInformation> swordKnight = new List<KnightInformation>();
    [SerializeField] protected List<KnightInformation> spearKnight = new List<KnightInformation>();
    [SerializeField] protected List<KnightInformation> bowKnight = new List<KnightInformation>();

    protected List<KnightInformation> sortedDefaultKnight = new List<KnightInformation>();
    protected List<KnightInformation> sortedSwordKnight = new List<KnightInformation>();
    protected List<KnightInformation> sortedSpearKnight = new List<KnightInformation>();
    protected List<KnightInformation> sortedBowKnight = new List<KnightInformation>();

    protected virtual void Awake()
    {
        knightsSpawner = GetComponent<KnightsSpawner>();
        knightCustomizer = GetComponent<KnightCustomizer>();
    }

    protected virtual void Start()
    {
        if (GameManager.Instance.loadGame == false)
        {
            knightsSpawner.SpawnKnights(knights, 50);
            SetDefalutTypeAll();
        }
    }

    public bool IsReady()
    {
        return (defaultKnight.Count <= 0);
    }

    public int KnightCount()
    {
        return knights.Count;
    }

    public void StartBattle()
    {
        foreach (Knight knight in knights)
        {
            knight.StartBattle();
        }
    }

    public Knight[] GetKnightAll()
    {
        return knights.ToArray();
    }


    public EKnightType GetKnightType(int _index)
    {
        return knights[_index].GetComponent<KnightInformation>().KnightType;
    }

    public KnightInformation GetKnight(int _index, int _type)
    {
        if (_type == 0)
            return sortedDefaultKnight[_index];
        else if (_type == 1)
            return sortedSwordKnight[_index];
        else if (_type == 2)
            return sortedSpearKnight[_index];
        else if (_type == 3)
            return sortedBowKnight[_index];
        else return null;
    }

    public KnightInformation GetKnight(int _index)
    {
        return defaultKnight[_index];
    }

    public List<KnightInformation> GetKnightInformationListWithType(int _type)
    {
        if (_type == 0)
        { // 여기서 정렬하셈
            sortedDefaultKnight = defaultKnight.OrderBy(x => x.KnightRank).ToList();
            return sortedDefaultKnight;
        }
        else if (_type == 1)
        {
            sortedSwordKnight = swordKnight.OrderBy(x => x.KnightRank).ToList();
            return sortedSwordKnight;
        }
        else if (_type == 2)
        {
            sortedSpearKnight = spearKnight.OrderBy(x => x.KnightRank).ToList();
            return sortedSpearKnight;
        }
        else
        {
            sortedBowKnight = bowKnight.OrderBy(x => x.KnightRank).ToList();
            return sortedBowKnight;
        }
    }


    public void InputKnight(int _type)
    {
        for(int i = 0; i< selectManager.Selected_table.Count; i++)
        {
            KnightInformation knightInformation = selectManager.Selected_table[i].GetComponentInChildren<KnightInformation>();
            if(_type == (int)EKnightType.Sword)
            {
                swordKnight.Remove(knightInformation);
                defaultKnight.Remove(knightInformation);
                spearKnight.Remove(knightInformation);
                bowKnight.Remove(knightInformation);
                swordKnight.Add(knightInformation);
            }
            else if(_type == (int)EKnightType.Spear)
            {
                spearKnight.Remove(knightInformation);
                defaultKnight.Remove(knightInformation);
                swordKnight.Remove(knightInformation);
                bowKnight.Remove(knightInformation);
                spearKnight.Add(knightInformation);
            }
            else if(_type == (int)EKnightType.Bow)
            {
                bowKnight.Remove(knightInformation);
                defaultKnight.Remove(knightInformation);
                swordKnight.Remove(knightInformation);
                spearKnight.Remove(knightInformation);
                bowKnight.Add(knightInformation);
            }
        }
        selectManager.ListInitialization();
    }

    protected void SetDefalutTypeAll()
    {
        defaultKnight.Clear();
        swordKnight.Clear();
        spearKnight.Clear();
        bowKnight.Clear();

        for (int i = 0; i < knights.Count; i++)
            defaultKnight.Add(knights[i].GetComponent<KnightInformation>());
    }
}
