using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public void OnTutorial()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
    }

    public void OnBack()
    {
        SceneManager.LoadScene(0);
    }
}
