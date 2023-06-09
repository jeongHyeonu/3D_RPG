using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public event Action OnHPZero;
    int currentHP;
    public int CurrentHP { get { return currentHP; } }
    public int maxHP;

    public int power = 10;

    private void OnEnable()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hitted(power);
        }
    }

    public void Heal(int heal)
    {
        currentHP += heal;
        currentHP = Math.Clamp(currentHP, 0, maxHP);
    }

    public void Hitted(int damage)
    {
        Mathf.Clamp(damage, 0, int.MaxValue);
        currentHP -= damage;

        if (currentHP <= 0) {
            OnHPZero?.Invoke();
        }

        Debug.Log(currentHP);
       
    }

    //void Die()
    //{
    //    Debug.Log(transform.name + " died");
    //}
}
