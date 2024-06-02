using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class Flag : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        LevelLoader.level++;
        animator.ResetTrigger("Load");
        OnPlay();
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
        PlayerPrefs.SetInt("Level", LevelLoader.level);
        SceneManager.LoadScene(LevelLoader.level);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
