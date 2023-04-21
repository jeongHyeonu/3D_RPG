using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    CharacterStat stat;

    private void OnEnable()
    {
        stat = GetComponent<CharacterStat>();
        stat.OnHPZero += Die;
    }

    private void OnDisable()
    {
        stat.OnHPZero -= Die;
    }

    public override void Interact()
    {
        //Debug.Log("Enemy-Player �������ϴ�.");
        Player.instance.combat.Attack(stat);
    }

    void Die()
    {
        Debug.Log("�� ĳ���� ���");
        //Destroy(this.gameObject,1f);
        PoolingManager.instance.ReturnObject(this.gameObject);
    }
}
