using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTime2 : MonoBehaviour
{
    public float sceneTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScene", sceneTime);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("Level2");
    }
}
