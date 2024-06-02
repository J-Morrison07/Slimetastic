using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public void OnBack()
    {
        animator.SetTrigger("Load");
        audioSource.Play();
        StartCoroutine(BackWait(1));
    }

    IEnumerator BackWait(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }

    public void OnCredits()
    {
        animator.SetTrigger("Load");
        audioSource.Play();
        StartCoroutine(CreditsWait(1));
    }

    IEnumerator CreditsWait(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 2);
    }
}
