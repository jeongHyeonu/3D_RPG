using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEmission : MonoBehaviour
{
    public SkinnedMeshRenderer renderer;
    Material material;

    bool isAttacked;

    public float duration = 1.0f;
    float timeLeft = 0f;

    private void Start()
    {
        material = renderer.material;
    }

    public void FX()
    {
        Debug.Log("FX");
        isAttacked = true;
        material.EnableKeyword("_EMISSION");
    }

    private void Update()
    {
        if (isAttacked)
        {
            if (timeLeft <= duration)
            {
                timeLeft += Time.deltaTime;
            }
            else
            {
                material.DisableKeyword("_EMISSION");
                isAttacked = false;
                timeLeft = 0f;
            }
        }
    }
}
