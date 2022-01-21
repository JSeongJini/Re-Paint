using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightInformation : MonoBehaviour
{
    [SerializeField]private string knightName = null;
    public string KnightName
    {
        get
        {
            return knightName;
        }
        set
        {
            knightName = value;
        }
    }
    [SerializeField]private Rank knightRank = Rank.SS;
    public Rank KnightRank
    {
        get
        {
            return knightRank;
        }
        set
        {
            knightRank = value;
        }
    }
    [SerializeField] private EKnightType knightType = EKnightType.Default;
    public EKnightType KnightType
    {
        get
        {
            return knightType;
        }
        set
        {
            knightType = value;
        }
    }
    
    public int exp = 0;
    public int nextExp = 20;

    public bool Upgrade()
    {
        exp += 10;

        if(exp >= nextExp)
        {
            RankUp();
            exp = 0;
            nextExp *= 2;
            return true;
        }

        return false;
    }

    public void RankUp()
    {
        if (knightRank == Rank.SS) return;

        knightRank--;

        //TODO : ½ºÅÈ°ü¸®?
    }

    public float GetExpRatio()
    {
        if (knightRank == Rank.SS) return 1f;

        return exp / (float)nextExp;
    }
    
}
