using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public string sceneName;

    private void Start()
    {
        Invoke("NextScene", 7f);
    }



    void NextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
