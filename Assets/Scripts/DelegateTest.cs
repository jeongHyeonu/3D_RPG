using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest : MonoBehaviour
{
    public delegate int CharacterInfo(int val);

    public static event CharacterInfo CharacterInfoHandler;

    Action<int> CharacterInfo2;
    Func<int, int> CharacterInfo3;

    int hp = 0;
    int defense = 0;

    void Attack(int n)
    {
        Debug.Log(n + "만큼의 공격을 받았습니다.");
    }

    int AddHP(int n)
    {
        Debug.Log("HP가 " + n + "만큼 증가");
        return hp + n;
    }

    int AddDefense(int n)
    {
        Debug.LogFormat("Defense가 {0}만큼 증가",n);
        return defense + n;
    }

    int ChangeCharacterData(int val, CharacterInfo characterInfo)
    {
        int result = characterInfo(val);
        return result;
    }

    private void Start()
    {
        CharacterInfo2 += Attack;
        CharacterInfo2 += Attack;

        CharacterInfo3 += AddHP;
        CharacterInfo3 += AddDefense;

        if (CharacterInfo2!=null)
            CharacterInfo2(40);
        if(CharacterInfo3!=null)
            CharacterInfo3(50);
    }
}
