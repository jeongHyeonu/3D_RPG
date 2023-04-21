using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadTest : MonoBehaviour
{
    public void LoadScene()
    {
        SceneController.instance.StartCoroutine(SceneController.instance.FadeScene());
    }
}
