using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class LoadScene : MonoBehaviour
{
    public GameObject loadingScene;
    public Slider slider;
    public TextMeshProUGUI progressText;

    private bool _isLoadingScene;

    private void Awake()
    {
        _isLoadingScene = false;
    }
    public void LoadLevel(string sceneName) {
        if (!_isLoadingScene)
            StartCoroutine(LoadAsynchronously(sceneName));
    }
    
    IEnumerator LoadAsynchronously(string sceneName)
    {
        float targetTime = slider.maxValue;
        float currentTime = 0f;
        float value = 0f;

        _isLoadingScene = true;

        loadingScene.SetActive(true);

        while (currentTime <= targetTime) // while tempo que tu definiste
        {
            print(currentTime);
            value = Mathf.Lerp(currentTime, targetTime, currentTime / targetTime);
            slider.value = value;
            progressText.text = "Loading - " + String.Format("{0:0.00}", value * 100f) + "%";

            currentTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
    }
}


