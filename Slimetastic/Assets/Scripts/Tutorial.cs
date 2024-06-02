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
        animator.SetTrigger("Load");
        audioSource.Play();
        StartCoroutine(TutorialWait(1));
    }

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

    IEnumerator TutorialWait(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
}
