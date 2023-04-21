using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image hpBar;
    public Transform target;
    public CharacterStat stat;

    Transform cam;

    public void Init(Transform target, CharacterStat stat)
    {
        this.target = target;
        this.stat = stat;
        cam = Camera.main.transform;
    }

    private void LateUpdate()
    {
        SetHP();
    }

    public void SetHP()
    {
        if (target == null) return;
        transform.position = target.position;
        transform.LookAt(new Vector3(cam.position.x,transform.position.y,cam.position.z),Vector3.zero);
        hpBar.fillAmount = NomalizeHP();
    }

    float NomalizeHP()
    {
        return Mathf.Clamp01(stat.CurrentHP / (float)stat.maxHP);
    }
}
