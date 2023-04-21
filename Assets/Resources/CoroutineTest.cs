using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    public MeshRenderer testRender;

    void Start()
    {
        StartCoroutine("FadeOutCo");
    }

    IEnumerator FadeOutCo()
    {
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = testRender.material.color;
            c.a = f;
            testRender.material.color = c;
            yield return null;
        }
    }
}
