using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarManager : MonoBehaviour
{
    public HPBar hpBar;
    public static HPBarManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void Create(Transform target, CharacterStat stat)
    {
        HPBar newhpBar = Instantiate(hpBar,transform) as HPBar;
        newhpBar.Init(target,stat);
    }
}
