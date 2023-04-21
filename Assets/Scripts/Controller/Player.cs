using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public CharacterStat stat;
    public CharacterCombat combat;

    private void OnEnable()
    {
        stat.OnHPZero += Die;

    }

    public int hp = 100;

    private void Die()
    {
        Debug.Log("플레이어 사망");
    }
}
