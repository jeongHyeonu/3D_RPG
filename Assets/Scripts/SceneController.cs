using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public Image fader;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            fader.rectTransform.sizeDelta = new Vector2(Screen.width + 20, Screen.height + 20);
            fader.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public IEnumerator FadeScene()
    {
        fader.gameObject.SetActive(true);

        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, t));
            yield return null;
        }

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("main");
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, t));
            yield return null;
        }

        yield return null;
        fader.gameObject.SetActive(false);
    }
}
