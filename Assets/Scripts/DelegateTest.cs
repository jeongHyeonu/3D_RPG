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
        Debug.Log(n + "��ŭ�� ������ �޾ҽ��ϴ�.");
    }

    int AddHP(int n)
    {
        Debug.Log("HP�� " + n + "��ŭ ����");
        return hp + n;
    }

    int AddDefense(int n)
    {
        Debug.LogFormat("Defense�� {0}��ŭ ����",n);
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
