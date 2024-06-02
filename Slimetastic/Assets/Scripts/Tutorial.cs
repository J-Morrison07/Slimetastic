using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class Tutorial : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public void OnTutorial()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
    }

    public void OnBack()
    {
        animator.SetTrigger("Load");
        audioSource.Play();
        StartCoroutine(Wait(1));
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }
}
