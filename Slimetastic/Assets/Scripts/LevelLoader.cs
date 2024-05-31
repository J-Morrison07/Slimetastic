using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static int level = 1;
    public Animator animator;
    public AudioSource audioSource;
    public GameObject resetButton;

    private void Start()
    {
        resetButton.SetActive(false);
        level = PlayerPrefs.GetInt("Level", 1);
        animator.ResetTrigger("Load");
        if (level != 1)
        {
            resetButton.SetActive(true);
        }
    }
    public void OnPlay()
    {
        animator.SetTrigger("Load");
        audioSource.Play();
        StartCoroutine(Wait(1));
    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene(level);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnReset()
    {
        level = 1;
        PlayerPrefs.SetInt("Level", level);
    }
}
